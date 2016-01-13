using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Shapes.Abstract;

namespace VectorDrawing_WinForm_.Shapes.Concrete
{
    public class Rectangle : AShape
    {
        public override void DrawShape(PictureBox pctbx, Color color, int width)
        {
            pctbx.CreateGraphics().DrawRectangle(new Pen(color, width), Top, Left, 15, 15);
        }
    }
}
