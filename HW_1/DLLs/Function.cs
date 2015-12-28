using System;

namespace DLLs
{
    public class Function
    {
        public string GetDayOfWeek(int num)
        {
            var result = "";

            switch (num)
            {
                case 1: result = "monday"; break;
                case 2: result = "tuesday"; break;
                case 3: result = "wednesday"; break;
                case 4: result = "thursday";break;
                case 5: result = "friday"; break;
                case 6: result = "saturday"; break;
                case 7: result = "sunday"; break;
                default: throw new ArgumentException();
            }

            return result;
        }

        public double GetDistance(double x1, double y1, double x2, double y2)
        {
            if (x1==x2 && y1==y2)
            {
                return 0;
            }
            var result = 0.0;

            result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            return result;
        }
    }
}
