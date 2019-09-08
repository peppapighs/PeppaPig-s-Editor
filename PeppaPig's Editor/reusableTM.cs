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
    public partial class reusableTM : Form
    {
        private Form1 form1;

        public reusableTM(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }

        private void reusableTM_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void patchButton_Click(object sender, EventArgs e)
        {
            if (!Func.canSave)
            {
                MessageBox.Show("Please enable saving in the main menu", "Error");
                return;
            }

            if (hideBox.Checked)
            {
                byte[] hideQ = PeppaPig_s_Editor.Properties.Resources.hideQ;
                int off = Func.FindFreeSpace(0x800000, hideQ.Length, Func.rom);
                if (off == -1)
                {
                    MessageBox.Show("Not enough space", "Error");
                    return;
                }

                Func.writeByte(Func.rom, hideQ, off);

                byte[] rep = new byte[8] { 0x0, 0x48, 0x0, 0x47, 0x0, 0x0, 0x0, 0x8 };
                off++;
                rep[4] = Convert.ToByte(off & 255);
                rep[5] = Convert.ToByte((off >> 8) & 255);
                rep[6] = Convert.ToByte((off >> 16) & 255);

                Func.writeByte(Func.rom, rep, 0x131EF4);
            }

            byte[] zero = new byte[4] { 0x0, 0x0, 0x0, 0x0 };
            Func.writeByte(Func.rom, zero, 0x124F78);
            Func.writeByte(Func.rom, zero, 0x125C80);

            byte[] e0 = new byte[1] { 0xE0 };
            Func.writeByte(Func.rom, e0, 0x131EA5);

            if (ungivableBox.Checked)
            {
                byte[] tmp = new byte[4] { 0x0, 0x0, 0x17, 0xE0 };
                Func.writeByte(Func.rom, tmp, 0x1326B8);
            }

            if (unsellBox.Checked)
            {
                int off = 0x3DE1E4;
                byte[] tmp = new byte[2] { 0x0, 0x0 };

                for (int i = 0; i < 50; i++)
                {
                    Func.writeByte(Func.rom, tmp, off);
                    off += 0x2C;
                }
            }

            MessageBox.Show("Successfully saved!", "Done");
        }
    }
}
