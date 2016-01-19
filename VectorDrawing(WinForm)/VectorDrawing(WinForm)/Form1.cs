using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Shapes;
using System.Resources;
using VectorDrawing_WinForm_.Memento;

namespace VectorDrawing_WinForm_
{
    public partial class Main : Form
    {
        private readonly ResourceManager _locale;
        private Shape _currentShape;
        private XData _data;


        public Main()
        {
            _locale = new ResourceManager("VectorDrawing_WinForm_.Resources.Locale", typeof(Main).Assembly);

            InitializeComponent();

            _data = new XData
            {
                Color = Color.Black,
                LineWidth = 1,
                Type = "Rectangle"
            };

            tsmi_language.Items.AddRange(new object[] { "English", "Русский", "Українська" });
            tsmi_language.SelectedIndex = 0;

            tsmi_theme.Items.AddRange(new object[] { "Gray", "Blue", "Dark" });
            tsmi_theme.SelectedIndex = 0;

            ttcmbx_color.Items.AddRange(new object[] { "Black", "Green", "Red" });
            ttcmbx_width.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            ttcmd_type.Items.AddRange(new object[] { "Rectangle", "Ellipse", "Line" });

            ttcmbx_tabs.Items.AddRange(new object[] {"1", "2"});

            cmbx_color.DataSource = new List<string> { "Black", "Green", "Red" };
            cmbx_type.DataSource = new List<string> { "Rectangle", "Ellipse", "Line" };

            cmbx_color.SelectedIndexChanged += cmbx_SelectedIndexChanged;
            cmbx_type.SelectedIndexChanged += cmbx_SelectedIndexChanged;

            SetValue();
        }

        private void tsmi_language_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tsmi_language.Text)
            {
                case "English":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("");
                    break;
                case "Русский":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    break;
                case "Українська":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("uk-UA");
                    break;
                default:
                    break;
            }

            tsmi_file.Text = _locale.GetString("tsmi_file");
            tsmi_open.Text = _locale.GetString("tsmi_open");
            tsmi_save.Text = _locale.GetString("tsmi_save");
            tsmi_exit.Text = _locale.GetString("tsmi_exit");
            tsmi_color.Text = _locale.GetString("tsmi_color");
            tsmi_lineWidth.Text = _locale.GetString("tsmi_lineWidth");
            tsmi_type.Text = _locale.GetString("tsmi_type");
            tsmi_tabs.Text = _locale.GetString("tsmi_tabs");
            tsmi_settings.Text = _locale.GetString("tsmi_settings");
            tsmi_lang.Text = _locale.GetString("tsmi_lang");
            tsmi_style.Text = _locale.GetString("tsmi_style");
            tsmi_about.Text = _locale.GetString("tsmi_about");
            grbx_color.Text = _locale.GetString("grbx_color");
            grbx_width.Text = _locale.GetString("grbx_width");
            grbx_type.Text = _locale.GetString("grbx_type");
            grbx_coord.Text = _locale.GetString("grbx_coord");
            tbpg_1.Text = _locale.GetString("tbpg_1");
            tbpg_2.Text = _locale.GetString("tbpg_2");
        }

        private void tsmi_theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var themeColor = default(Color);

            switch (tsmi_theme.Text)
            {
                case "Gray":
                    themeColor = default(Color);
                    break;
                case "Blue":
                    themeColor = Color.Blue;
                    break;
                case "Dark":
                    themeColor = Color.DarkGray;
                    break;
                default:
                    break;
            }

            BackColor = themeColor;

            foreach (var control in Controls)
            {
                if (control is MenuStrip)
                {
                    ((MenuStrip)control).BackColor = themeColor;
                }
                else if (control is GroupBox)
                {
                    ((GroupBox)control).BackColor = themeColor;
                }
                else if (control is ToolStrip)
                {
                    ((ToolStrip)control).BackColor = themeColor;
                }
            }

            Invalidate();
        }

        private void tbcntrl_canvas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ttcmbx_tabs.SelectedIndex = tbcntrl_canvas.SelectedIndex;
        }

        private void pctbx_canvas_MouseClick(object sender, MouseEventArgs e)
        {
            var pctbx = (PictureBox)sender;

            _data.SetData(e.X, e.Y, 40, 40, _data.Color, _data.LineWidth, _data.Type, tbcntrl_canvas.SelectedIndex);

            var shape = new Shape(_data, _data.Type) { Location = new Point(_data.X, _data.Y) };
            pctbx.Controls.Add(shape);
        }

        private void tsmi_save_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = @"Binary format (*.dat)|*.dat|XML format (*.xml)|*.xml|" +
             @"JSON format (*.json)|*.json|YAML format (*.yaml)|*.yaml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            List<Shape> shapes = new List<Shape>();

            foreach (var item in tbcntrl_canvas.TabPages)
            {
                foreach (var pctbx in ((TabPage)item).Controls)
                {
                    shapes.AddRange(((PictureBox)pctbx).Controls.OfType<Shape>().Select(shape => shape).ToList());
                }
            }

            var memento = new PctbxMemento(shapes);
            memento.SaveState(saveFileDialog.FilterIndex, saveFileDialog.FileName);
        }

        private void tsmi_open_Click(object sender, EventArgs e)
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
                    tbcntrl_canvas.Controls[shape.TabIndex].Controls.OfType<PictureBox>().FirstOrDefault().Controls.Add(shape);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"There is no saved data!!!", @"Balls", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is ComboBox)
            {
                switch (((ComboBox)sender).Name)
                {
                    case "cmbx_color":
                        _data.Color = ColorFactory.GetColorFromString(((ComboBox)sender).Text);
                        break;
                    case "cmbx_type":
                        _data.Type = ((ComboBox)sender).Text;
                        break;
                    default:
                        break;
                }
            }
            else if (sender is ToolStripComboBox)
            {
                switch (((ToolStripComboBox)sender).Name)
                {
                    case "ttcmbx_color":
                        _data.Color = ColorFactory.GetColorFromString(((ToolStripComboBox)sender).Text);
                        break;
                    case "ttcmd_type":
                        _data.Type = ((ToolStripComboBox)sender).Text;
                        break;
                    default:
                        break;
                }
            }

            SetValue();
        }

        private void nmr_width_ValueChanged(object sender, EventArgs e)
        {
            _data.LineWidth = (int)nmr_width.Value;
            SetValue();
        }

        public void SetData(Shape shape)
        {
            _data = shape.Data;
            _currentShape = shape;
            SetValue();
        }

        private void SetValue()
        {
            _currentShape?.RedrawShape(_data);
            _currentShape?.Focus();

            var color = ColorFactory.GetNumColor(_data.Color);
            cmbx_color.SelectedIndex = color;
            ttcmbx_color.SelectedIndex = color;
            lbl_color.Text = _data.Color.ToString();

            nmr_width.Value = _data.LineWidth;
            ttcmbx_width.SelectedIndex = _data.LineWidth - 1;
            lbl_width.Text = _data.LineWidth.ToString();

            var type = TypeFactory.GetNumShapeType(_data.Type);
            cmbx_type.SelectedIndex = type;
            ttcmd_type.SelectedIndex = type;
            lbl_type.Text = _data.Type;
        }

        private void tsmi_exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
