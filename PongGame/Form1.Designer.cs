namespace Ping_pong
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PlayerPlatform = new System.Windows.Forms.Panel();
            this.EnemyPlatform = new System.Windows.Forms.Panel();
            this.PictureBoxBall = new System.Windows.Forms.PictureBox();
            this.PlayerScore = new System.Windows.Forms.Label();
            this.AIScore = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBall)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayerPlatform
            // 
            this.PlayerPlatform.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PlayerPlatform.BackColor = System.Drawing.Color.DarkGreen;
            this.PlayerPlatform.Location = new System.Drawing.Point(759, 141);
            this.PlayerPlatform.Name = "PlayerPlatform";
            this.PlayerPlatform.Size = new System.Drawing.Size(29, 118);
            this.PlayerPlatform.TabIndex = 0;
            // 
            // EnemyPlatform
            // 
            this.EnemyPlatform.BackColor = System.Drawing.Color.DarkGreen;
            this.EnemyPlatform.Location = new System.Drawing.Point(12, 141);
            this.EnemyPlatform.Name = "EnemyPlatform";
            this.EnemyPlatform.Size = new System.Drawing.Size(29, 118);
            this.EnemyPlatform.TabIndex = 1;
            // 
            // PictureBoxBall
            // 
            this.PictureBoxBall.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxBall.Image")));
            this.PictureBoxBall.InitialImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxBall.InitialImage")));
            this.PictureBoxBall.Location = new System.Drawing.Point(374, 186);
            this.PictureBoxBall.Name = "PictureBoxBall";
            this.PictureBoxBall.Size = new System.Drawing.Size(51, 47);
            this.PictureBoxBall.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBoxBall.TabIndex = 2;
            this.PictureBoxBall.TabStop = false;
            // 
            // PlayerScore
            // 
            this.PlayerScore.AutoSize = true;
            this.PlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerScore.Location = new System.Drawing.Point(615, 10);
            this.PlayerScore.Name = "PlayerScore";
            this.PlayerScore.Size = new System.Drawing.Size(99, 31);
            this.PlayerScore.TabIndex = 3;
            this.PlayerScore.Text = "Player:";
            // 
            // AIScore
            // 
            this.AIScore.AutoSize = true;
            this.AIScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AIScore.Location = new System.Drawing.Point(35, 10);
            this.AIScore.Name = "AIScore";
            this.AIScore.Size = new System.Drawing.Size(48, 31);
            this.AIScore.TabIndex = 4;
            this.AIScore.Text = "AI:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AIScore);
            this.Controls.Add(this.PlayerScore);
            this.Controls.Add(this.PictureBoxBall);
            this.Controls.Add(this.EnemyPlatform);
            this.Controls.Add(this.PlayerPlatform);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxBall)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PlayerPlatform;
        private System.Windows.Forms.Panel EnemyPlatform;
        private System.Windows.Forms.PictureBox PictureBoxBall;
        private System.Windows.Forms.Label PlayerScore;
        private System.Windows.Forms.Label AIScore;
        private System.Windows.Forms.Timer timer1;
    }
}

