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

            // Инициализация на обектите
            ball = new Ball(PictureBoxBall);
            playerPlatform = PlayerPlatform;
            enemyPlatform = EnemyPlatform;

            this.KeyPreview = true;

            // Настройки на таймерите
            timer1.Interval = 20; // Около 50 кадъра в секунда
            timer1.Start();

            timerForReset.Interval = 3000; // 3 секунди пауза при победа/загуба
            timerForReset.Enabled = false;

            // Свързване на събитията (Events)
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.timerForReset.Tick += new System.EventHandler(this.timerForReset_Tick);
            this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);

            // Първоначално състояние на надписите
            lblPlaying.Visible = true;
            lblLoseWin.Visible = false;
        }

        // Основен гейм цикъл
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveAI();
            ball.Move();
            CheckCollisions();
        }

        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 15; // Малко по-бърза реакция на играча
            if (e.KeyCode == Keys.Up && playerPlatform.Top > 0)
                playerPlatform.Top -= speed;
            if (e.KeyCode == Keys.Down && playerPlatform.Bottom < this.ClientSize.Height)
                playerPlatform.Top += speed;
        }

        public void MoveAI()
        {
            // AI се движи само ако топката лети към него (наляво)
            if (ball.SpeedX < 0)
            {
                int speed = 6;
                int ballCenter = ball.Y + ball.Height / 2;
                int platformCenter = enemyPlatform.Top + enemyPlatform.Height / 2;

                // Малка грешка за по-реалистично поведение
                int error = random.Next(-15, 15);

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
            int maxPoints = 3;

            // Сблъсък с тавана и пода
            if (ball.Y <= 0 || ball.Y + ball.Height >= this.ClientSize.Height)
            {
                ball.ReverseY();
            }

            // Сблъсък с платформите (използваме Bounds на PictureBox)
            if (ball.Picture.Bounds.IntersectsWith(playerPlatform.Bounds) ||
                ball.Picture.Bounds.IntersectsWith(enemyPlatform.Bounds))
            {
                ball.ReverseX();
            }

            // Проверка за точка
            if (ball.X <= 0) // Топката излиза отляво (AI пропуска)
            {
                playerScore++;
                PlayerScore.Text = "Player: " + playerScore;
                CheckGameState(maxPoints);
            }
            else if (ball.X + ball.Width >= this.ClientSize.Width) // Излиза отдясно (Играч пропуска)
            {
                aiScore++;
                AIScore.Text = "AI: " + aiScore;
                CheckGameState(maxPoints);
            }
        }

        private void CheckGameState(int maxPoints)
        {
            if (playerScore >= maxPoints || aiScore >= maxPoints)
            {
                // КРАЙ НА ИГРАТА
                timer1.Stop();
                lblPlaying.Visible = false;
                lblLoseWin.Visible = true;

                if (playerScore >= maxPoints)
                {
                    lblLoseWin.Text = "YOU WIN!";
                    lblLoseWin.ForeColor = Color.Green;
                }
                else
                {
                    lblLoseWin.Text = "YOU LOSE!";
                    lblLoseWin.ForeColor = Color.Red;
                }

                timerForReset.Start(); // Пускаме брояча за рестарт
            }
            else
            {
                // ПРОДЪЛЖАВАМЕ - само центрираме топката
                ResetBall();
            }
        }

        private void ResetBall()
        {
            // Центрираме координатите спрямо ClientSize на формата
            int centerX = this.ClientSize.Width / 2 - ball.Width / 2;
            int centerY = this.ClientSize.Height / 2 - ball.Height / 2;

            ball.X = centerX;
            ball.Y = centerY;

            // Директно обновяваме PictureBox за моментна визуализация
            ball.Picture.Left = centerX;
            ball.Picture.Top = centerY;

            // Връщаме началната скорост (съобразено с твоя Ball.cs)
            ball.SpeedX = random.Next(0, 2) == 0 ? 5 : -5;
            ball.SpeedY = random.Next(0, 2) == 0 ? 5 : -5;
        }

        private void timerForReset_Tick(object sender, EventArgs e)
        {
            // Този код се изпълнява след 3 секунди пауза
            timerForReset.Stop();

            // Нулиране на резултата
            playerScore = 0;
            aiScore = 0;
            PlayerScore.Text = "Player: 0";
            AIScore.Text = "AI: 0";

            // Оправяне на надписите
            lblLoseWin.Visible = false;
            lblPlaying.Visible = true;

            // Рестарт на играта
            ResetBall();
            timer1.Start();
        }

        // Празни методи, които Visual Studio генерира автоматично (не ги трий, ако са свързани в Designer-а)
        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}