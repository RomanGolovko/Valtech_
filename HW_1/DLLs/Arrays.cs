using System;
using System.Linq;

namespace DLLs
{
    public class Arrays
    {
        public int GetMinValue(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            var result = array[0];

            return array.Concat(new[] { result }).Min();
        }

        public int GetMaxValue(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array[0];
            }

            var result = array[0];

            return array.Concat(new[] { result }).Max();
        }

        public int GetMinValueIndex(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return 0;
            }

            var result = array[0];

            return Array.IndexOf(array, array.Concat(new[] { result }).Min());
        }

        public int GetMaxValueIndex(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return 0;
            }

            var result = array[0];

            return Array.IndexOf(array, array.Concat(new[] { result }).Max());
        }

        public int GetOddIndexValueSum(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return 0;
            }

            var result = 0;

            for (var i = 1; i < array.Length; i += 2)
            {
                result += array[i];
            }

            return result;
        }

        public int[] ArraysRevers(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array;
            }

            Array.Reverse(array, 0, array.Length);

            return array;
        }

        public int GetOddValueSum(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            return array.Where(x => x%2 != 0).Sum();
        }

        public int[] SwapArrayIndexValue(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }
            else if (array.Length == 1)
            {
                return array;
            }

            for (var i = 0; i < array.Length / 2; i++)
            {
                var index = (array.Length/2 == 0) ? array.Length/2 : array.Length/2 + 1;
                var temp = array[index + i];
                array[index + i] = array[i];
                array[i] = temp;
            }
            return array;
        }

        public int[] BubbleSort(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array;
            }

            for (var i = 0; i < array.Length; i++)
            { 
                for (var j = array.Length - 1; j > i; j--)
                {
                    if (array[j] >= array[j - 1]) continue;
                    var temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }

            return array;
        }

        public int[] SelectionSort(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array;
            }

            for (var i = 0; i < array.Length - 1; i++)
            {
                var min = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                var temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }

            return array;
        }

        public int[] InsertionSort(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            if (array.Length == 0)
            {
                throw new ArgumentException();
            }

            if (array.Length == 1)
            {
                return array;
            }

            for (var i = 0; i < array.Length; i++)
            {
                var temp = array[i];
                var j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = temp;
            }

            return array;
        }
    }
}
