using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Serialization.Memento;
using VectorDrawing_WinForm_.Shapes;

namespace VectorDrawing_WinForm_
{
    public partial class Main : Form
    {
        private PictureBox _pictureBox;

        public Shape Shape { get; set; }

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
            data.SetData(e.X, e.Y, 40, 40, ColorFactory.GetColorFromString(lbl_color.Text), int.Parse(lbl_width.Text), lbl_type.Text);

            var shape = new Shape(data, data.Type);
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
            var shapes = pctbx_canvas1.Controls.OfType<Shape>().Select(shape => shape).ToList();

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
                lbl_color.Text = ((NumericUpDown)sender).Value.ToString(CultureInfo.InvariantCulture);
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
            lbl_width.Text = nmr_width.Value.ToString(CultureInfo.InvariantCulture);
        }

        private void lbl_TextChanged(object sender, EventArgs e)
        {
            Shape.Focus();
            var data = default(XData);

            foreach (var figure in from object shape in _pictureBox.Controls where ((Shape)shape).Focused select shape as Shape)
            {
                data = figure?.Data.SetData(figure.Data.X, figure.Data.Y, 50, 50, ColorFactory.GetColorFromString(lbl_color.Text),
                    int.Parse(lbl_width.Text), lbl_type.Text);
                figure.RedrawShape(data);
            }

            var color = ColorFactory.GetColorNum(ColorFactory.GetColorFromString(lbl_color.Text)) ;
            cmbx_color.SelectedIndex = color;
            ttcmbx_color.SelectedIndex = color;

            var lineWidth = int.Parse(lbl_width.Text);
            nmr_width.Value = lineWidth;
            ttcmbx_width.SelectedIndex = lineWidth - 1;

            var type = TypeFactory.GetNumShapeType(lbl_type.Text);
            cmbx_type.SelectedIndex = type;
            ttcmd_type.SelectedIndex = type;
        }

        public void SetCurrentValue(XData data)
        {
            foreach (var lbl in Controls.OfType<ToolStrip>().SelectMany(control => (control).Items.OfType<ToolStripLabel>()))
            {
                switch ((lbl).Name)
                {
                                
                    case "lbl_color":
                        (lbl).Text = data.Color.ToString();
                        break;
                    case "lbl_width":
                        (lbl).Text = data.LineWidth.ToString();
                        break;
                    case "lbl_type":
                        (lbl).Text = data.Type;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
