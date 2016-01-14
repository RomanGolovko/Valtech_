using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Shapes.Concrete;

namespace VectorDrawing_WinForm_
{
    public partial class Main : Form
    {
        private PictureBox _pictureBox;
        public Main()
        {
            InitializeComponent();

            cmbx_color.DataSource = new List<string> { "Black", "Green", "Red" };
            cmbx_type.DataSource = new List<string> { "Rectangle", "Ellipse", "Line" };
        }

        private void tbcntrl_canvas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tbcntrl_canvas.SelectedIndex)
            {
                case 0:
                    _pictureBox = pctbx_canvas1;
                    break;
                case 1:
                    _pictureBox = pctbx_canvas2;
                    break;
            }
        }

        private void pctbx_canvas_MouseClick(object sender, MouseEventArgs e)
        {
            var pctbx = (PictureBox)sender;
            var shape = new ShapeMemento();
            shape.SetData(e.X, e.Y, 15, 15, ChooseColor(), (int)nmr_width.Value, cmbx_type.Text);

            switch (cmbx_type.Text)
            {
                case "Rectangle":
                    {
                        var rectangle = new Shapes.Concrete.Rectangle(this, pctbx, shape);
                        pctbx.Controls.Add(rectangle);
                        rectangle.DrawShape();
                    }
                    break;
                case "Ellipse":
                    {
                        var ellipse = new Ellipse(pctbx, shape);
                        pctbx.Controls.Add(ellipse);
                        ellipse.DrawShape();
                    }
                    break;
                case "Line":
                    {
                        var line = new Line(pctbx, shape);
                        pctbx.Controls.Add(line);
                        line.DrawShape();
                    }
                    break;
            }
            Refresh();
        }

        private Color ChooseColor()
        {
            Color color = Color.Black;

            if (cmbx_color.Text == "Black")
            {
                color = Color.Black;
            }
            else if (cmbx_color.Text == "Green")
            {
                color = Color.Green;
            }
            else if (cmbx_color.Text == "Red")
            {
                color = Color.Red;
            }

            return color;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"Binary format (*.dat)|*.dat|XML format (*.xml)|*.xml|" +
                         @"JSON format (*.json)|*.json|YAML format (*.yaml)|*.yaml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            var shapes = new List<AShape>();
            ///TODO: изменить захардкоженный пикчербокс
            foreach (var shape in pctbx_canvas1.Controls)
            {
                if (shape is AShape)
                {
                    shapes.Add(shape as AShape);
                }
            }

            var memento = new PctbxMemento(shapes);
            memento.SaveState(saveFileDialog.FilterIndex, saveFileDialog.FileName);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Binary format (*.dat)|*.dat|XML format (*.xml)|*.xml|" +
                         @"JSON format (*.json)|*.json|YAML format (*.yaml)|*.yaml"
            };
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                var shapes = PctbxMemento.RestoreState(openFileDialog.FilterIndex, openFileDialog.FileName);

                foreach (var shape in shapes)
                {
                    ///TODO: изменить захардкоженный пикчербокс
                    shape.PictureBox = pctbx_canvas1;
                    shape.DrawShape();
                    pctbx_canvas1.Controls.Add(shape);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There is no saved data!!!", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
