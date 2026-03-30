using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ping_pong.Models;

namespace Ping_pong
{
    public partial class Form1 : Form
    {
        Ball ball;
        int playerScore = 0;
        int aiScore = 0;
        Panel playerPlatform;
        Panel enemyPlatform;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            ball = new Ball(PictureBoxBall);
            playerPlatform = PlayerPlatform;
            enemyPlatform = EnemyPlatform;
            this.KeyPreview = true;
            timer1.Start();
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
        }
        //game loop
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveAI();
            ball.Move();
            CheckCollisions();
        }
        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 10;
            if (e.KeyCode == Keys.Up && playerPlatform.Top > 0)
                playerPlatform.Top -= speed;
            if (e.KeyCode == Keys.Down && playerPlatform.Bottom < this.ClientSize.Height)
                playerPlatform.Top += speed;
        }
        public void MoveAI()
        {
            if (ball.SpeedX < 0)
            {
                int speed = 5;
                int ballCenter = ball.Y + ball.Height / 2;
                int platformCenter = enemyPlatform.Top + enemyPlatform.Height / 2;
                int error = random.Next(-10, 10);
                if (ballCenter + error < platformCenter && enemyPlatform.Top > 0)
                {
                    enemyPlatform.Top -= speed;
                }
                else if (ballCenter + error > platformCenter && enemyPlatform.Bottom < this.ClientSize.Height)
                {
                    enemyPlatform.Top += speed;
                }
            }
        }
        public void CheckCollisions()
        {
            if (ball.Y <= 0 || ball.Y + ball.Height >= this.ClientSize.Height)
                ball.ReverseY();
            if (ball.Picture.Bounds.IntersectsWith(playerPlatform.Bounds) ||
                    ball.Picture.Bounds.IntersectsWith(enemyPlatform.Bounds))
                ball.ReverseX();
            if (ball.X <= 0)
            {
                playerScore++;
                PlayerScore.Text = "Player" + playerScore;
                ResetBall();
            }
            else if (ball.X + ball.Width >= this.ClientSize.Width)
            {
                aiScore++;
                AIScore.Text = "Ai"+aiScore;
                ResetBall();
            }
        }
        private void ResetBall()
        {
            ball.X = this.ClientSize.Width / 2 - ball.Width / 2;
            ball.Y = this.ClientSize.Height / 2 - ball.Height / 2;
            ball.SpeedX = random.Next(0, 2) == 0 ? 5 : -5; // Randomize initial direction
        }
    }
}
