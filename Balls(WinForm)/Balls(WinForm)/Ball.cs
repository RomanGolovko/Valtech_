using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Balls_WinForm_
{
    public class Ball : Control
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IncreaseX { get; set; }
        public bool IncreaseY { get; set; }
        private PictureBox _pictureBox;

        public Ball() { }

        public Ball(PictureBox pctbx, MouseEventArgs e)
        {
            _pictureBox = pctbx;

            X = e.X;
            Y = e.Y;

            var random = new Random();
            IncreaseX = random.Next(-1, 2) >= 0;
            IncreaseY = random.Next(-1, 2) >= 0;
        }

        public void SetPctbx(PictureBox pctbx)
        {
            _pictureBox = pctbx;
        }

        public void MoveBall()
        {
            while (true)
            {
                Thread.Sleep(25);

                _pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.White), X, Y, 20, 20);

                X = IncreaseX ? ++X : --X;
                Y = IncreaseY ? ++Y : --Y;

                _pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.Red), X, Y, 20, 20);

                if (X == 0 || X == _pictureBox.ClientSize.Width - 20)
                {
                    IncreaseX = !IncreaseX;
                }

                if (Y == 0 || Y == _pictureBox.ClientSize.Height - 20)
                {
                    IncreaseY = !IncreaseY;
                }
            }
        }
    }
}
