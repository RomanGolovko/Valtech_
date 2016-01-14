using System.Drawing;
using System.Windows.Forms;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Shapes.Abstract
{
    public abstract class AShape : Control
    {
        public XData Data { get; set; }
        public Form Main { get; set; }
        public PictureBox PictureBox { get; set; }
        public Color Color { get; set; }
        public int LineWidth { get; set; }

        public abstract void DrawShape();
    }
}
