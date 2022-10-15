using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArcanoidNV
{
    public partial class MenuForm : Form
    {
        private Form1 infoForm;
        Bitmap but1,but2;

       

        public MenuForm()
        {
            InitializeComponent();
           
            but1 = new Bitmap(Properties.Resources.But1);
            but2 = new Bitmap(Properties.Resources.But2);
            
        }
        private void MenuForm_Paint(object sender, PaintEventArgs e)
        {
            var rect = new RectangleF(
                         label1.Location.X,
                         label1.Location.Y,
                         label1.Width,
                         label1.Height);

            LinearGradientBrush gradBrush;
            gradBrush = new  LinearGradientBrush(rect, Color.Yellow, Color.DarkRed, LinearGradientMode.Vertical);
            var g = e.Graphics;
            g.DrawString("Arcanoid", new Font("Pristina", 140, FontStyle.Regular),
                new SolidBrush(Color.White), label1.Location.X, label1.Location.Y);
            g.DrawString("Arcanoid", new Font("Pristina", 140, FontStyle.Regular), 
                gradBrush, label1.Location.X+5,label1.Location.Y);

        }

        private void butStart_Click(object sender, EventArgs e)
        {
            infoForm = new Form1();
           
            
            
        }
        private void butStart_MouseEnter(object sender, EventArgs e)
        {
            butStart.BackgroundImage = but2;
        } 
        private void butStart_MouseLeave(object sender, EventArgs e)
        {
            butStart.BackgroundImage = but1;
        }
        

        private void butSet_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке", "Разработчик", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void butSet_MouseEnter(object sender, EventArgs e)
        {
            butSet.BackgroundImage = but2;
        }

        private void butSet_MouseLeave(object sender, EventArgs e)
        {
            butSet.BackgroundImage = but1;
        }

        

        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butExit_MouseEnter(object sender, EventArgs e)
        {
            butExit.BackgroundImage = but2;
        }

        

        private void butExit_MouseLeave(object sender, EventArgs e)
        {
            butExit.BackgroundImage = but1;
        }
       


    }
}
