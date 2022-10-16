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
            this.butStart = new System.Windows.Forms.Button();
            this.butSet = new System.Windows.Forms.Button();
            this.butExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // butStart
            // 
            this.butStart.BackColor = System.Drawing.Color.Transparent;
            this.butStart.BackgroundImage = global::ArcanoidNV.Properties.Resources.But1;
            this.butStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butStart.FlatAppearance.BorderSize = 0;
            this.butStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butStart.Location = new System.Drawing.Point(229, 253);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(322, 72);
            this.butStart.TabIndex = 6;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = false;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            this.butStart.MouseEnter += new System.EventHandler(this.butStart_MouseEnter);
            this.butStart.MouseLeave += new System.EventHandler(this.butStart_MouseLeave);
            // 
            // butSet
            // 
            this.butSet.BackColor = System.Drawing.Color.Transparent;
            this.butSet.BackgroundImage = global::ArcanoidNV.Properties.Resources.But1;
            this.butSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butSet.FlatAppearance.BorderSize = 0;
            this.butSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butSet.Location = new System.Drawing.Point(229, 436);
            this.butSet.Name = "butSet";
            this.butSet.Size = new System.Drawing.Size(322, 72);
            this.butSet.TabIndex = 8;
            this.butSet.Text = "Setting";
            this.butSet.UseVisualStyleBackColor = false;
            this.butSet.Click += new System.EventHandler(this.butSet_Click);
            this.butSet.MouseEnter += new System.EventHandler(this.butSet_MouseEnter);
            this.butSet.MouseLeave += new System.EventHandler(this.butSet_MouseLeave);
            // 
            // butExit
            // 
            this.butExit.BackColor = System.Drawing.Color.Transparent;
            this.butExit.BackgroundImage = global::ArcanoidNV.Properties.Resources.But1;
            this.butExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butExit.FlatAppearance.BorderSize = 0;
            this.butExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.butExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.butExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butExit.Location = new System.Drawing.Point(229, 630);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(322, 72);
            this.butExit.TabIndex = 9;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = false;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            this.butExit.MouseEnter += new System.EventHandler(this.butExit_MouseEnter);
            this.butExit.MouseLeave += new System.EventHandler(this.butExit_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Pristina", 140.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(58, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 244);
            this.label1.TabIndex = 10;
            this.label1.Text = " ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(557, 253);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(203, 442);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Когда нажмете на кнопку Start\r\nвы начнете игру!\r\n\r\nНажмите на кнопку мыши, чтобы " +
    "\r\nзапустить мячик!\r\n\r\nЧтобы выйти из игры нажмите \r\nкнопку Esc!\r\n\r\nПриятной игры" +
    "!!!";
            this.textBox1.Visible = false;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::ArcanoidNV.Properties.Resources.Oboi;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(769, 800);
            this.ControlBox = false;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.butSet);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximumSize = new System.Drawing.Size(789, 843);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(789, 843);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MenuForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butSet;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
    }
}