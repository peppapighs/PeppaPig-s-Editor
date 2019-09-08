using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Drawing;

namespace PeppaPig.Function
{
    class Func
    {
        public static string rom = "";
        public static bool canSave = false;

        public static bool isFireRed(string path)
        {
            if(path == "")
            {
                return false;
            }

            byte[] header = new byte[4];
            using (Stream s = new FileStream(path, FileMode.Open))
            {
                s.Seek(0xAC, SeekOrigin.Begin);
                s.Read(header, 0, 4);
            }

            if (Encoding.UTF8.GetString(header) != "BPRE")
            {
                return false;
            }

            return true;
        }

        public static byte[] imgBin(Bitmap b, Dictionary<Color, int> pal)
        {
            List<byte> res = new List<byte>();
            for (int l = 0; l < b.Height / 8; l++)
            {
                for (int k = 0; k < b.Width / 8; k++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        for (int i = 0; i < 8; i += 2)
                        {
                            int p1, p2;
                            if (pal.ContainsKey(b.GetPixel((k * 8) + i, (l * 8) + j)))
                            {
                                p1 = pal[b.GetPixel((k * 8) + i, (l * 8) + j)];
                            }
                            else
                            {
                                p1 = 0;
                            }
                            if (pal.ContainsKey(b.GetPixel((k * 8) + i + 1, (l * 8) + j)))
                            {
                                p2 = pal[b.GetPixel((k * 8) + i + 1, (l * 8) + j)];
                            }
                            else
                            {
                                p2 = 0;
                            }

                            res.Add(Convert.ToByte((p1 & 15) | ((p2 & 15) << 4)));
                        }
                    }
                }
            }

            return res.ToArray();
        }

        public static void writeByte(string path, byte[] data, int offset)
        {
            using (Stream stream = File.Open(path, FileMode.Open))
            {
                stream.Position = offset;
                stream.Write(data, 0, data.Length);
            }
        }

        public static byte[] repoint(int off)
        {
            List<byte> res = new List<byte>();
            res.Add(Convert.ToByte(off & 255));
            res.Add(Convert.ToByte((off >> 8) & 255));
            res.Add(Convert.ToByte((off >> 16) & 255));
            res.Add(0x8);

            return res.ToArray();
        }

        public enum CompressionMode
        {
            Old, // Good
            New  // Perfect!
        }

        public static byte[] CompressBytes(byte[] Data, CompressionMode Mode = CompressionMode.New)
        {
            byte[] header = BitConverter.GetBytes(Data.Length);
            List<byte> Bytes = new List<byte>();
            List<byte> PreBytes = new List<byte>();
            byte Watch = 0;
            byte ShortPosition = 2;
            int ActualPosition = 2;
            int match = -1;

            int BestLength = 0;

            // Adds the Lz77 header to the bytes 0x10 3 bytes size reversed
            Bytes.Add(0x10);
            Bytes.Add(header[0]);
            Bytes.Add(header[1]);
            Bytes.Add(header[2]);

            // Lz77 Compression requires SOME starting data, so we provide the first 2 bytes
            PreBytes.Add(Data[0]);
            PreBytes.Add(Data[1]);

            // Compress everything
            while (ActualPosition < Data.Length)
            {
                //If we've compressed 8 of 8 bytes
                if (ShortPosition == 8)
                {
                    // Add the Watch Mask
                    // Add the 8 steps in PreBytes
                    Bytes.Add(Watch);
                    Bytes.AddRange(PreBytes);

                    Watch = 0;
                    PreBytes.Clear();

                    // Back to 0 of 8 compressed bytes
                    ShortPosition = 0;
                }
                else
                {
                    // If we are approaching the end
                    if (ActualPosition + 1 < Data.Length)
                    {
                        // Old NSE 1.x compression lookup
                        if (Mode == CompressionMode.Old)
                        {
                            match = SearchBytesOld(
                                Data,
                                ActualPosition,
                                Math.Min(4096, ActualPosition));
                        }
                        else if (Mode == CompressionMode.New)
                        {
                            // New NSE 2.x compression lookup
                            match = SearchBytes(
                                        Data,
                                        ActualPosition,
                                        Math.Min(4096, ActualPosition), out BestLength);
                        }
                    }
                    else
                    {
                        match = -1;
                    }

                    // If we have NOT found a match in the compression lookup
                    if (match == -1)
                    {
                        // Add the byte
                        PreBytes.Add(Data[ActualPosition]);
                        // Add a 0 to the mask
                        Watch = BitConverter.GetBytes((int)Watch << 1)[0];

                        ActualPosition++;
                    }
                    else
                    {
                        // How many bytes match
                        int length = -1;

                        int start = match;
                        if (Mode == CompressionMode.Old || BestLength == -1)
                        {
                            // Old look-up technique
                            # region GetLength_Old
                            start = match;

                            bool Compatible = true;

                            while (Compatible == true && length < 18 && length + ActualPosition < Data.Length - 1)
                            {
                                length++;
                                if (Data[ActualPosition + length] != Data[ActualPosition - start + length])
                                {
                                    Compatible = false;
                                }
                            }
                            #endregion
                        }
                        else if (Mode == CompressionMode.New)
                        {
                            // New lookup (Perfect Compression!)
                            length = BestLength;
                        }

                        // Add the rel-compression pointer (P) and length of bytes to copy (L)
                        // Format: L P P P
                        byte[] b = BitConverter.GetBytes(((length - 3) << 12) + (start - 1));

                        b = new byte[] { b[1], b[0] };
                        PreBytes.AddRange(b);

                        // Move to the next position
                        ActualPosition += length;

                        // Add a 1 to the bit Mask
                        Watch = BitConverter.GetBytes(((int)Watch << 1) + 1)[0];
                    }

                    // We've just compressed 1 more 8
                    ShortPosition++;
                }


            }

            // Finnish off the compression
            if (ShortPosition != 0)
            {
                //Tyeing up any left-over data compression
                Watch = BitConverter.GetBytes((int)Watch << (8 - ShortPosition))[0];

                Bytes.Add(Watch);
                Bytes.AddRange(PreBytes);
            }

            // Return the Compressed bytes as an array!
            return Bytes.ToArray();
        }

        public static int SearchBytesOld(byte[] Data, int Index, int Length)
        {
            int found = -1;
            int pos = 2;

            if (Index + 2 < Data.Length)
            {
                while (pos < Length + 1 && found == -1)
                {
                    if (Data[Index - pos] == Data[Index] && Data[Index - pos + 1] == Data[Index + 1])
                    {

                        if (Index > 2)
                        {
                            if (Data[Index - pos + 2] == Data[Index + 2])
                            {
                                found = pos;
                            }
                            else
                            {
                                pos++;
                            }
                        }
                        else
                        {
                            found = pos;
                        }


                    }
                    else
                    {
                        pos++;
                    }
                }

                return found;
            }
            else
            {
                return -1;
            }

        }

        public static int SearchBytes(byte[] Data, int Index, int Length, out int match)
        {

            int pos = 2;
            match = 0;
            int found = -1;

            if (Index + 2 < Data.Length)
            {
                while (pos < Length + 1 && match != 18)
                {
                    if (Data[Index - pos] == Data[Index] && Data[Index - pos + 1] == Data[Index + 1])
                    {

                        if (Index > 2)
                        {
                            if (Data[Index - pos + 2] == Data[Index + 2])
                            {
                                int _match = 2;
                                bool Compatible = true;
                                while (Compatible == true && _match < 18 && _match + Index < Data.Length - 1)
                                {
                                    _match++;
                                    if (Data[Index + _match] != Data[Index - pos + _match])
                                    {
                                        Compatible = false;
                                    }
                                }
                                if (_match > match)
                                {
                                    match = _match;
                                    found = pos;
                                }

                            }
                            pos++;
                        }
                        else
                        {
                            found = pos;
                            match = -1;
                            pos++;
                        }


                    }
                    else
                    {
                        pos++;
                    }
                }

                return found;
            }
            else
            {
                return -1;
            }

        }

        public static int FindFreeSpace(int StartOffset, int Size, string FilePath, bool Safe = true)
        {
            int _return = -1;
            int FindPos = StartOffset;
            if (Safe == true)
            {
                FindPos = FindPos - FindPos % 4;
            }
            int check = -1;
            int Window = 0xFFFFFF;
            //Creating and filling search buffer
            byte[] SearchBytes = new byte[Size - 1];
            for (int i = 0; i < Size - 1; i++)
            {
                SearchBytes[i] = 0xFF;
            }

            //Creating ReadBuffer
            byte[] ReadBytes;

            FileStream Stream = System.IO.File.Open(FilePath, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
            BinaryReader br = new BinaryReader(Stream);
            br.BaseStream.Seek(FindPos, SeekOrigin.Begin);
            while (check == -1 && FindPos < Stream.Length - 513)
            {
                ReadBytes = br.ReadBytes(Window);
                if (Safe == true)
                {
                    check = FindSafeBytes(ReadBytes, SearchBytes);
                }
                else
                {
                    check = FindBytes(ReadBytes, SearchBytes);
                }
                if (check != -1)
                {
                    if (Safe == false)
                    {
                        _return = FindPos + check;
                    }
                    else if (Safe == true && (FindPos + check) % 4 == 0)
                    {
                        _return = FindPos + check;
                    }
                    else
                    {
                        check = -1;
                        FindPos += Window - SearchBytes.Length;
                    }
                }
                else
                {
                    FindPos += Window - SearchBytes.Length;
                }
            }
            br.Close();
            return _return;

        }

        public static int FindBytes(byte[] Bytes, byte[] SearchBytes, int Offset = 0)
        {
            int _return = -1;
            int fpos2 = 0;
            bool compatible = false;
            while (!(Offset == Bytes.Length - SearchBytes.Length | _return != -1 | Offset == Bytes.Length))
            {
                if (Bytes[Offset] == SearchBytes[0] & Bytes[Offset + 1] == SearchBytes[1])
                {
                    compatible = true;
                    fpos2 = 0;
                    while (!(fpos2 == SearchBytes.Length || compatible == false))
                    {
                        if (Bytes[Offset + fpos2] != SearchBytes[fpos2])
                        {
                            compatible = false;
                        }
                        fpos2 = fpos2 + 1;
                    }
                    if (compatible == true)
                    {
                        _return = Offset;
                    }
                    else
                    {
                        _return = -1;
                    }

                }
                Offset = Offset + 1;
            }
            return _return;
        }

        public static int FindSafeBytes(byte[] Bytes, byte[] SearchBytes, int Offset = 0)
        {
            Offset = Offset - (Offset % 4);

            int _return = -1;
            int fpos2 = 0;
            bool compatible = false;
            while (!(Offset == Bytes.Length - SearchBytes.Length | _return != -1 | Offset == Bytes.Length))
            {
                if (Bytes[Offset] == SearchBytes[0] & Bytes[Offset + 1] == SearchBytes[1])
                {
                    compatible = true;
                    fpos2 = 0;
                    while (!(fpos2 == SearchBytes.Length || compatible == false))
                    {
                        if (Bytes[Offset + fpos2] != SearchBytes[fpos2])
                        {
                            compatible = false;
                        }
                        fpos2 = fpos2 + 1;
                    }
                    if (compatible == true)
                    {
                        _return = Offset;
                    }
                    else
                    {
                        _return = -1;
                    }

                }
                Offset = Offset + 4;
            }
            return _return;
        }

        public static string[] horspool(string path, string search)
        {
            byte[] oldP = new byte[4];
            List<string> pointer = new List<string>();

            int oldT = Convert.ToInt32(search, 16);

            oldP[0] = Convert.ToByte(oldT & 255);
            oldP[1] = Convert.ToByte((oldT >> 8) & 255);
            oldP[2] = Convert.ToByte((oldT >> 16) & 255);
            oldP[3] = Convert.ToByte((oldT >> 24) & 255);

            byte[] rom = File.ReadAllBytes(Func.rom);
            int[] table = new int[256];

            for (int i = 0; i < 256; i++)
            {
                table[i] = 4;
            }
            for (int i = 0; i < 3; i++)
            {
                table[(int)oldP[i]] = 3 - i;
            }

            int n = rom.Length;
            int m = 4;
            int pos = m - 1;

            while (pos < n)
            {
                int k = 0;
                while (k < m && oldP[m - k - 1] == rom[pos - k])
                {
                    k++;
                }

                if (k == m)
                {
                    pointer.Add((pos - m + 1).ToString("X"));
                    pos += 4;
                }
                else
                {
                    pos += table[(int)rom[pos]];
                }
            }

            return pointer.ToArray();
        }

        public static void repointAll(string oldOff, string newOff, string path)
        {
            string[] search = horspool(path, oldOff);
            byte[] newP = repoint(Convert.ToInt32(newOff, 16));

            for(int i=0;i<search.Length;i++)
            {
                writeByte(path, newP, Convert.ToInt32(search[i], 16));
            }
        }
    }
}
