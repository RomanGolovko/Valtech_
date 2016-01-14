using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Shapes.Concrete
{
    public class Line : AShape
    {
        public Line(Form main, PictureBox pctbx, XData data)
        {
            Main = main;
            PictureBox = pctbx;
            Data = data;

            Top = Data.X;
            Left = Data.Y;
            Width = Data.Width;
            Height = Data.Height;
            Color = Data.Color;
            LineWidth = Data.LineWidth;
        }

        public override void DrawShape()
        {
            PictureBox.CreateGraphics().DrawLine(new Pen(Color, LineWidth), Top, Left, Width, Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PictureBox.CreateGraphics().DrawLine(new Pen(Color, LineWidth), Top, Left, Width, Height);
            base.OnPaint(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            Data.GetData(Main);
            base.OnMouseClick(e);
        }
    }
}
