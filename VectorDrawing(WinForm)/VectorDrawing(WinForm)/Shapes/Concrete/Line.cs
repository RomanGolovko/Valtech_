using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Shapes.Abstract;

namespace VectorDrawing_WinForm_.Shapes.Concrete
{
    public class Line : AShape
    {
        public override void DrawShape(PictureBox pctbx, Color color, int width)
        {
            pctbx.CreateGraphics().DrawLine(new Pen(color, width), Top, Left, 10, 15);
        }
    }
}
