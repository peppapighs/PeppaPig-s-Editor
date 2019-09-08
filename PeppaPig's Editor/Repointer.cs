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
    public partial class Repointer : Form
    {
        private Form1 form1;

        public Repointer(Form1 form)
        {
            InitializeComponent();
            form1 = form;
        }


        private void Repointer_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (oldPointerBox.Text == "")
            {
                return;
            }

            listBox1.Items.Clear();

            listBox1.Items.AddRange(Func.horspool(Func.rom, oldPointerBox.Text));
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            if (!Func.canSave)
            {
                MessageBox.Show("Please enable saving in the main menu", "Error");
                return;
            }

            if(listBox1.SelectedIndex != -1)
            {
                if(newPointerBox.Text == "")
                {
                    return;
                }

                byte[] newP = new byte[4];

                long newT = Convert.ToInt64(newPointerBox.Text, 16);

                newP[0] = Convert.ToByte(newT & 255);
                newP[1] = Convert.ToByte((newT >> 8) & 255);
                newP[2] = Convert.ToByte((newT >> 16) & 255);
                newP[3] = Convert.ToByte((newT >> 24) & 255);

                Func.writeByte(Func.rom, newP, Convert.ToInt32(listBox1.Items[listBox1.SelectedIndex].ToString(), 16));

                int indx = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(indx);

                if(indx < listBox1.Items.Count)
                {
                    listBox1.SelectedIndex = indx;
                }

                MessageBox.Show("Finish repointing", "Done");
            }
        }

        private void replaceAllButton_Click(object sender, EventArgs e)
        {
            if (!Func.canSave)
            {
                MessageBox.Show("Please enable saving in the main menu", "Error");
                return;
            }

            if (newPointerBox.Text == "")
            {
                return;
            }

            byte[] newP = new byte[4];

            long newT = Convert.ToInt64(newPointerBox.Text, 16);

            newP[0] = Convert.ToByte(newT & 255);
            newP[1] = Convert.ToByte((newT >> 8) & 255);
            newP[2] = Convert.ToByte((newT >> 16) & 255);
            newP[3] = Convert.ToByte((newT >> 24) & 255);

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Func.writeByte(Func.rom, newP, Convert.ToInt32(listBox1.Items[listBox1.SelectedIndex].ToString(), 16));
                listBox1.Items.RemoveAt(i);
            }

            MessageBox.Show("Finish repointing", "Done");
        }
    }
}
