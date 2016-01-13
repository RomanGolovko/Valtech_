using System.Drawing;
using System.Windows.Forms;

namespace VectorDrawing_WinForm_.Shapes.Abstract
{
    public abstract class AShape : Control
    {
        public int LineWidth { get; set; }

        public abstract void DrawShape(PictureBox pctbx, Color color, int width);
    }
}
