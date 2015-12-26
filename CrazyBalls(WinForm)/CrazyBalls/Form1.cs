using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CrazyBalls
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            var thread = new Thread(CreateBall);
            thread.Start(e);
        }

        private void CreateBall(object obj)
        {
            var e = (MouseEventArgs)obj;
            var x = e.X;
            var y = e.Y;

            CreateGraphics().DrawEllipse(new Pen(Color.Red), x, y, 20, 20);

            var random = new Random();
            var xDirection = random.Next(-1, 2);
            var ydirection = random.Next(-1, 2);
            bool increaseX;
            bool increaseY;

            if (xDirection >= 0 && ydirection >= 0)
            {
                increaseX = true;
                increaseY = true;
            }
            else if (xDirection < 0 && ydirection >= 0)
            {
                increaseX = false;
                increaseY = true;
            }
            else if (xDirection < 0 && ydirection < 0)
            {
                increaseX = true;
                increaseY = false;
            }
            else
            {
                increaseX = false;
                increaseY = false;
            }

            while (true)
            {
                Thread.Sleep(25);
                CreateGraphics().DrawEllipse(new Pen(Color.White), x, y, 20, 20);

                if (x == 0 || x == ClientSize.Width - 20)
                {
                    increaseX = !increaseX;
                }

                if (y == 0 || y == ClientSize.Height - 20)
                {
                    increaseY = !increaseY;
                }

                x = increaseX ? ++x : --x;
                y = increaseY ? ++y : --y;

                CreateGraphics().DrawEllipse(new Pen(Color.Red), x, y, 20, 20);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
