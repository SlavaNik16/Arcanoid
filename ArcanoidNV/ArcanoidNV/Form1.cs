using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArcanoidNV
{
    public partial class Form1 : Form
    {
        Bitmap scene;
        Bitmap map;
        Bitmap pl;
        Bitmap bl;
        Player player;
        Wall wall;
        Ball ball;
        int Condit = 0;
        Timer timer;
        private readonly List<Wall> walls;
        public Color color;
        int dx = 1;
        int dy = -1;
        public Form1()
        {
            InitializeComponent();

            map = new Bitmap(Properties.Resources.map);
            pl = new Bitmap(Properties.Resources.player);
            bl = new Bitmap(Properties.Resources._ball);

            color = new Color();

            player = new Player();
            player.X = Screen.PrimaryScreen.WorkingArea.Width / 2 - 100;
            player.Y = Screen.PrimaryScreen.WorkingArea.Height - 150;
            player.width = 300;
            player.height = 60;

            ball = new Ball();
            ball.X = Screen.PrimaryScreen.WorkingArea.Width / 2;
            ball.Y = Screen.PrimaryScreen.WorkingArea.Height /2 ;
            ball.speedX = 20;
            ball.speedY = 20;
            ball.width = 40;
            ball.height = 40;


            wall = new Wall();
            wall.X = 100;
            wall.Y = 100;
            wall.width = 150;
            wall.height = 60;

            walls = new List<Wall>();
            AddWalls();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {


            


          
            ball.X += ball.speedX * dx;
            ball.Y += ball.speedY * dy;

           if (ball.X < 0)
            {
                dx = -dx;
            }

            if (ball.Y < 0)
            {
                dy = -dy;
            }

            if (ball.X > Screen.PrimaryScreen.WorkingArea.Width - 50)
            {
                dx = -dx;
            }

            if (ball.Y > Screen.PrimaryScreen.WorkingArea.Height - 50)
            {
                Environment.Exit(0);
            }
            if (dy > 0)
            {
                if (ball.Y + ball.height >= player.Y && ball.Y + ball.height <= player.Y + player.height / 2)
                {
                    if (ball.X + ball.width >= player.X && ball.X <= player.X + player.width)
                    {
                        CollisionBallAndPlayer(ref dx, ref dy, ref ball, ref player);
                    }
                }
            }







            foreach (var wal in walls)
            {
                if (ball.Y < wal.Y + wall.height && ball.Y > wal.Y)
                {
                    if (ball.X >= wal.X && ball.X <= wal.X + wall.width && dy < 0)
                    {
       
                        wal.HP--;

                        CollisionBallAndWall(ref dx, ref dy, ref ball, wall,wal);
                        if (wal.HP == 0)
                        {
                            walls.Remove(wal);
                        }
                        break;
                    }
                    else if (ball.X + ball.width >= wal.X && ball.X <= wal.X + wall.width && dy > 0)
                    {
                       
                        wal.HP--;
                        CollisionBallAndWall(ref dx, ref dy, ref ball, wall, wal);
                        if (wal.HP == 0)
                        {
                            walls.Remove(wal);
                        }
                        break;
                    }
                }
               
            }



            Draw();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Condit == 2)
            {
                player.X = e.X - player.width /2;
                if (player.X > Screen.PrimaryScreen.WorkingArea.Width - player.width)
                {
                    player.X = Screen.PrimaryScreen.WorkingArea.Width - player.width;
                }
                if (player.X < 0)
                {
                    player.X = 0;
                }

            }
        }

        public void AddWalls()
        {
            
            var rnd = new Random();
            for (int i = 60; i < Screen.PrimaryScreen.WorkingArea.Height / 2 - 200; i += wall.height)
            {
                for(int j = 50; j < Screen.PrimaryScreen.WorkingArea.Width - 150; j += wall.width)
                {
                    walls.Add(new Wall
                    {
                        X = j,
                        Y = i,
                        HP = 1,
                        type = rnd.Next(0, 4),
                    });          
                }
            }
            foreach (var wal in walls)
            {
                wal.HP = wal.type + 1;
                
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
                player.width,
                player.height));
            Graphics gb = Graphics.FromImage(scene);
            gb.DrawImage(bl, new Rectangle(
                ball.X,
                ball.Y,
                ball.width,
                ball.height));
            foreach (var wal in walls)
            {
                color = wal.type == 0 ? Color.Gray : (wal.type == 1) ? Color.Green : (wal.type == 2) ? Color.Orange : Color.Red;
                Graphics gw = Graphics.FromImage(scene);
                gw.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(wal.X, wal.Y, 150, 60));
                gw.FillRectangle(new SolidBrush(color), new RectangleF(wal.X, wal.Y, 150, 60));
                gw.DrawString(wal.HP.ToString(), new Font("Times New Roman", 24, FontStyle.Regular), new SolidBrush(Color.Black), wal.X + wal.width / 2 ,wal.Y + wal.height / 2);
             
            }
            var gr = this.CreateGraphics();
            gr.DrawImage(scene, 0, 0);

           
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Condit = 2;
            timer.Start();
            Cursor.Hide();
            long totalMemory = GC.GetTotalMemory(false);
            GC.Collect(0, GCCollectionMode.Forced);

        }

        private void CollisionBallAndPlayer(ref int dx, ref int dy, ref Ball ball, ref Player player)
        {
            double delta_X = 0,delta_Y = 0;

            if (dx > 0) 
            { 
                delta_X = (ball.X + ball.width) - (player.X);
            }
            else if (dx < 0)
            {
                delta_X = (player.X + player.width) - (ball.X);
            }
            if (dy > 0)
            {
                delta_Y = (ball.Y + ball.height) - (player.Y);
            }
            else if(dy < 0)
            {
                delta_Y = (player.Y + player.height) - (ball.Y);
            }
            if (Math.Abs(delta_X - delta_Y) < 20)
            {
                dx = -dx;
                dy = -dy;
            }
            else if (delta_X > delta_Y)
            {
                dy = -dy;
            }
            else if (delta_Y > delta_X)
            {
                dx = -dx;
            }
            
        }
        private void CollisionBallAndWall(ref int dx, ref int dy, ref Ball ball,  Wall wall,Wall wals)
        {
            double delta_X = 0, delta_Y = 0;

            if (dx > 0)
            {
                delta_X = (ball.X + ball.width) - (wals.X);
            }
            else if (dx < 0)
            {
                delta_X = (wals.X + wall.width) - (ball.X);
            }
            if (dy > 0)
            {
                delta_Y = (ball.Y + ball.height) - (wals.Y);
            }
            else if (dy < 0)
            {
                delta_Y = (wals.Y + wall.height) - (ball.Y);
            }
            if (Math.Abs(delta_X - delta_Y) < 15)
            {
                dx = -dx;
                dy = -dy;
            }
            else if (delta_X > delta_Y)
            {
                dy = -dy;
            }
            else if (delta_Y > delta_X)
            {
                dx = -dx;
            }

        }

    }
}
