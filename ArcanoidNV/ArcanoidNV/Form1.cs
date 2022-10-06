using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArcanoidNV
{
    public partial class Form1 : Form
    {
        Bitmap scene,map,pl,bl;
        Player player;
        Wall wall;
        Ball ball;
        int Condit = 0, Nrnd = 0;
        Timer timer;
        private readonly List<Wall> walls;
        public Color color;
        double dx = 1,dy = -1, scout = 0, x=0;
        bool runnin = false;
        private Graphics buffer;
        Bitmap mainBitmap;

        public Form1()
        {
            InitializeComponent();

            map = new Bitmap(Properties.Resources.map);
            scene = new Bitmap(map,
                     Screen.PrimaryScreen.WorkingArea.Width,
                     Screen.PrimaryScreen.WorkingArea.Height);
            pl = new Bitmap(Properties.Resources.player);
            bl = new Bitmap(Properties.Resources._ball);
            mainBitmap = new Bitmap(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            buffer = Graphics.FromImage(mainBitmap);

            color = new Color();

            player = new Player();
            player.X = Screen.PrimaryScreen.WorkingArea.Width / 2 - 100;
            player.Y = Screen.PrimaryScreen.WorkingArea.Height - 150;
            player.width = 300;
            player.height = 60;
            player.speed = 40;

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
            MovePlayer();
            

            if (ball.X < 10)
            {
                dx = -dx;
            }

            if (ball.Y < 0)
            {
                dy = -dy;
            }

            if (ball.X > Screen.PrimaryScreen.WorkingArea.Width - 80)
            {
                dx = -dx;
            }

            if (ball.Y > Screen.PrimaryScreen.WorkingArea.Height - 60)
            {
               
                timer.Stop();
                Cursor.Show();
                if (MessageBox.Show("Хотите начать с начала!","Вы проиграли!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    runnin = false;
                }
                
            }
            if (dy > 0)
            {                             //25 100 50 100 25
                if (player.Y - 2 <= ball.Y + ball.height  && player.Y + player.height + 2 >= ball.Y)
                {
                    if (player.X - 2 <= ball.X + ball.width && player.X + player.width + 2 >= ball.X)
                    {
                        
                        dx = dx < 0 ? -1: 1;

                        CollisionBallAndPlayer(ref dx, ref dy, ref ball, ref player);
                        if(player.Y - 2 <= ball.Y + ball.height && player.Y + player.height / 2 >= ball.Y)
                        {
                            if (
                            (ball.X + ball.width >= player.X - 2 &&
                            ball.X <= player.X + player.width / 12) ||
                            (ball.X <= player.X + player.width + 2 &&
                            ball.X + ball.width >= player.X + player.width - player.width / 12))
                            {

                                dx *= 2;
                                
                            }
                            else if (
                            (ball.X + ball.width > player.X + player.width / 12 &&
                            ball.X <= player.X + player.width / 2.4) ||
                            (ball.X <= player.X + player.width - player.width / 6 &&
                            ball.X + ball.width >= player.X + player.width - player.width / 2.4))
                            {

                                dx *= 1.5;
                            }
                            else if (
                            (ball.X+ ball.width > player.X + player.width / 2.4 &&
                            ball.X < player.X + player.width - player.width / 2.4))
                            {

                                dx *= 0.09;
                            }

                        }
                        
                    }
                }
                
            }







            foreach (var wal in walls)
            {
                if(wal.Y - 2 <= ball.Y + ball.height && wal.Y + wall.height + 2 >= ball.Y)
                {
                    if(wal.X - 2 <= ball.X + ball.width && wal.X+wall.width + 2 >= ball.X)
                    {
                        wal.HP--;

                        CollisionBallAndWall(ref dx, ref dy, ref ball, wall, wal);
                        if (wal.HP == 0)
                        {
                            scout += wal.scout;
                            walls.Remove(wal);
                        }
                        break;
                    }
                }
               
               
            }
            



            Draw();
            if (walls.Count == 0)
            {
                timer.Stop();
                Cursor.Show();
                if (MessageBox.Show($"Спасибо за игру!\nВы набрали {scout} счета!", "Вы ВЫИГРАЛИ!", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    Application.Restart();
                }
                else
                {
                    runnin = false;
                }
            }
            if (!runnin)
            {
                Close();
            }
        }
        private void MovePlayer()
        {
            if ((x - player.width / 2) - player.X > -player.speed &&
                (x - player.width / 2) - player.X < player.speed)
            {
                player.X += 0;
            }
            else if ((x - player.width / 2) - player.X <= -player.speed && player.X > player.speed)
            {
                player.X += -player.speed;
            }
            else if ((x - player.width / 2) - player.X >= player.speed)
            {
                player.X += player.speed;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= player.width / 2)
            {
                x = e.X;
            }
            else
            {
                x = 0;
            }
            if (e.X < Screen.PrimaryScreen.WorkingArea.Width - player.width /2)
            {
                x = e.X;
            }
            else
            {
                x = Screen.PrimaryScreen.WorkingArea.Width - player.width / 2;
            }


            if (Condit == 2)
            {
                if (player.X > Screen.PrimaryScreen.WorkingArea.Width - player.width)
                {
                    player.X = Screen.PrimaryScreen.WorkingArea.Width - player.width;
                }
                if (player.X <= 0)
                {
                    player.X = player.width /2;
                }

            }
        }

        public void AddWalls()
        {
            
            var rnd = new Random();
            for (int i = 1; i <= 6; i++)
            {
                Nrnd = rnd.Next(0, 12);
                if (Nrnd > 0)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        walls.Add(new Wall
                        {
                            X = j * (wall.width + 4) - wall.width + 40,
                            Y = i * (wall.height + 4) - 30,
                            HP = 1,
                            type = rnd.Next(0, 4),
                            scout = 0,

                        });
                    }
                }
               
            }
            foreach (var wal in walls)
            {
                wal.HP = wal.type + 1;
                wal.scout = Math.Pow(wal.HP, 2);
                
            }
        }

       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }


        private void Draw()
        {

            buffer.DrawImage(scene, new Rectangle(0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height));
            buffer.DrawImage(pl, new Rectangle(
                player.X,
                player.Y,
                player.width,
                player.height));
            //Graphics gb = Graphics.FromImage(gp);
            buffer.DrawImage(bl, new Rectangle(
                (int)ball.X,
                (int)ball.Y,
                ball.width,
                ball.height));
            foreach (var wal in walls)
            {
                color = wal.type == 0 ? Color.Gray : (wal.type == 1) ? Color.Green : (wal.type == 2) ? Color.Orange : Color.Red;
               
                buffer.DrawRectangle(new Pen(Color.Black, 3), new Rectangle(wal.X, wal.Y, 150, 60));
                buffer.FillRectangle(new SolidBrush(color), new RectangleF(wal.X, wal.Y, 150, 60));
                buffer.DrawString(wal.HP.ToString(), new Font("Times New Roman", 24, FontStyle.Regular), new SolidBrush(Color.Black),wal.X + wall.width / 2 -20 , wal.Y + wall.height/2 -20);
                buffer.DrawString($"Очки: {scout.ToString()}", new Font("Times New Roman", 24, FontStyle.Regular), new SolidBrush(Color.Orange), 
                    Screen.PrimaryScreen.WorkingArea.Width - 170, 
                    Screen.PrimaryScreen.WorkingArea.Height - 70);

            }
            var gr = this.CreateGraphics();
            gr.DrawImage(mainBitmap, 0, 0);

           
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Condit = 2;
            runnin = true;
            timer.Start();
            Cursor.Hide();
          

        }

        private void CollisionBallAndPlayer(ref double dx, ref double dy, ref Ball ball, ref Player player)
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
        private void CollisionBallAndWall(ref double dx, ref double dy, ref Ball ball,  Wall wall,Wall wals)
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
