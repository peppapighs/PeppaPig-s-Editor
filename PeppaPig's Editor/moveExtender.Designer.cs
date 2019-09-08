namespace PeppaPig_s_Editor
{
    partial class moveExtender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(moveExtender));
            this.moveNumberNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.findButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.animationBox = new System.Windows.Forms.TextBox();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.attackDataBox = new System.Windows.Forms.TextBox();
            this.attackNamesBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.repointButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.moveNumberNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // moveNumberNumeric
            // 
            this.moveNumberNumeric.Location = new System.Drawing.Point(145, 7);
            this.moveNumberNumeric.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.moveNumberNumeric.Minimum = new decimal(new int[] {
            355,
            0,
            0,
            0});
            this.moveNumberNumeric.Name = "moveNumberNumeric";
            this.moveNumberNumeric.Size = new System.Drawing.Size(127, 20);
            this.moveNumberNumeric.TabIndex = 0;
            this.moveNumberNumeric.Value = new decimal(new int[] {
            355,
            0,
            0,
            0});
            this.moveNumberNumeric.ValueChanged += new System.EventHandler(this.moveNumberNumeric_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total Number of Moves : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.findButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.animationBox);
            this.groupBox1.Controls.Add(this.descriptionBox);
            this.groupBox1.Controls.Add(this.attackDataBox);
            this.groupBox1.Controls.Add(this.attackNamesBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(13, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Repoint Offset";
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(6, 136);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(247, 23);
            this.findButton.TabIndex = 9;
            this.findButton.Text = "Find Free Space";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(49, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "*Leave blank if you do not want to repoint";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Animations : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descriptions : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Attack Data : ";
            // 
            // animationBox
            // 
            this.animationBox.Location = new System.Drawing.Point(95, 97);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(158, 20);
            this.animationBox.TabIndex = 4;
            // 
            // descriptionBox
            // 
            this.descriptionBox.Location = new System.Drawing.Point(95, 71);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(158, 20);
            this.descriptionBox.TabIndex = 3;
            // 
            // attackDataBox
            // 
            this.attackDataBox.Location = new System.Drawing.Point(95, 45);
            this.attackDataBox.Name = "attackDataBox";
            this.attackDataBox.Size = new System.Drawing.Size(158, 20);
            this.attackDataBox.TabIndex = 2;
            // 
            // attackNamesBox
            // 
            this.attackNamesBox.Location = new System.Drawing.Point(95, 19);
            this.attackNamesBox.Name = "attackNamesBox";
            this.attackNamesBox.Size = new System.Drawing.Size(158, 20);
            this.attackNamesBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Attack Names : ";
            // 
            // repointButton
            // 
            this.repointButton.Location = new System.Drawing.Point(13, 198);
            this.repointButton.Name = "repointButton";
            this.repointButton.Size = new System.Drawing.Size(259, 29);
            this.repointButton.TabIndex = 3;
            this.repointButton.Text = "Repoint";
            this.repointButton.UseVisualStyleBackColor = true;
            this.repointButton.Click += new System.EventHandler(this.repointButton_Click);
            // 
            // moveExtender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 239);
            this.Controls.Add(this.repointButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveNumberNumeric);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "moveExtender";
            this.Text = "Move Extender";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.moveExtender_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.moveNumberNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown moveNumberNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox animationBox;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.TextBox attackDataBox;
        private System.Windows.Forms.TextBox attackNamesBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button repointButton;
    }
}