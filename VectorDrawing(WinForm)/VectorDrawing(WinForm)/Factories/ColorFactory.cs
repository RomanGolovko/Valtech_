using System.Drawing;

namespace VectorDrawing_WinForm_.Factories
{
    public static class ColorFactory
    {
        public static Color GetColor(string color)
        {
            var value = Color.Black;

            switch (color)
            {
                case "Black":
                    value = Color.Black;
                    break;
                case "Green":
                    value = Color.Green;
                    break;
                case "Red":
                    value = Color.Red;
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}
