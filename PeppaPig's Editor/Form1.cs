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
    public partial class Form1 : Form
    {
        About about = new About();

        public Form1()
        {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openRom.ShowDialog();
            if(openRom.FileName == "")
            {
                return;
            }

            if(Func.isFireRed(openRom.FileName))
            {
                groupBox2.Enabled = true;
                Func.rom = openRom.FileName;
                romTextBox.Text = openRom.FileName;
            }
            else
            {
                groupBox2.Enabled = false;
                Func.rom = "";
                romTextBox.Clear();

                MessageBox.Show("Cannot open rom", "Error");
            }
        }

        private void savingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Func.canSave = savingCheckBox.Checked;
        }

        private void aniButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            animatedTS ani = new animatedTS(this);
            ani.ShowDialog();
            ani.Dispose();
        }

        private void tmButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            reusableTM reu = new reusableTM(this);
            reu.ShowDialog();
            reu.Dispose();
        }

        private void repointButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Repointer rep = new Repointer(this);
            rep.ShowDialog();
            rep.Dispose();
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            moveExtender mov = new moveExtender(this);
            mov.ShowDialog();
            mov.Dispose();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            about.Show();
        }
    }
}
