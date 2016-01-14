using System;
using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Shapes.Abstract;

namespace VectorDrawing_WinForm_.Shapes.Concrete
{
    public class Rectangle : AShape
    {
        public Rectangle(Form main, PictureBox pctbx, ShapeMemento memento)
        {
            Main = main;
            PictureBox = pctbx;
            Data = memento;

            Top = Data.X;
            Left = Data.Y;
            Width = Data.Width;
            Height = Data.Height;
            Color = Data.Color;
            LineWidth = Data.LineWidth;
        }

        public override void DrawShape()
        {
            PictureBox.CreateGraphics().DrawRectangle(new Pen(Color, LineWidth), Top, Left, Width, Height);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PictureBox.CreateGraphics().DrawRectangle(new Pen(Color, LineWidth), Top, Left, Width, Height);
            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            foreach (var item in Main.Controls)
            {
                //if (item is ComboBox)
                //{
                //    if (((ComboBox)item).Name == "cmbx_color")
                //    {
                //        ((ComboBox)item).SelectedText = GetColorStr();
                //    }
                //    else if (((ComboBox)item).Name == "cmbx_type")
                //    {
                //        ((ComboBox)item).SelectedText = Data.Type;
                //    }
                //}
                //else if (item is NumericUpDown)
                //{
                //    ((NumericUpDown)item).Value = LineWidth;
                //}
                //else if (item is ToolStripComboBox)
                //{
                //    if (((ToolStripComboBox)item).Name == "ttcmbx_color")
                //    {
                //        ((ToolStripComboBox)item).SelectedText = GetColorStr();
                //    }
                //    else if (((ToolStripComboBox)item).Name == "ttcmbx_width")
                //    {
                //        ((ToolStripComboBox)item).SelectedItem = LineWidth;
                //    }
                //    else if (((ToolStripComboBox)item).Name == "ttcmbx_type")
                //    {
                //        ((ToolStripComboBox)item).SelectedText = Data.Type;
                //    }
                //    else if (((ToolStripComboBox)item).Name == "ttcmbx_tabs")
                //    {
                //        ((ToolStripComboBox)item).SelectedItem = 1;
                //    }
                //}

                if (item is GroupBox)
                {
                    foreach (var grpbxItem in ((GroupBox)item).Controls)
                    {
                        if (grpbxItem is ComboBox)
                        {
                            if (((ComboBox)grpbxItem).Name == "cmbx_color")
                            {
                                ((ComboBox)grpbxItem).SelectedText = GetColorStr();
                            }
                            else if (((ComboBox)grpbxItem).Name == "cmbx_type")
                            {
                                ((ComboBox)grpbxItem).SelectedText = Data.Type;
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
                        if (((ToolStrip)tlstrpItem).Name == "lbl_color")
                        {
                            ((ToolStrip)tlstrpItem).Text = GetColorStr();
                        }
                        else if (((ToolStrip)tlstrpItem).Name == "lbl_width")
                        {
                            ((ToolStrip)tlstrpItem).Text = LineWidth.ToString();
                        }
                        else if (((ToolStrip)tlstrpItem).Name == "lbl_type")
                        {
                            ((ToolStrip)tlstrpItem).Text = Data.Type;
                        }
                    }
                }
                else if (item is MenuStrip)
                {
                    foreach (var mnItem in ((MenuStrip)item).Items)
                    {
                        if (((MenuStrip)mnItem).Name == "ttcmbx_color")
                        {
                            ((ToolStripComboBox)mnItem).SelectedText = GetColorStr();
                        }
                        else if (((MenuStrip)mnItem).Name == "ttcmbx_width")
                        {
                            ((ToolStripComboBox)mnItem).SelectedItem = LineWidth;
                        }
                        else if (((MenuStrip)mnItem).Name == "ttcmbx_type")
                        {
                            ((ToolStripComboBox)mnItem).SelectedText = Data.Type;
                        }
                    }
                }
            }
            base.OnMouseClick(e);
        }

        private string GetColorStr()
        {
            var color = "";

            if (Color == Color.Black)
            {
                color = "Black";
            }
            else if (Color == Color.Green)
            {
                color = "Green";
            }
            else if (Color == Color.Red)
            {
                color = "Red";
            }

            return color;
        }
    }
}
