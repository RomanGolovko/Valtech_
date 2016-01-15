using System;
using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Shapes.Abstract
{
    public abstract class AShape : Control
    {
        private bool _isPresed;
        private int _dx;
        private int _dy;

        public Form Main { get; set; }
        public XData Data { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }
        public string Type { get; set; }

        public abstract void RedrawShape(XData data);

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            Focus();

            switch (e.Button)
            {
                case MouseButtons.Left:
                    Focus();
                    break;
                case MouseButtons.Right:
                    var shapeMenu = new ContextMenuStrip();

                    var colorMenu = new ToolStripComboBox();
                    colorMenu.Items.AddRange(new object[] { "Black", "Green", "Red" });
                    colorMenu.SelectedIndex = NumColorFactory.GetColor(Color);
                    colorMenu.SelectedIndexChanged += cmbx_SelectedIndexChanged;

                    var widthMenu = new ToolStripComboBox();
                    widthMenu.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
                    widthMenu.SelectedIndex = LineWidth - 1;
                    widthMenu.SelectedIndexChanged += cmbx_SelectedIndexChanged;

                    var typeMenu = new ToolStripComboBox();
                    typeMenu.Items.AddRange(new object[] { "Rectangle", "Ellipse", "Line" });

                    shapeMenu.Items.AddRange(new ToolStripItem[] {colorMenu, widthMenu, typeMenu});
                    ContextMenuStrip = shapeMenu;
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawShape(Data.SetData(Top, Left, Width, Height, Color, LineWidth, Type));
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            _isPresed = true;
            _dx= e.X;
            _dy = e.Y;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPresed = false;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.Capture = true;
            BackColor = default(Color);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            BackColor = Color.White;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isPresed) return;
            Top += e.Y - _dy;
            Left += e.X - _dx;
        }
    }
}
