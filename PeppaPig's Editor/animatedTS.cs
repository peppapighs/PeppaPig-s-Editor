using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PeppaPig.Function;

namespace PeppaPig_s_Editor
{
    public partial class animatedTS : Form
    {
        private Form1 form1;

        int fWidth, fHeight;
        Color[] palette = Enumerable.Repeat(Color.Black, 16).ToArray();
        Dictionary<Color, int> palDict = new Dictionary<Color, int>();

        public animatedTS(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void animatedTS_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            openImg.ShowDialog();
            if (openImg.FileNames.Length == 0)
            {
                return;
            }
            else if (openImg.FileNames.Length + listBox1.Items.Count > 255)
            {
                MessageBox.Show("Exceeding 255 frames", "Error");
                return;
            }

            for (int i = 0; i < openImg.FileNames.Length; i++)
            {
                Bitmap tmp = new Bitmap(openImg.FileNames[i]);
                if (tmp.Width % 8 != 0 || tmp.Height % 8 != 0)
                {
                    MessageBox.Show("Image dimension must be divisible by 8 :\n" + openImg.FileNames[i], "Error");
                    return;
                }
                else
                {
                    if (listBox1.Items.Count == 0)
                    {
                        if (tmp.Palette.Entries.Length > 16)
                        {
                            MessageBox.Show("Image color must be 16-bit depth :\n" + openImg.FileNames[i], "Error");
                            return;
                        }
                        for (int j = 0; j < tmp.Palette.Entries.Length; j++)
                        {
                            palette[j] = tmp.Palette.Entries[j];
                        }
                        int k = 0;
                        for (int j = 0; j < 16; j++)
                        {
                            if (!palDict.ContainsKey(palette[j]))
                            {
                                palDict[palette[j]] = k++;
                            }
                        }

                        fWidth = tmp.Width;
                        fHeight = tmp.Height;

                        listBox1.Items.Add(openImg.FileNames[i]);
                    }
                    else
                    {
                        if (tmp.Palette.Entries.Length > 16)
                        {
                            MessageBox.Show("Image color must be 16-bit depth :\n" + openImg.FileNames[i], "Error");
                            return;
                        }
                        else if (tmp.Width != fWidth || tmp.Height != fHeight)
                        {
                            MessageBox.Show("Image dimension must be the same :\n" + openImg.FileNames[i], "Error");
                            return;
                        }
                        listBox1.Items.Add(openImg.FileNames[i]);
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int indx = listBox1.SelectedIndex;

            if (indx != -1)
            {
                listBox1.Items.RemoveAt(indx);
                if (indx < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex = indx;
                }
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            if(!Func.canSave)
            {
                MessageBox.Show("Please enable saving in the main menu", "Error");
                return;
            }

            try
            {
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("No frame has been added", "Error");
                    return;
                }

                if(startBox.Text == "")
                {
                    MessageBox.Show("Please enter start searching offset", "Error");
                    return;
                }

                try
                {
                    Convert.ToInt32(startBox.Text, 16);
                }
                catch(Exception err)
                {
                    MessageBox.Show("Invalid offset", "Error");
                    return;
                }

                List<int> imgOff = new List<int>();
                int stOff = Convert.ToInt32(startBox.Text, 16);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    byte[] img = Func.CompressBytes(Func.imgBin(new Bitmap(listBox1.Items[i].ToString()), palDict));
                    int tmpOff = Func.FindFreeSpace(stOff, img.Length, Func.rom);

                    if (tmpOff == -1)
                    {
                        MessageBox.Show("Not enough space", "Error");
                        return;
                    }

                    Func.writeByte(Func.rom, img, tmpOff);
                    imgOff.Add(tmpOff);
                }

                List<byte> ani = new List<byte>();
                for (int i = 1; i < imgOff.Count; i++)
                {
                    ani.AddRange(Func.repoint(imgOff[i - 1]));
                    ani.Add(0x3);
                    ani.Add(Convert.ToByte(i));
                    ani.Add(0xFF);
                    ani.Add(0xFF);
                }

                ani.AddRange(Func.repoint(imgOff[imgOff.Count - 1]));
                ani.Add(0x3);
                ani.Add(0x0);
                ani.Add(0xFF);
                ani.Add(0xFF);

                byte[] aniByte = ani.ToArray();

                int aniOff = Func.FindFreeSpace(stOff, aniByte.Length, Func.rom);
                if (aniOff == -1)
                {
                    MessageBox.Show("Not enough space", "Error");
                    return;
                }

                Func.writeByte(Func.rom, aniByte, aniOff);

                byte[] ts = PeppaPig_s_Editor.Properties.Resources.ts;
                byte[] load = PeppaPig_s_Editor.Properties.Resources.load;

                ts[52] = Func.repoint(aniOff)[0];
                ts[53] = Func.repoint(aniOff)[1];
                ts[54] = Func.repoint(aniOff)[2];

                int tsOff = Func.FindFreeSpace(stOff, ts.Length, Func.rom);
                if (tsOff == -1)
                {
                    MessageBox.Show("Not enough space", "Error");
                    return;
                }

                Func.writeByte(Func.rom, ts, tsOff);

                Func.writeByte(Func.rom, load, 0x78BFC);

                Func.writeByte(Func.rom, Func.repoint(tsOff + 1), 0x78C1C);

                if (paletteCheckBox.Checked)
                {
                    int offset = 0xEAD5E8;

                    for (int i = 0; i < 16; i++)
                    {
                        int pal = ((palette[i].R >> 3) & 31) | (((palette[i].G >> 3) & 31) << 5) | (((palette[i].B >> 3) & 31) << 10);
                        byte[] x = new byte[2];
                        x[0] = Convert.ToByte(pal & 255);
                        x[1] = Convert.ToByte((pal >> 8) & 255);

                        Func.writeByte(Func.rom, x, offset);

                        offset += 2;
                    }
                }

                MessageBox.Show("Save rom successfully", "Done");
            }
            catch (Exception err)
            {
                MessageBox.Show("Error :\n" + err.Message, "Error");
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
