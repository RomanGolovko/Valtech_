using System;
using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Factories;

namespace VectorDrawing_WinForm_.Shapes
{
    public class Shape : Control
    {
        private bool _isPresed;
        private bool _isMoved;
        private bool _isResized;
        private int _dx;
        private int _dy;
        private ToolStripComboBox _colorMenu;
        private ToolStripComboBox _lineWidthMenu;
        private ToolStripComboBox _typeMenu;

        public XData Data { get; }
        public Color Color { get; private set; }
        public int LineWidth { get; private set; }
        public string Type { get; private set; }

        public Shape(XData data, string type)
        {
            Data = data;

            Left = Data.X;
            Top = Data.Y;
            Width = Data.Width;
            Height = Data.Height;
            Color = Data.Color;
            LineWidth = Data.LineWidth;
            BackColor = Color.White;
            Type = type;
        }

        public void RedrawShape(XData data)
        {
            Left = data.X;
            Top = data.Y;
            Width = data.Width;
            Height = data.Height;
            Color = data.Color;
            LineWidth = data.LineWidth;
            Type = data.Type;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            switch (Type)
            {
                case "Rectangle":
                    CreateGraphics().DrawRectangle(new Pen(Color, LineWidth), 1, 1, Width - 2, Height - 2);
                    break;
                case "Ellipse":
                    CreateGraphics().DrawEllipse(new Pen(Color, LineWidth), 1, 1, Width - 2, Height - 2);
                    break;
                case "Line":
                    CreateGraphics().DrawLine(new Pen(Color, LineWidth), 1, 1, Width - 2, Height - 2);
                    break;
                default:
                    break;
            }
        }

 
        private void cmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color = ColorFactory.GetColorFromNum(_colorMenu.SelectedIndex);
            LineWidth = _lineWidthMenu.SelectedIndex + 1;
            Type = TypeFactory.GetStrShapeType(_typeMenu.SelectedIndex);

            RedrawShape(Data.SetData(Left, Top, Width, Height, Color, LineWidth, Type));

            var pctbx = Parent;
            var tbPg = pctbx.Parent;
            var tbCntrl = tbPg.Parent;
            var main = tbCntrl.Parent as Main;
            main.SetData(Data);
            main.CurrentShape = this;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();

            _isPresed = true;
            if (e.X >= Width - 10 && e.Y >= Height - 10)
            {
                _isResized = true;
                _isMoved = false;
            }
            else
            {
                _isResized = false;
                _isMoved = true;
            }

            _dx = e.X;
            _dy = e.Y;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPresed = false;
            _isMoved = false;
            _isResized = false;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            BackColor = default(Color);

            var main = Parent.Parent.Parent.Parent as Main;
            main.SetData(Data);
            main.CurrentShape = this;
        }

        protected override void OnLostFocus(EventArgs e)
        {
            BackColor = Color.White;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!_isPresed) return;

            if (_isMoved)
            {
                Top += e.Y - _dy;
                Left += e.X - _dx;
            }
            else if (_isResized)
            {
                Width = e.X - (Parent.Left - _dx);
                Height = e.Y - (Parent.Top - _dy);
            }

            Invalidate();
        }
    }
}
