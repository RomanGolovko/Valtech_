using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace VectorDrawing_WinForm_.Memento
{
    [Serializable]
    [DataContract]                          // for json serialization
    public class ShapeMemento
    {
        [DataMember]                        // for json serialization
        public int X { get; set; }

        [DataMember]                        // for json serialization
        public int Y { get; set; }

        [DataMember]                        // for json serialization
        public int Width { get; set; }

        [DataMember]                        // for json serialization
        public int Height { get; set; }

        [DataMember]                        // for json serialization
        public Color Color { get; set; }

        [DataMember]                        // for json serialization
        public string Type { get; set; }

        [DataMember]                        // for json serialization
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
                if (item is GroupBox)
                {
                    foreach (var grpbxItem in ((GroupBox)item).Controls)
                    {
                        if (grpbxItem is ComboBox)
                        {
                            if (((ComboBox)grpbxItem).Name == "cmbx_color")
                            {
                                ((ComboBox)grpbxItem).SelectedIndex = GetColor();
                            }
                            else if (((ComboBox)grpbxItem).Name == "cmbx_type")
                            {
                                ((ComboBox)grpbxItem).SelectedIndex = GetShapeType();
                            }
                        }
                        else if (grpbxItem is NumericUpDown)
                        {
                            ((NumericUpDown)grpbxItem).Value = LineWidth;
                        }
                    }
                }
                else if (item is ToolStrip)
                {
                    foreach (var tlstrpItem in ((ToolStrip)item).Items)
                    {
                        if (tlstrpItem is ToolStripLabel)
                        {
                            if (((ToolStripLabel)tlstrpItem).Name == "lbl_color")
                            {
                                ((ToolStripLabel)tlstrpItem).Text = Color.ToString();
                            }
                            else if (((ToolStripLabel)tlstrpItem).Name == "lbl_width")
                            {
                                ((ToolStripLabel)tlstrpItem).Text = LineWidth.ToString();
                            }
                            else if (((ToolStripLabel)tlstrpItem).Name == "lbl_type")
                            {
                                ((ToolStripLabel)tlstrpItem).Text = Type;
                            }
                        }
                    }
                }
                else if (item is MenuStrip)
                {
                    foreach (var mnItem in ((MenuStrip)item).Items)
                    {
                        if (((MenuStrip)mnItem).Name == "ttcmbx_color")
                        {
                            ((ToolStripComboBox)mnItem).SelectedIndex = GetColor();
                        }
                        else if (((MenuStrip)mnItem).Name == "ttcmbx_width")
                        {
                            ((ToolStripComboBox)mnItem).SelectedItem = LineWidth;
                        }
                        else if (((MenuStrip)mnItem).Name == "ttcmbx_type")
                        {
                            ((ToolStripComboBox)mnItem).SelectedIndex = GetColor();
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
