using System.Drawing;

namespace VectorDrawing_WinForm_.Util
{
    public class XData
    {
        public string Color { get; private set; }
        public int Width { get; private set; }
        public string Type { get; private set; }

        public void SetData(string color, int width, string type)
        {
            Color = color;
            Width = width;
            Type = type;
        }
    }
}
