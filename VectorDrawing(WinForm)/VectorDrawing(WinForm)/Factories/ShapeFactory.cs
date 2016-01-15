using System.Windows.Forms;
using VectorDrawing_WinForm_.Shapes.Abstract;
using VectorDrawing_WinForm_.Shapes.Concrete;
using VectorDrawing_WinForm_.Util;

namespace VectorDrawing_WinForm_.Factories
{
    public static class ShapeFactory
    {
        public static AShape GetShape(string type, Form main, XData data)
        {
            AShape shape = null;

            switch (type)
            {
                case "Rectangle":
                    shape = new Rectangle(main, data);
                    break;
                case "Ellipse":
                    shape = new Ellipse(main, data);
                    break;
                case "Line":
                    shape = new Line(main, data);
                    break;
                default:
                    break;
            }

            return shape;
        }
    }
}
