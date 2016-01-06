using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Drawing_WinForm_
{
    public partial class Main : Form
    {
        private bool isPresed;
        private int _x;
        private int _y;

        public Main()
        {
            InitializeComponent();
            cmbx_color.DataSource = new List<string> { "black", "green", "red" };
        }

        private void pctbx_canvas_MouseDown(object sender, MouseEventArgs e)
        {
            isPresed = true;
            _x = e.X;
            _y = e.Y;
        }

        private void pctbx_canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isPresed = false;
        }

        private void pctbx_canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPresed)
            {
                var color = ChooseColor();
                var size = (int)nmrc_size.Value;
                pctbx_canvas.CreateGraphics().DrawLine(new Pen(color, size), _x, _y, e.X, e.Y);
            }
            _x = e.X;
            _y = e.Y;
        }

        private Color ChooseColor()
        {
            var color = Color.Black;

            switch (cmbx_color.SelectedText)
            {
                case "black": color = Color.Black; break;
                case "green": color = Color.Green; break;
                case "red": color = Color.Red; break;
                default:
                    break;
            }

            return color;
        }
    }
}
