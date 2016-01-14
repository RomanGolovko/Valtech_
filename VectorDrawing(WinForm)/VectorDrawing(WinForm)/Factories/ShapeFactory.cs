using System.Windows.Forms;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Shapes.Concrete;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Factories
{
    public static class ShapeFactory
    {
        public static AShape GetShape(string type, Form main, PictureBox pctbx, XData data)
        {
            AShape shape = null;

            switch (type)
            {
                case "Rectangle":
                    shape = new Rectangle(main, pctbx, data);
                    break;
                case "Ellipse":
                    shape = new Ellipse(main, pctbx, data);
                    break;
                case "Line":
                    shape = new Line(main, pctbx, data);
                    break;
                default:
                    break;
            }

            return shape;
        }
    }
}
