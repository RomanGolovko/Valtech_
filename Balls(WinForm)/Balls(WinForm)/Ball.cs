using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

namespace Balls_WinForm_
{
    [Serializable]
    [DataContract]                  // for json serialization
    public class Ball
    {
        [DataMember]                // for json serialization
        public int x;               // public for xml serialization

        [DataMember]                // for json serialization
        public int y;               // public for xml serialization

        [DataMember]                // for json serialization
        public bool increaseX;      // public for xml serialization

        [DataMember]                // for json serialization
        public bool increaseY;      // public for xml serialization

        [NonSerialized]
        private PictureBox _pictureBox;

        public Ball() { }            // for xml serialization

        public Ball(PictureBox pctbx, MouseEventArgs e)
        {
            _pictureBox = pctbx;

            x = e.X;
            y = e.Y;

            var random = new Random();
            increaseX = random.Next(-1, 2) >= 0;
            increaseY = random.Next(-1, 2) >= 0;
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

                _pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.White), x, y, 20, 20);

                x = increaseX ? ++x : --x;
                y = increaseY ? ++y : --y;

                _pictureBox.CreateGraphics().DrawEllipse(new Pen(Color.Red), x, y, 20, 20);

                if (x == 0 || x == _pictureBox.ClientSize.Width - 20)
                {
                    increaseX = !increaseX;
                }

                if (y == 0 || y == _pictureBox.ClientSize.Height - 20)
                {
                    increaseY = !increaseY;
                }
            }
        }
    }
}
