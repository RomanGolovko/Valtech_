using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Balls_WinForm_
{
    public partial class Main : Form
    {
        private List<Ball> _balls = new List<Ball>();

        public Main()
        {
            InitializeComponent();
            cmbx_format.DataSource = new List<string> { "Binary", "CSV", "XML", "JSON", "YAML" };
        }

        private void pctbx_canvas_MouseClick(object sender, MouseEventArgs e)
        {
            var ball = new Ball(pctbx_canvas, e);
            _balls.Add(ball);
            var thread = new Thread(ball.MoveBall);
            thread.Start();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            var memento = new PctbxMemento(_balls);
            memento.SaveState(cmbx_format.Text);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            try
            {
                _balls = PctbxMemento.RestoreState(cmbx_format.Text);

                foreach (var ball in _balls)
                {
                    ball.SetPctbx(pctbx_canvas);
                    var thread = new Thread(ball.MoveBall);
                    thread.Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There is no saved data!!!", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
