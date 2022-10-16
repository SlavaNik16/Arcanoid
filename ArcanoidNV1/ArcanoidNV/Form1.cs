using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ArcanoidNV
{
    public partial class Form1 : Form
    {
        Bitmap scene, map, pl, bl;
        Bitmap wall0, wall1Pur, wall2Pur, wall3Pur, wall4Pur,
            wall1Yel, wall2Yel,wall3Yel,
            wall1Green, wall2Green,
            wall1Gray;
        public System.Drawing.Text.PrivateFontCollection f;
        Player player;
        Wall wall;
        Ball ball;
        public int Nrnd = 0;
        Timer timer;
        MenuForm menu;
        public Random rnd;

        private readonly List<Wall> walls;
        public Color color;
        double dx = 1,dy = -1, scout = 0, x=0;

        bool runnin = false;
        private Graphics buffer;
        Bitmap mainBitmap;

        public Form1()
        {
            InitializeComponent();
            menu = new MenuForm();
            rnd = new Random();
            InitImage();
            f = new System.Drawing.Text.PrivateFontCollection();
            f.AddFontFile("Font/Pixel1.ttf");

            color = new Color();

            player = new Player();
            player.X = ClientRectangle.Width / 2 - 100;
            player.Y = ClientRectangle.Height - 150;
            player.width = 250;
            player.height = 45;
            player.speed = 40;

            ball = new Ball();
            ball.X = ClientRectangle.Width / 2;
            ball.Y = ClientRectangle.Height / 2 ;
            ball.speedX = rnd.Next(0, 2) == 0 ? 20 : -20 ;
            ball.speedY = 20;
            ball.width = 30;
            ball.height = 30;


            wall = new Wall();
            wall.X = 100;
            wall.Y = 100;
            wall.width = 120;
            wall.height = 50;

            walls = new List<Wall>();
            AddWalls();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;

        }
        private void InitImage()
        {
            map = new Bitmap(Properties.Resources.map);
            
            scene = new Bitmap(map,
                     ClientRectangle.Width,
                     ClientRectangle.Height);
            pl = new Bitmap(Properties.Resources.player);
            bl = new Bitmap(Properties.Resources._ball);
            mainBitmap = new Bitmap(ClientRectangle.Width,
                                    ClientRectangle.Height);
            buffer = Graphics.FromImage(mainBitmap);

            wall0 = wall1Pur = new Bitmap(Properties.Resources.wall1);
            wall2Pur = new Bitmap(Properties.Resources.wall2);
            wall3Pur = new Bitmap(Properties.Resources.wall3);
            wall4Pur = new Bitmap(Properties.Resources.wall4);

            wall1Yel = new Bitmap(Properties.Resources.wall1Yel);
            wall2Yel = new Bitmap(Properties.Resources.wall2Yel);
            wall3Yel = new Bitmap(Properties.Resources.wall3Yel);

            wall1Green = new Bitmap(Properties.Resources.wall1Yel);
            wall2Green = new Bitmap(Properties.Resources.wall2Yel);

            wall1Gray = new Bitmap(Properties.Resources.wall1Gray);

        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
               runnin = false;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

           
            
            MovePlayer();
            

            if (ball.X < 0)
            {
                dx = -dx;
                
            }

            if (ball.Y < 0)
            {
                dy = -dy;
            }

            if (ball.X + ball.width > ClientRectangle.Width - 10)
            {
                dx = -dx;
            }

            if (ball.Y > ClientRectangle.Height - ball.height)
            {
               
                timer.Stop();
                Cursor.Show();
                MessageBox.Show($"Ваши очки: {scout.ToString()}", "Вы проиграли!", MessageBoxButtons.OK);
                runnin = false;
                
            } 
            ball.X += ball.speedX * dx;
            ball.Y += ball.speedY * dy;
            if (dy > 0)
            {                            
                if (player.Y - 2 <= ball.Y + ball.height  && player.Y + player.height / 2 + 2 >= ball.Y)
                {
                    if (player.X - 2 <= ball.X + ball.width && player.X + player.width + 2 >= ball.X)
                    {

                        dx = dx < 0 ? -1 : 1;

                        CollisionBallAndPlayer(ref dx, ref dy, ref ball, ref player);
                        
                       
                        if(player.Y - 2 <= ball.Y + ball.height && player.Y + player.height / 2 >= ball.Y)
                        {
                            if (
                            (ball.X + ball.width >= player.X - 2 &&
                            ball.X <= player.X + player.width / 12) ||
                            (ball.X <= player.X + player.width + 2 &&
                            ball.X + ball.width >= player.X + player.width - player.width / 12))
                            {
                                
                                dx *= rnd.Next(0,2)==0 ? 2 : 1.8;
                                
                            }
                            else if (
                            (ball.X + ball.width > player.X + player.width / 12 &&
                            ball.X <= player.X + player.width / 2.4) ||
                            (ball.X <= player.X + player.width - player.width / 6 &&
                            ball.X + ball.width >= player.X + player.width - player.width / 2.4))
                            {

                                dx *= rnd.Next(0, 2) == 0 ? 1.5 : 1.3;
                            }
                            else if (
                            (ball.X+ ball.width > player.X + player.width / 2.4 &&
                            ball.X < player.X + player.width - player.width / 2.4))
                            {

                                dx *= rnd.Next(0, 2) == 0 ? 0.09 : -0.09; ;
                            }

                        }
                        
                    }
                }
                
            }







            foreach (var wal in walls)
            {
                if(wal.Y - 2 <= ball.Y + ball.height && wal.Y + wall.height + 2 >= ball.Y)
                {
                    if(wal.X - 2 <= (ball.X) + ball.width && wal.X+wall.width + 2 >= ball.X)
                    {
                        wal.HP--;
                        dx = dx < 0 ? -1 : 1;
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
                MessageBox.Show($"Спасибо за игру!\nВы набрали {scout} счета!", "Вы ВЫИГРАЛИ!",
                MessageBoxButtons.OK); 
                runnin = false;
                
            }

            if (!runnin)
            {
                timer.Stop();
                Cursor.Show();
                menu.Show();
                this.Close();
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
            if (e.X > player.width / 2 + 10)
            {
                x = e.X;
            }
            else
            {
                x = player.width / 2 + 10;
            }
            if (e.X < ClientRectangle.Width - player.width /2+ 10)
            {
                x = e.X;
            }
            else
            {
                x = ClientRectangle.Width - player.width / 2 + 10;
            }


           
            if (player.X > ClientRectangle.Width - player.width)
            {
                    player.X = ClientRectangle.Width - player.width;
            }
            if (player.X <= 0)
            {
                    player.X = player.width /2;
            }
        }

        public void AddWalls()
        {
           
            for (int i = 1; i <= 6; i++)
            {
                Nrnd = rnd.Next(0, 12);
                if (Nrnd > 0)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        walls.Add(new Wall
                        {
                            X = j * (wall.width + 4) - wall.width + 10,
                            Y = i * (wall.height + 10) - 50,
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

            buffer.DrawImage(scene, new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height));
            buffer.DrawImage(pl, new Rectangle(
                player.X,
                player.Y,
                player.width,
                player.height));

            buffer.DrawImage(bl, new Rectangle(
                (int)ball.X,
                (int)ball.Y,
                ball.width,
                ball.height));
            foreach (var wal in walls)
            {
                switch (wal.type)
                {
                    case 0:
                        switch (wal.HP)
                        {
                            case 1:
                                wall0 = wall1Gray;
                                break;
                        }
                        break;
                    case 1:
                        switch (wal.HP)
                        {
                            case 1:
                                wall0 = wall1Green;
                                break;
                            case 2:
                                wall0 = wall2Green;
                                break;
                        }
                        break;
                    case 2:
                        switch (wal.HP)
                        {
                            case 1:
                                wall0 = wall1Yel;
                                break;
                            case 2:
                                wall0 = wall2Yel;
                                break;
                            case 3:
                                wall0 = wall3Yel;
                                break;
                        }
                        break;
                    case 3:
                        switch (wal.HP)
                        {
                            case 1:
                                wall0 = wall1Pur;
                                break;
                            case 2:
                                wall0 = wall2Pur;
                                break;
                            case 3:
                                wall0 = wall3Pur;
                                break;
                            case 4:
                                wall0 = wall4Pur;
                                break;
                        }
                        break;
                }


                buffer.DrawImage(wall0, new RectangleF(wal.X, wal.Y, wall.width, wall.height));
                buffer.DrawString($"Очки: {scout.ToString()}", new Font(f.Families[0], 24, FontStyle.Regular), new SolidBrush(Color.Orange),
                    ClientRectangle.Width - 170,
                    ClientRectangle.Height - 70);

            }
            var gr = this.CreateGraphics();
            gr.DrawImage(mainBitmap, 0, 0);

           
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            
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
   
            if (Math.Abs(delta_X - delta_Y) < 10)
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
            if (Math.Abs(delta_X - delta_Y) < 5)
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
