using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Memento;
using VectorDrawing_WinForm_.Shapes.Abstract;

namespace VectorDrawing_WinForm_.Shapes.Concrete
{
    public class Line : AShape
    {
        public Line(Form main, PictureBox pctbx, ShapeMemento memento)
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
