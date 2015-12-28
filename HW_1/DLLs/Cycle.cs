using System;

namespace DLLs
{
    public class Cycle
    {
        private int _count = 0;
        public int PositiveNumSum(ref int count)
        {
            var sum = 0;

            for (var i = 1; i < 100; i++)
            {
                if (i % 2 > 0) continue;

                sum += i;
                count++;
            }

            return sum;
        }

        public bool IsSimple(int num)
        {
            var result = false;

            if (num <= 0)
            {
                throw new ArgumentException();
            }
            else if (num == 1 || num == 2)
            {
                result = true;
            }
            else
            {
                var count = num - 1;
                while (count > 1)
                {
                    if (num % count == 0)
                    {
                        return false;
                    }
                    count--;
                }
                result = true;
            }

            return result;
        }

        public int GetSquareBySelection(int num)
        {
            if (num <= 0)
            {
                throw new ArgumentException();
            }

            var result = 0;
            while (true)
            {
                if (Math.Pow(result, 2) == num)
                {
                    return result;
                }

                if (Math.Pow(result, 2) > num)
                {
                    return result - 1;
                }
                result++;
            }
        }

        public int GetSquareByBinarySearch(int num)
        {
            if (num <= 0)
            {
                throw new ArgumentException();
            }

            var result = 0;
            do
            {
                result = num / 2;

            } while (Math.Pow(result, 2) > num);

            while (Math.Pow(result, 2) > num)
            {

                if (Math.Pow(result, 2) == num)
                {
                    return result;
                }

                if (Math.Pow(result, 2) > num)
                {
                    return result - 1;
                }
                result++;
            }

            return result;
        }

        public int GetFactorial(int num)
        {
            var result = 1;
            if (num <= 0)
            {
                throw new ArgumentException();
            }
            else if (num == 1 || num == 2)
            {
                result = num;
            }
            else
            {
                for (var i = num; i > 1; i--)
                {
                    result *= i;
                }
            }

            return result;
        }

        public int NumbersSum(int num)
        {
            if (Math.Abs(num / 10) < 0)
            {
                return num;
            }

            var count = num.ToString().ToCharArray().Length;
            var size = 1;

            for (var i = 1; i < count; i++)
            {
                size *= 10;
            }

            var result = 0;
            for (var i = 1; i <= size; size /= 10)
            {
                result += num / size;
                num = num % size;
            }

            return result;
        }

        public int ReverseNumber(int num)
        {
            if ((num / 10) <= 0)
            {
                return num;
            }

            var result = num.ToString();
            var temp = "";

            for (int i = result.Length - 1; i >= 0; i--)
            {
                temp += result[i];
            }


            return int.Parse(temp);
        }
    }
}
