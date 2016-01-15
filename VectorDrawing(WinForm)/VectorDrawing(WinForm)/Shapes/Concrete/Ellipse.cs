using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Shapes.Concrete
{
    public class Ellipse : AShape
    {
        public Ellipse(Form main, XData data)
        {
            Main = main;
            Data = data;

            Left = Data.X;
            Top = Data.Y;
            Width = Data.Width;
            Height = Data.Height;
            Color = Data.Color;
            LineWidth = Data.LineWidth;
            BackColor = Color.White;
            Type = "Ellipse";
        }

        public override void RedrawShape(XData data)
        {
            Left = Data.X;
            Top = Data.Y;
            Width = Data.Width;
            Height = Data.Height;
            Color = Data.Color;
            LineWidth = Data.LineWidth;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color, LineWidth), 1, 1, Width - 2, Height - 2);
            base.OnPaint(e);
        }
    }
}
