using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private PictureBox fruit;
        private PictureBox[] Snake;
        private bool play;
        private bool start;
        private bool firstlaunch;
        private int step = 10;
        private int updateinterval = 100;
        private int score = 0;
        public struct Vector
        {
            public int x, y;
        }

        Vector direction; //направление
        Vector positionfruct;//позиция фрукта
        Vector gamearrea;//игровая зона
        public Form1()
        {
            InitializeComponent();
            gamearrea.x = 500;
            gamearrea.y = 400;
            firstlaunch = true;
            new_game();
        }
        public void new_game()
        {
            if (firstlaunch == true)
            {
                //инициализируем и добавляем голову
                Snake = new PictureBox[400];
                Snake[0] = new PictureBox();
                Snake[0].Location = new Point(250, 200);
                Snake[0].BackColor = Color.Red;
                Snake[0].Width = step;
                Snake[0].Height = step;
                score = 0;
                this.Controls.Add(Snake[0]);//Добавляем голову

                //Добавляем фрукт
                fruit = new PictureBox();
                fruit.BackColor = Color.Green;
                fruit.Width = step;
                fruit.Height = step;
                generet_position_fruict();

                timer1.Interval = updateinterval;
                play = true;
                start = true;
                label.Text = "Счет: " + score;
                firstlaunch = false;
                direction.x = 1;
                direction.y = 0;
                timer1.Start();
            }
            else
            {
                Random rnd = new Random();
                this.Controls.Remove(fruit);
                generet_position_fruict();
                for (int i = 0; i <= score; i++)
                {
                    this.Controls.Remove(Snake[i]);
                }
                Snake[0].Location = new Point(rnd.Next(2,30)*10, rnd.Next(10,40)*10);
                this.Controls.Add(Snake[0]);
                score = 0;
                label.Text = "Счет: " + score;
                direction.x = 1;
                direction.y = 0;
                timer1.Start();
                play = true;
            }
        }
        public void generet_position_fruict()
        {
            Random rnd = new Random();
            positionfruct.x = rnd.Next(20, gamearrea.x);
            positionfruct.y = rnd.Next(100, gamearrea.y);
            int tempX = positionfruct.x % step;//помещаем фрукт в клеточку
            positionfruct.x -= tempX;
            int tempY = positionfruct.y % step;
            positionfruct.y -= tempY;
            for (int i = 0; i < score; i++)
            {
                if (positionfruct.x == Snake[i].Location.X && positionfruct.y == Snake[i].Location.Y)
                {
                    generet_position_fruict();
                }
            }
            fruit.Location = new Point(positionfruct.x, positionfruct.y);//задаем новую позицию фрукту
            this.Controls.Add(fruit);//Добавляем фрукт
        }
        public void cheak_Snake_eat_fruict()
        {
            if (positionfruct.x == Snake[0].Location.X && positionfruct.y == Snake[0].Location.Y)
            {
                score++;
                label.Text = "Счет: " + score;
                generet_position_fruict();
                Snake[score] = new PictureBox();
                Snake[score].Location = new Point(Snake[score - 1].Location.X + step*direction.x,
                    Snake[score - 1].Location.Y + step * direction.y);
                Snake[score].BackColor = Color.Blue;
                Snake[score].Width = step;
                Snake[score].Height = step;
                this.Controls.Add(Snake[score]);
            }
        }
        public void move_sneak()
        {
            for (int i = score; i >= 1; i--)
            {
                Snake[i].Location = Snake[i - 1].Location;
            }
            Snake[0].Location = new Point(Snake[0].Location.X + direction.x*step, Snake[0].Location.Y + direction.y * step);
            //Предыдущее значение змейки + направление * на шаг
        }
        public void snake_eat_yourself()
        {
            for (int i = 1; i < score; i++)
            {
                if (Snake[0].Location == Snake[i].Location)
                {
                    play = false;
                }
            }
        }
        public void snake_crashes_on_wall()
        {
            if (Snake[0].Location.X == 0)
            {
                play = false;
            }
            if (Snake[0].Location.X == 500)
            {
                play = false;
            }
            if (Snake[0].Location.Y == 60)
            {
                play = false;
            }
            if (Snake[0].Location.Y == 400)
            {
                play = false;
            }
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (start == true)
            {
                timer1.Stop();
                start = false;
            }
            else
            {
                timer1.Start();
                start = true;
            }
        }
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Кушай фрукты, расти и ставь новые рекорды. Игра разработана di","Правила и авторы");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Right")
            {
                direction.y = 0;
                direction.x = 1;
            }
            if (e.KeyCode.ToString() == "Up")
            {
                direction.y = -1;
                direction.x = 0;
            }
            if (e.KeyCode.ToString() == "Left")
            {
                direction.y = 0;
                direction.x = -1;
            }
            if (e.KeyCode.ToString() == "Down")
            {
                direction.y = 1;
                direction.x = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (play == true)
            {
                move_sneak();
                cheak_Snake_eat_fruict();
                snake_eat_yourself();
                snake_crashes_on_wall();
                groupBox2.Visible = false;
            }
            else
            {
                timer1.Stop();
                groupBox2.Visible = true;
            }        
        }
        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_game();
        }
    }
}