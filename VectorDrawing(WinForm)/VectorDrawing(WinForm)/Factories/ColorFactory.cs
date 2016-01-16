using System.Drawing;

namespace VectorDrawing_WinForm_.Factories
{
    public static class ColorFactory
    {
        public static Color GetColorFromString(string color)
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

        public static int GetColorNum(Color color)
        {
            var numColor = 0;

            if (color == Color.Black)
            {
                numColor = 0;
            }
            else if (color == Color.Green)
            {
                numColor = 1;
            }
            else if (color == Color.Red)
            {
                numColor = 2;
            }

            return numColor;
        }

        public static Color GetColorFromNum(int color)
        {
            var value = default(Color);

            switch (color)
            {
                case 0:
                    value = Color.Black;
                    break;
                case 1:
                    value = Color.Green;
                    break;
                case 2:
                    value = Color.Red;
                    break;
                default:
                    break;
            }

            return value;
        }
    }
}
