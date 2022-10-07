namespace ArcanoidNV
{
    partial class MenuForm
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
            this.StartBox = new System.Windows.Forms.PictureBox();
            this.SettingBox = new System.Windows.Forms.PictureBox();
            this.ExitBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.StartBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBox)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBox
            // 
            this.StartBox.BackColor = System.Drawing.Color.Black;
            this.StartBox.InitialImage = null;
            this.StartBox.Location = new System.Drawing.Point(229, 253);
            this.StartBox.Name = "StartBox";
            this.StartBox.Size = new System.Drawing.Size(322, 75);
            this.StartBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StartBox.TabIndex = 1;
            this.StartBox.TabStop = false;
            this.StartBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StartBox_MouseClick);
            // 
            // SettingBox
            // 
            this.SettingBox.BackColor = System.Drawing.Color.Black;
            this.SettingBox.InitialImage = null;
            this.SettingBox.Location = new System.Drawing.Point(229, 436);
            this.SettingBox.Name = "SettingBox";
            this.SettingBox.Size = new System.Drawing.Size(322, 75);
            this.SettingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingBox.TabIndex = 2;
            this.SettingBox.TabStop = false;
            this.SettingBox.Visible = false;
            // 
            // ExitBox
            // 
            this.ExitBox.BackColor = System.Drawing.Color.Black;
            this.ExitBox.InitialImage = null;
            this.ExitBox.Location = new System.Drawing.Point(229, 630);
            this.ExitBox.Name = "ExitBox";
            this.ExitBox.Size = new System.Drawing.Size(322, 75);
            this.ExitBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ExitBox.TabIndex = 3;
            this.ExitBox.TabStop = false;
            this.ExitBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(769, 800);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExitBox);
            this.Controls.Add(this.SettingBox);
            this.Controls.Add(this.StartBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.StartBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExitBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox StartBox;
        private System.Windows.Forms.PictureBox SettingBox;
        private System.Windows.Forms.PictureBox ExitBox;
        private System.Windows.Forms.Label label1;
    }
}