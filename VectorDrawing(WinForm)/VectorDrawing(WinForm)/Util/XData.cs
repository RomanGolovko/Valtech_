using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VectorDrawing_WinForm_.Util
{
    public class XData
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color Color { get; set; }
        public string Type { get; set; }
        public int LineWidth { get; set; }

        public void SetData(int x, int y, int width, int height, Color color, int lineWidth, string type)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            LineWidth = lineWidth;
            Type = type;
        }

        public void GetData(Form main)
        {
            foreach (var item in main.Controls)
            {
                var box = item as GroupBox;
                if (box != null)
                {
                    foreach (var grpbxItem in box.Controls)
                    {
                        var comboBox = grpbxItem as ComboBox;
                        if (comboBox != null)
                        {
                            switch (comboBox.Name)
                            {
                                case "cmbx_color":
                                    comboBox.SelectedIndex = GetColor();
                                    break;
                                case "cmbx_type":
                                    comboBox.SelectedIndex = GetShapeType();
                                    break;
                                default:
                                    break;
                            }
                        }
                        else if (grpbxItem is NumericUpDown)
                        {
                            ((NumericUpDown)grpbxItem).Value = LineWidth;
                        }
                    }
                }
                else if (item is ToolStripComboBox)
                {
                    switch (((ToolStripComboBox)item).Name)
                    {
                        case "ttcmbx_color":
                            ((ToolStripComboBox) item).SelectedIndex = GetColor();
                            break;
                        case "ttcmbx_width":
                            ((ToolStripComboBox) item).SelectedIndex = LineWidth;
                            break;
                        case "ttcmd_type":
                            ((ToolStripComboBox)item).SelectedIndex = GetShapeType();
                            break;
                        default:
                            break;
                    }
                }
                else if (item is ToolStrip)
                {
                    foreach (var tlstrpItem in ((ToolStrip)item).Items.OfType<ToolStripLabel>())
                    {
                        switch ((tlstrpItem).Name)
                        {
                            case "lbl_color":
                                (tlstrpItem).Text = Color.ToString();
                                break;
                            case "lbl_width":
                                (tlstrpItem).Text = LineWidth.ToString();
                                break;
                            case "lbl_type":
                                (tlstrpItem).Text = Type;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private int GetColor()
        {
            var color = 0;

            if (Color == Color.Black)
            {
                color = 0;
            }
            else if (Color == Color.Green)
            {
                color = 1;
            }
            else if (Color == Color.Red)
            {
                color = 2;
            }

            return color;
        }

        private int GetShapeType()
        {
            var type = 0;

            switch (Type)
            {
                case "Rectangle": type = 0; break;
                case "Ellipse": type = 1; break;
                case "Line": type = 2; break;
                default:
                    break;
            }

            return type;
        }
    }
}
