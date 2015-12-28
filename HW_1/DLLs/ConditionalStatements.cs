using System;

namespace DLLs
{
    public class ConditionalStatements
    {
        public int Even(int a, int b)
        {
            if (a == 0)
            {
                throw new ArgumentException();
            }

            var result = 0;
            result = ((a%2) == 0) ? a*b : a + b;

            return result;
        }

        public int FindQuarter(int x, int y)
        {
            if (x == 0 || y == 0)
            {
                throw new ArgumentException("The value is on the qaters border!!!");
            }

            var temp = 0;

            if (x > 0)
            {
                temp = (y > 0) ? 1 : 4;
            }
            else
            {
                temp = (y > 0) ? 2 : 3;
            }

            return temp;
        }

        public int PositiveValueSum(int num1, int num2, int num3)
        {
            var sum = 0;

            sum += (num1 > 0) ? num1 : 0;
            sum += (num2 > 0) ? num2 : 0;
            sum += (num3 > 0) ? num3 : 0;

            return sum;
        }

        public int MaxValue(int a, int b, int c)
        {
            var sum = 0;
            if (a == 0 && b == 0 && c == 0)
            {
                sum = 3;
            }
            else
            {
                sum = ((a + b + c) > (a * b * c)) ? (a + b + c) + 3 : (a * b * c) + 3;
            }

            return sum;
        }

        public string CheckMark(int rating)
        {
            if (rating < 0 || rating > 100)
            {
                throw new ArgumentException();
            }
            var mark = "";

            if (rating < 20)
            {
                mark = "F";
            }
            else if (rating >= 20 && rating < 40)
            {
                mark = "E";
            }
            else if (rating >= 40 && rating < 60)
            {
                mark = "D";
            }
            else if (rating >= 60 && rating < 75)
            {
                mark = "C";
            }
            else if (rating >= 75 && rating < 90)
            {
                mark = "B";
            }
            else if (rating >= 90 && rating <= 100)
            {
                mark = "A";
            }

            return mark;
        }
    }
}
