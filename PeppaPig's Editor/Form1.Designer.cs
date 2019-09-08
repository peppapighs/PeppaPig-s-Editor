namespace PeppaPig_s_Editor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.savingCheckBox = new System.Windows.Forms.CheckBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.romTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moveButton = new System.Windows.Forms.Button();
            this.repointButton = new System.Windows.Forms.Button();
            this.tmButton = new System.Windows.Forms.Button();
            this.aniButton = new System.Windows.Forms.Button();
            this.aboutButton = new System.Windows.Forms.Button();
            this.openRom = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PeppaPig_s_Editor.Properties.Resources.Banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(284, 86);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.savingCheckBox);
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Controls.Add(this.romTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Browse Rom";
            // 
            // savingCheckBox
            // 
            this.savingCheckBox.AutoSize = true;
            this.savingCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savingCheckBox.Location = new System.Drawing.Point(6, 46);
            this.savingCheckBox.Name = "savingCheckBox";
            this.savingCheckBox.Size = new System.Drawing.Size(108, 17);
            this.savingCheckBox.TabIndex = 3;
            this.savingCheckBox.Text = "Enable Saving";
            this.savingCheckBox.UseVisualStyleBackColor = true;
            this.savingCheckBox.CheckedChanged += new System.EventHandler(this.savingCheckBox_CheckedChanged);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(178, 18);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // romTextBox
            // 
            this.romTextBox.Location = new System.Drawing.Point(7, 20);
            this.romTextBox.Name = "romTextBox";
            this.romTextBox.ReadOnly = true;
            this.romTextBox.Size = new System.Drawing.Size(165, 20);
            this.romTextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.moveButton);
            this.groupBox2.Controls.Add(this.repointButton);
            this.groupBox2.Controls.Add(this.tmButton);
            this.groupBox2.Controls.Add(this.aniButton);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 139);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools";
            // 
            // moveButton
            // 
            this.moveButton.Location = new System.Drawing.Point(7, 110);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(247, 23);
            this.moveButton.TabIndex = 3;
            this.moveButton.Text = "Move Extender";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // repointButton
            // 
            this.repointButton.Location = new System.Drawing.Point(7, 80);
            this.repointButton.Name = "repointButton";
            this.repointButton.Size = new System.Drawing.Size(247, 23);
            this.repointButton.TabIndex = 2;
            this.repointButton.Text = "Rom Repointer";
            this.repointButton.UseVisualStyleBackColor = true;
            this.repointButton.Click += new System.EventHandler(this.repointButton_Click);
            // 
            // tmButton
            // 
            this.tmButton.Location = new System.Drawing.Point(7, 50);
            this.tmButton.Name = "tmButton";
            this.tmButton.Size = new System.Drawing.Size(247, 23);
            this.tmButton.TabIndex = 1;
            this.tmButton.Text = "Reusable TM";
            this.tmButton.UseVisualStyleBackColor = true;
            this.tmButton.Click += new System.EventHandler(this.tmButton_Click);
            // 
            // aniButton
            // 
            this.aniButton.Location = new System.Drawing.Point(7, 20);
            this.aniButton.Name = "aniButton";
            this.aniButton.Size = new System.Drawing.Size(247, 23);
            this.aniButton.TabIndex = 0;
            this.aniButton.Text = "Animated Titlescreen";
            this.aniButton.UseVisualStyleBackColor = true;
            this.aniButton.Click += new System.EventHandler(this.aniButton_Click);
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(12, 313);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(260, 38);
            this.aboutButton.TabIndex = 3;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // openRom
            // 
            this.openRom.Filter = "Fire Red Rom(*.gba)|*.gba";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 363);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "PeppaPig\'s Editor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox savingCheckBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox romTextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button repointButton;
        private System.Windows.Forms.Button tmButton;
        private System.Windows.Forms.Button aniButton;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.OpenFileDialog openRom;
    }
}

