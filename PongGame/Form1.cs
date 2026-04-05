using System;
using System.Drawing;
using System.Windows.Forms;
using Ping_pong.Models;

namespace Ping_pong
{
    public partial class Form1 : Form
    {
        Ball ball;
        bool start = true;
        int seconds = 650;
        int time = 20;
        int sumTime;
        int playerScore = 0;
        int aiScore = 0;
        Panel playerPlatform;
        Panel enemyPlatform;
        Random random = new Random();
        bool gameOver = false;
        int maxScore = 5;

        bool moveUp = false;
        bool moveDown = false;
        int aiDelayCounter = 0;

        public Form1()
        {
            InitializeComponent();

            ball = new Ball(PictureBoxBall);
            playerPlatform = PlayerPlatform;
            enemyPlatform = EnemyPlatform;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            timer1.Tick += Timer1_Tick;
            timer1.Interval = 20;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (gameOver) return;

            int speed = 12;
            if (moveUp && playerPlatform.Top > 0)
                playerPlatform.Top -= speed;
            if (moveDown && playerPlatform.Bottom < this.ClientSize.Height)
                playerPlatform.Top += speed;

            MoveAI();
            ball.Move();
            CheckCollisions();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                moveUp = true;
            if (e.KeyCode == Keys.Down)
                moveDown = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                moveUp = false;
            if (e.KeyCode == Keys.Down)
                moveDown = false;
        }

        private void MoveAI()
        {
            aiDelayCounter++;
            if (aiDelayCounter % 2 != 0) return;

            if (ball.SpeedX < 0)
            {
                if (seconds > sumTime)
                {
                    sumTime += time;
                    return;
                }

                int speed = random.Next(3, 6);
                int ballCenter = ball.Y + ball.Height / 2;
                int platformCenter = enemyPlatform.Top + enemyPlatform.Height / 2;
                int error = random.Next(-40, 40);

                if (ballCenter + error < platformCenter && enemyPlatform.Top > 0)
                    enemyPlatform.Top -= speed;
                else if (ballCenter + error > platformCenter && enemyPlatform.Bottom < this.ClientSize.Height)
                    enemyPlatform.Top += speed;
            }
        }

        private void CheckCollisions()
        {
            if (ball.Y <= 0 || ball.Y + ball.Height >= this.ClientSize.Height)
                ball.ReverseY();

            if (ball.Picture.Bounds.IntersectsWith(playerPlatform.Bounds) ||
                ball.Picture.Bounds.IntersectsWith(enemyPlatform.Bounds))
            {
                ball.ReverseX();
                sumTime = 0;
            }

            if (ball.X <= 0)
            {
                playerScore++;
                PlayerScore.Text = "Player: " + playerScore;
                ResetBall();
                CheckGameOver();
                return;
            }
            else if (ball.X + ball.Width >= this.ClientSize.Width)
            {
                aiScore++;
                AIScore.Text = "AI: " + aiScore;
                ResetBall();
                CheckGameOver();
                return;
            }
        }

        private void CheckGameOver()
        {
            if (playerScore >= maxScore)
            {
                gameOver = true;
                MessageBox.Show("Player Wins!");
                ResetGame();
            }
            else if (aiScore >= maxScore)
            {
                gameOver = true;
                MessageBox.Show("AI Wins!");
                ResetGame();
            }
        }

        private void ResetBall()
        {
            ball.X = this.ClientSize.Width / 2 - ball.Width / 2;
            ball.Y = this.ClientSize.Height / 2 - ball.Height / 2;
            ball.SpeedX = random.Next(0, 2) == 0 ? 5 : -5;
            ball.SpeedY = random.Next(-3, 3);
        }

        private void ResetGame()
        {
            playerScore = 0;
            aiScore = 0;
            PlayerScore.Text = "Player: 0";
            AIScore.Text = "AI: 0";
            ResetBall();
            gameOver = false;
        }
    }
}