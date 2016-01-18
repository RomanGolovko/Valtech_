using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Serialization.Memento;
using VectorDrawing_WinForm_.Shapes;
using System.Resources;

namespace VectorDrawing_WinForm_
{
    public partial class Main : Form
    {
        private ResourceManager _locale;
        private PictureBox _pictureBox;
        private XData _data;

        public Shape CurrentShape { get; set; }

        public Main()
        {
            _locale = new ResourceManager("VectorDrawing_WinForm_.Resources.Locale", typeof(Main).Assembly);

            InitializeComponent();

            _pictureBox = pctbx_canvas1;

            _data = new XData
            {
                Color = Color.Black,
                LineWidth = 1,
                Type = "Rectangle"
            };

            tsmi_language.Items.AddRange(new object[] { "English", "Русский", "Українська" });
            tsmi_language.SelectedIndex = 0;

            ttcmbx_color.Items.AddRange(new object[] { "Black", "Green", "Red" });
            ttcmbx_width.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            ttcmd_type.Items.AddRange(new object[] { "Rectangle", "Ellipse", "Line" });

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

            fileToolStripMenuItem.Text = _locale.GetString("fileToolStripMenuItem");
            openToolStripMenuItem.Text = _locale.GetString("openToolStripMenuItem");
            saveToolStripMenuItem.Text = _locale.GetString("saveToolStripMenuItem");
            exitToolStripMenuItem.Text = _locale.GetString("exitToolStripMenuItem");
            colorToolStripMenuItem.Text = _locale.GetString("colorToolStripMenuItem");
            widthToolStripMenuItem.Text = _locale.GetString("widthToolStripMenuItem");
            typeToolStripMenuItem.Text = _locale.GetString("typeToolStripMenuItem");
            tabsToolStripMenuItem.Text = _locale.GetString("tabsToolStripMenuItem");
            settingsToolStripMenuItem.Text = _locale.GetString("settingsToolStripMenuItem");
            languageToolStripMenuItem.Text = _locale.GetString("languageToolStripMenuItem");
            styleToolStripMenuItem.Text = _locale.GetString("styleToolStripMenuItem");
            aboutToolStripMenuItem.Text = _locale.GetString("aboutToolStripMenuItem");
            grbx_color.Text = _locale.GetString("grbx_color");
            grbx_width.Text = _locale.GetString("grbx_width");
            grbx_type.Text = _locale.GetString("grbx_type");
            grbx_coord.Text = _locale.GetString("grbx_coord");
            tbpg_1.Text = _locale.GetString("tbpg_1");
            tbpg_2.Text = _locale.GetString("tbpg_2");
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

            _data.SetData(e.X, e.Y, 40, 40, _data.Color, _data.LineWidth, _data.Type);

            var shape = new Shape(_data, _data.Type) {Location = new Point(_data.X, _data.Y)};
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

        public void SetData(XData data)
        {
            _data = data;
            SetValue();
        }

        private void SetValue()
        {
            CurrentShape?.Focus();
            if (CurrentShape != null && CurrentShape.Focused)
            {
               CurrentShape.RedrawShape( CurrentShape.Data.SetData(_data.X, _data.Y, _data.Width, 
                   _data.Height, _data.Color, _data.LineWidth, _data.Type));
            }

            var color = ColorFactory.GetColorNum(_data.Color);
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
    }
}
