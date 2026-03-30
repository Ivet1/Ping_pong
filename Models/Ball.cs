using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ping_pong.Models
{
    public class Ball
    {
        private int x;
        private int y;
        private int speedX;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int SpeedX
        {
            get { return speedX; }
            set
            {
                if (value == 0)
                    speedX = 5;
                else if (value > 10)
                    speedX = 10;
                else if(value<-10)
                    speedX = -10;
                else
                    speedX = value;
            }
        }
        private int speedY;
        public int SpeedY
        {
            get { return speedY; }
            set
            {
                if (value == 0)
                    speedY = 5;
                else if (value > 10)
                    speedY = 10;
                else if (value < -10)
                    speedY = -10;
                else
                    speedY = value;
            }
        }
        public int Width { get; set; } 
        public int Height { get; set; }
        public PictureBox Picture;
        public Ball(PictureBox picture)
        {
            Picture = picture;
            Width = picture.Width;
            Height = picture.Height;
            X = picture.Left;
            Y = picture.Top;
            SpeedX = 5;
            SpeedY = 5;
        }
        public void Move()
        {
            X += SpeedX;
            Y += SpeedY;
            Picture.Left = X;
            Picture.Top = Y;
        }
        public void ReverseX()
        {
            SpeedX = -SpeedX;
            //slight increase in speed after each hit
            if (SpeedX > 0)
                    SpeedX += 1;
                else
                    SpeedX -= 1;
        }
        public void ReverseY()
        {
            SpeedY = -SpeedY;
        }
    }
}
