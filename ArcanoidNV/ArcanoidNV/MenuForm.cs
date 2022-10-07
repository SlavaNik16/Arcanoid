using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcanoidNV
{
    public partial class MenuForm : Form
    {
        private Bitmap ImageButStart, Oboi, scene, bitMap;
        private bool Ent = false;
        private Form1 infoForm;

        private Graphics gr,image;
        public MenuForm()
        {
            InitializeComponent();
            Oboi = new Bitmap(Properties.Resources.Oboi);
            scene = new Bitmap(Oboi,
                ClientRectangle.Width,
                ClientRectangle.Height);
            ImageButStart = new Bitmap(Properties.Resources.But1);
            bitMap = new Bitmap(ClientRectangle.Width,
                ClientRectangle.Height);
            gr = Graphics.FromImage(bitMap);
            StartBox.Image = ImageButStart;
            SettingBox.Image = ImageButStart;
            ExitBox.Image = ImageButStart;
            label1.Text = "Слава";
            label1.Parent = StartBox;
            infoForm = new Form1();
            infoForm.Condit = 0;
            StartBox.MouseEnter += StartBox_MouseEnter;
            StartBox.MouseLeave += StartBox_MouseLeave;
        }

        private void StartBox_MouseClick(object sender, MouseEventArgs e)
        {
            infoForm.Condit = 2;
            infoForm.Show(this);
        }

        private void StartBox_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void StartBox_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void MenuForm_Paint(object sender, PaintEventArgs e)
        {
           
            Draw();
        }
        public void Draw()
        {
            
            gr.DrawImage(scene, new Rectangle(0, 0,
                ClientRectangle.Width,
                ClientRectangle.Height));
           
            gr.DrawImage(ImageButStart, new Rectangle(
                    StartBox.Location.X,
                    StartBox.Location.Y,
                    StartBox.Width,
                    StartBox.Height));
                gr.DrawString($"Start", new Font("Times New Roman", 40, FontStyle.Regular), new SolidBrush(Color.White),
                  ClientRectangle.Width - ImageButStart.Width / 2 + 10,
                  ClientRectangle.Height - ImageButStart.Height * 3 + 60);

                gr.DrawImage(ImageButStart, new Rectangle(
                    SettingBox.Location.X,
                    SettingBox.Location.Y,
                    SettingBox.Width,
                    SettingBox.Height));
                gr.DrawString($"Setting", new Font("Times New Roman", 40, FontStyle.Regular), new SolidBrush(Color.White),
                  ClientRectangle.Width - ImageButStart.Width / 2 - 10,
                  ClientRectangle.Height - ImageButStart.Height * 2 + 40);

                gr.DrawImage(ImageButStart, new Rectangle(
                    ExitBox.Location.X,
                    ExitBox.Location.Y,
                    ExitBox.Width,
                    ExitBox.Height));
                gr.DrawString($"Exit", new Font("Times New Roman", 40, FontStyle.Regular), new SolidBrush(Color.White),
                  ClientRectangle.Width - ImageButStart.Width / 2 + 20,
                  ClientRectangle.Height - ImageButStart.Height + 35);
           
               

            var g = CreateGraphics();
           
            g.DrawImage(bitMap, 0, 0); 
           
            
        }
    }
}
