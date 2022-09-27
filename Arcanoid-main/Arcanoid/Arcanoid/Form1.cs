using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcanoid
{
    public partial class Form1 : Form
    {
        Bitmap scene;
        Bitmap map;
        Bitmap pl;
        Bitmap bl;
        Player player;
        Ball ball;
        int Condit = 0;
        Timer timer;
        public Form1()
        {
            InitializeComponent();

            map = new Bitmap(Properties.Resources.map);
            pl = new Bitmap(Properties.Resources.player);
            bl = new Bitmap(Properties.Resources._ball);
            
             

            player = new Player();
            player.X = Screen.PrimaryScreen.WorkingArea.Width / 2 - 100;
            player.Y = Screen.PrimaryScreen.WorkingArea.Height - 150;

            ball = new Ball();
            ball.X = Screen.PrimaryScreen.WorkingArea.Width / 2 - 20;
            ball.Y = Screen.PrimaryScreen.WorkingArea.Height - 170;
            ball.speedX = 30;
            ball.speedY = 30;
            ball.delta = 30;

            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {


            if (ball.Y >= player.Y - 20 && ball.Y <= player.Y + 5)
            {

                if (ball.X >= player.X + 50 && ball.X <= player.X + 120)
                {
                    ball.speedX = 0;
                    ball.speedY = -ball.delta;
                }
                else if (ball.X >= player.X && ball.X < player.X + 20)
                {
                    ball.speedX = -ball.delta - 10;
                    ball.speedY = -ball.delta;
                }
                else if (ball.X >= player.X + 20 && ball.X < player.X + 50)
                {
                    ball.speedX = -ball.delta - 20;
                    ball.speedY = -ball.delta;
                }
                else if (ball.X > player.X + 180 && ball.X <= player.X + 200)
                {
                    ball.speedX = ball.delta + 10;
                    ball.speedY = -ball.delta;
                }
                else if (ball.X > player.X + 120 && ball.X <= player.X + 180)
                {
                    ball.speedX = ball.delta + 20;
                    ball.speedY = -ball.delta;
                }
            }


            ball.X += ball.speedX;
            ball.Y += ball.speedY; 
            

            if (ball.X < 0)
            {
                ball.speedX = ball.delta;
            }

            if (ball.Y < 0)
            {
                ball.speedY = ball.delta;
            }

            if (ball.X > Screen.PrimaryScreen.WorkingArea.Width - 50)
            {
                ball.speedX = -ball.delta;
            }

            if (ball.Y > Screen.PrimaryScreen.WorkingArea.Height - 50)
            {
                ball.speedY = -ball.delta;
            }

          


            Draw();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Condit == 2)
            {
                player.X = e.X - 100;
                if (player.X > Screen.PrimaryScreen.WorkingArea.Width - 200)
                {
                    player.X = Screen.PrimaryScreen.WorkingArea.Width - 200;
                }
                if (player.X < 0)
                {
                    player.X = 0;
                }

            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }

        
        private void Draw()
        {
            try
            {
                scene = new Bitmap(map,
                     Screen.PrimaryScreen.WorkingArea.Width,
                     Screen.PrimaryScreen.WorkingArea.Height);
            }
            catch (OutOfMemoryException)
            {
                Environment.Exit(0);
            }

            Graphics gp = Graphics.FromImage(scene);
            gp.DrawImage(pl, new Rectangle(
                player.X,
                player.Y,
                200,
                60));
            Graphics gb = Graphics.FromImage(scene);
            gb.DrawImage(bl, new Rectangle(
                ball.X,
                ball.Y,
                40,
                40));

            var gr = this.CreateGraphics();
            gr.DrawImage(scene, 0, 0);
            
            long totalMemory = GC.GetTotalMemory(false);
            GC.Collect(0,GCCollectionMode.Forced); 
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Condit = 2;
            timer.Start();
        }

    }
}
