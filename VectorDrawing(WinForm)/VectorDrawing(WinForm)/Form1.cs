using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Shapes.Concrete;
using VectorDrawing_WinForm_.Util;
using Rectangle = VectorDrawing_WinForm_.Shapes.Concrete.Rectangle;

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
            var data = new XData();
            data.SetData(cmbx_color.Text, (int)nmr_width.Value, cmbx_type.Text);

            switch (cmbx_type.Text)
            {
                case "Rectangle":
                    {
                        var rectangle = new Rectangle { Top = e.X, Left = e.Y };
                        rectangle.DrawShape(pctbx, Color.Red, data.Width);
                        pctbx.Controls.Add(rectangle);
                    }
                    break;
                case "Ellipse":
                    {
                        var ellipse = new Ellipse { Top = e.X, Left = e.Y };
                        ellipse.DrawShape(pctbx, Color.Red, data.Width);
                        pctbx.Controls.Add(ellipse);
                    }
                    break;
                case "Line":
                    {
                        var line = new Line { Top = e.X, Left = e.Y };
                        line.DrawShape(pctbx, Color.Red, data.Width);
                        pctbx.Controls.Add(line);
                    }
                    break;
            }
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
            ///TODO: изменить захардкоженный пикчербокс, сохраняет неполный объем данных (нет ширины, высоты, толщины и т.д.)
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
                    shape.DrawShape(_pictureBox, shape.ForeColor, shape.LineWidth);
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
