using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PeppaPig.Function;

namespace PeppaPig_s_Editor
{
    public partial class moveExtender : Form
    {
        private Form1 form1;

        int newMove = 1;

        List<byte> names = new List<byte>();
        List<byte> data = new List<byte>();
        List<byte> descriptions = new List<byte>();
        List<byte> animations = new List<byte>();

        public moveExtender(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void moveExtender_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            int offset = 0;

            #region Names
            byte[] nameByte = new byte[4615];
            byte[] nameAdd = new byte[newMove * 13];

            using(Stream s = new FileStream(Func.rom, FileMode.Open))
            {
                s.Seek(0x247094, SeekOrigin.Begin);
                s.Read(nameByte, 0, 4615);

                names.AddRange(nameByte);

                s.Seek(0x247094, SeekOrigin.Begin);
                s.Read(nameAdd, 0, newMove * 13);

                names.AddRange(nameAdd);
            }

            attackNamesBox.Text = Func.FindFreeSpace(offset, names.Count, Func.rom).ToString("X");
            if (Convert.ToInt32(attackNamesBox.Text, 16) == -1)
            {
                attackNamesBox.Clear();
            }
            else
            {
                offset = Convert.ToInt32(attackNamesBox.Text, 16) + 4615 + (newMove * 13);
            }
            #endregion

            #region Data
            byte[] dataByte = new byte[4260];
            byte[] dataAdd = new byte[newMove * 12];

            using (Stream s = new FileStream(Func.rom, FileMode.Open))
            {
                s.Seek(0x250C04, SeekOrigin.Begin);
                s.Read(dataByte, 0, 4260);

                data.AddRange(dataByte);

                s.Seek(0x250C04, SeekOrigin.Begin);
                s.Read(dataAdd, 0, newMove * 12);

                data.AddRange(dataAdd);
            }

            attackDataBox.Text = Func.FindFreeSpace(offset, data.Count, Func.rom).ToString("X");
            if (Convert.ToInt32(attackDataBox.Text, 16) == -1)
            {
                attackDataBox.Clear();
            }
            else
            {
                offset = Convert.ToInt32(attackDataBox.Text, 16) + 4260 + (newMove * 13);
            }
            #endregion

            #region Descriptions
            byte[] descriptionByte = new byte[1420];
            byte[] descriptionAdd = new byte[newMove * 4];

            using (Stream s = new FileStream(Func.rom, FileMode.Open))
            {
                s.Seek(0x4886E8, SeekOrigin.Begin);
                s.Read(descriptionByte, 0, 1420);

                descriptions.AddRange(descriptionByte);

                s.Seek(0x4886E8, SeekOrigin.Begin);
                s.Read(descriptionAdd, 0, newMove * 4);

                descriptions.AddRange(descriptionAdd);
            }

            descriptionBox.Text = Func.FindFreeSpace(offset, descriptions.Count, Func.rom).ToString("X");
            if (Convert.ToInt32(descriptionBox.Text, 16) == -1)
            {
                descriptionBox.Clear();
            }
            else
            {
                offset = Convert.ToInt32(descriptionBox.Text, 16) + 1420 + (newMove * 4);
            }
            #endregion

            #region Animation
            byte[] aniByte = new byte[2840];
            byte[] aniAdd = new byte[newMove * 8];

            using (Stream s = new FileStream(Func.rom, FileMode.Open))
            {
                s.Seek(0x1C68F4, SeekOrigin.Begin);
                s.Read(aniByte, 0, 2840);

                animations.AddRange(aniByte);

                s.Seek(0x1C68F4, SeekOrigin.Begin);
                s.Read(aniAdd, 0, newMove * 8);

                animations.AddRange(aniAdd);
            }

            animationBox.Text = Func.FindFreeSpace(offset, animations.Count, Func.rom).ToString("X");

            if (Convert.ToInt32(animationBox.Text, 16) == -1)
            {
                animationBox.Clear();
            }
            #endregion
        }

        private void moveNumberNumeric_ValueChanged(object sender, EventArgs e)
        {
            newMove = Convert.ToInt32(moveNumberNumeric.Value) - 354;
        }

        private void repointButton_Click(object sender, EventArgs e)
        {
            if (!Func.canSave)
            {
                MessageBox.Show("Please enable saving in the main menu", "Error");
                return;
            }

            if (attackNamesBox.Text != "")
            {
                Func.writeByte(Func.rom, names.ToArray(), Convert.ToInt32(attackNamesBox.Text, 16));
            }
            if (attackDataBox.Text != "")
            {
                Func.writeByte(Func.rom, data.ToArray(), Convert.ToInt32(attackDataBox.Text, 16));
            }
            if (descriptionBox.Text != "")
            {
                Func.writeByte(Func.rom, descriptions.ToArray(), Convert.ToInt32(descriptionBox.Text, 16));
            }
            if (animationBox.Text != "")
            {
                Func.writeByte(Func.rom, animations.ToArray(), Convert.ToInt32(animationBox.Text, 16));
            }

            Func.writeByte(Func.rom, new byte[8] {0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x13, 0xE0}, 0xD75FC);

            Func.repointAll("247094", attackNamesBox.Text, Func.rom);
            Func.repointAll("250C04", attackDataBox.Text, Func.rom);
            Func.repointAll("250C08", (Convert.ToInt32(attackNamesBox.Text, 16) + 4).ToString("X"), Func.rom);
            Func.repointAll("4886E8", descriptionBox.Text, Func.rom);
            Func.repointAll("1C68F4", animationBox.Text, Func.rom);

            MessageBox.Show("Successfully saved!", "Done");
        }
    }
}
