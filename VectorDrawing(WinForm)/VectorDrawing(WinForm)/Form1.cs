using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Serialization.Memento;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_
{
    public partial class Main : Form
    {
        private PictureBox _pictureBox;
        public Main()
        {
            InitializeComponent();

            _pictureBox = pctbx_canvas1;

            cmbx_color.DataSource = new List<string> { "Black", "Green", "Red" };
            cmbx_type.DataSource = new List<string> { "Rectangle", "Ellipse", "Line" };

            ttcmbx_color.Items.AddRange(new object[] { "Black", "Green", "Red" });
            ttcmbx_color.SelectedIndex = 0;
            ttcmbx_width.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            ttcmbx_width.SelectedIndex = (int)nmr_width.Value - 1;
            ttcmd_type.Items.AddRange(new object[] { "Rectangle", "Ellipse", "Line" });
            ttcmd_type.SelectedIndex = 0;

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
                default:
                    break;
            }
        }

        private void pctbx_canvas_MouseClick(object sender, MouseEventArgs e)
        {
            var pctbx = (PictureBox)sender;

            var data = new XData();
            data.SetData(e.X, e.Y, 20, 20, ColorFactory.GetColor(lbl_color.Text), int.Parse(lbl_width.Text), lbl_type.Text);

            var shape = ShapeFactory.GetShape(lbl_type.Text,this,  data);
            shape.Location = new Point(data.X, data.Y);
            pctbx.Controls.Add(shape);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"Binary format (*.dat)|*.dat|XML format (*.xml)|*.xml|" +
                         @"JSON format (*.json)|*.json|YAML format (*.yaml)|*.yaml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            ///TODO: изменить захардкоженный пикчербокс
            var shapes = pctbx_canvas1.Controls.OfType<AShape>().Select(shape => shape).ToList();

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

        private void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                switch (((ComboBox)sender).Name)
                {
                    case "cmbx_color":
                        lbl_color.Text = ((ComboBox)sender).Text;
                        break;
                    case "cmbx_type":
                        lbl_type.Text = ((ComboBox)sender).Text;
                        break;
                    default:
                        break;
                }
            }
            else if (sender is NumericUpDown)
            {
                lbl_color.Text = ((NumericUpDown)sender).Value.ToString();
            }
            else if (sender is ToolStripComboBox)
            {
                switch (((ToolStripComboBox)sender).Name)
                {
                    case "ttcmbx_color":
                        lbl_color.Text = ((ToolStripComboBox)sender).Text;
                        break;
                    case "ttcmd_type":
                        lbl_type.Text = ((ToolStripComboBox)sender).Text;
                        break;
                    default:
                        break;
                }
            }
        }

        private void nmr_width_ValueChanged(object sender, EventArgs e)
        {
            lbl_width.Text = nmr_width.Value.ToString();
        }

        private void lbl_TextChanged(object sender, EventArgs e)
        {
            if (_pictureBox.Controls.OfType<AShape>().FirstOrDefault(x => x.Name == ((AShape)sender).Name) != null)
            {
                var data = new XData();
                var temp = _pictureBox.Controls.OfType<AShape>().FirstOrDefault(x => x.Name == ((AShape)sender).Name);
                data.SetData(temp.Data.X, temp.Data.Y, 20, 20, ColorFactory.GetColor(lbl_color.Text), int.Parse(lbl_width.Text), lbl_type.Text);
            }
        }
    }
}
