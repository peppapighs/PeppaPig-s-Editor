namespace PeppaPig_s_Editor
{
    partial class reusableTM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reusableTM));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.unsellBox = new System.Windows.Forms.CheckBox();
            this.hideBox = new System.Windows.Forms.CheckBox();
            this.ungivableBox = new System.Windows.Forms.CheckBox();
            this.patchButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.unsellBox);
            this.groupBox1.Controls.Add(this.hideBox);
            this.groupBox1.Controls.Add(this.ungivableBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 90);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // unsellBox
            // 
            this.unsellBox.AutoSize = true;
            this.unsellBox.Location = new System.Drawing.Point(6, 67);
            this.unsellBox.Name = "unsellBox";
            this.unsellBox.Size = new System.Drawing.Size(143, 17);
            this.unsellBox.TabIndex = 2;
            this.unsellBox.Text = "Unsellable (TM01-TM50)";
            this.unsellBox.UseVisualStyleBackColor = true;
            // 
            // hideBox
            // 
            this.hideBox.AutoSize = true;
            this.hideBox.Location = new System.Drawing.Point(7, 44);
            this.hideBox.Name = "hideBox";
            this.hideBox.Size = new System.Drawing.Size(150, 17);
            this.hideBox.TabIndex = 1;
            this.hideBox.Text = "Hiding Quantities Showing";
            this.hideBox.UseVisualStyleBackColor = true;
            // 
            // ungivableBox
            // 
            this.ungivableBox.AutoSize = true;
            this.ungivableBox.Location = new System.Drawing.Point(7, 20);
            this.ungivableBox.Name = "ungivableBox";
            this.ungivableBox.Size = new System.Drawing.Size(74, 17);
            this.ungivableBox.TabIndex = 0;
            this.ungivableBox.Text = "Ungivable";
            this.ungivableBox.UseVisualStyleBackColor = true;
            // 
            // patchButton
            // 
            this.patchButton.Location = new System.Drawing.Point(12, 109);
            this.patchButton.Name = "patchButton";
            this.patchButton.Size = new System.Drawing.Size(260, 33);
            this.patchButton.TabIndex = 1;
            this.patchButton.Text = "Patch";
            this.patchButton.UseVisualStyleBackColor = true;
            this.patchButton.Click += new System.EventHandler(this.patchButton_Click);
            // 
            // reusableTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 154);
            this.Controls.Add(this.patchButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "reusableTM";
            this.Text = "Reusable TM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.reusableTM_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox unsellBox;
        private System.Windows.Forms.CheckBox hideBox;
        private System.Windows.Forms.CheckBox ungivableBox;
        private System.Windows.Forms.Button patchButton;
    }
}