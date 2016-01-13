using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Shapes.Abstract;

namespace VectorDrawing_WinForm_
{
    public partial class Main : Form
    {
        private PictureBox _pictureBox;
        public Main()
        {
            InitializeComponent();

            cmbx_color.DataSource = new List<string> { "Black", "Green", "Red" };
            cmbx_type.DataSource = new List<string> { "Rectangle", "Ellipse", "Line", "Round rectangle", "Fozzy" };
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
            foreach (var shape in _pictureBox.Controls)
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

        private void tbcntrl_canvas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcntrl_canvas.SelectedIndex == 0)
            {
                _pictureBox = pctbx_canvas1;
            }
            else if (tbcntrl_canvas.SelectedIndex == 1)
            {
                _pictureBox = pctbx_canvas2;
            }
        }
    }
}
