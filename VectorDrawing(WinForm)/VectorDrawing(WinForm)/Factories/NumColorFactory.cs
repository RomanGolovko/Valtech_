using System.Drawing;

namespace VectorDrawing_WinForm_.Factories
{
    public static class NumColorFactory
    {
        public static int GetColor(Color color)
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
    }
}
