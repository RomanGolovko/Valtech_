using System.Drawing;

namespace VectorDrawing_WinForm_.Shapes
{
    public class XData
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public Color Color { get; private set; }
        public string Type { get; private set; }
        public int LineWidth { get; private set; }

        public XData SetData(int x, int y, int width, int height, Color color, int lineWidth, string type)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Color = color;
            LineWidth = lineWidth;
            Type = type;

            return this;
        }
    }
}
