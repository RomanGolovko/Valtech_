using System;
using DataStructures.Abstract;

namespace DataStructures.Concrete.Arrays
{
    public class AList1 : IList
    {
        private int[] _array;

        public int Top { get; private set; }

        public AList1()
        {
            Top = 3;
            _array = new int[10];

            for (var i = 0; i <= Top; i++)
            {
                _array[i] = i + 1;
            }
        }

        public AList1(int[] array)
        {
            Top = array.Length - 1;
           _array = (Size() > array.Length) ? new int[Size()] : new int[array.Length];

            for (var i = 0; i <= Top; i++)
            {
                _array[i] = array[i];
            }
        }

        public int Size ()
        {
            return _array.Length;
        }

        public void Clear()
        {
            Top = -1;
            _array = new int[10];
        }

        public void Init(int[] array)
        {
            _array = new int[array.Length];

            if (array.Length == 0)
            {
                Top = -1;
                return;
            }

            Top = _array.Length - 1;

            for (var i = 0; i <= Top; i++)
            {
                _array[i] = array[i];
            }
        }

        public int[] ToArray()
        {
            if (_array.Length == 0)
            {
                return new int[0];
            }

            var temp = new int[Top + 1];

            for (var i = 0; i <= Top; i++)
            {
                temp[i] = _array[i];
            }

            return temp;
        }


        private int[] Resize()
        {
            var size = Convert.ToInt32(_array.Length + (_array.Length * 0.4));
            var newArray = new int[size];
            return newArray;
        }

        public void AddFirst(int value)
        {
            if (Top < _array.Length - 1)
            {
                Top++;
                for (var i = Top; i > 0; i--)
                {
                    _array[i] = _array[i - 1];
                }
                _array[0] = value;
            }
            else
            {
                var temp = Resize();

                for (var i = 0; i <= Top; i++)
                {
                    temp[i + 1] = _array[i];
                }

                Top++;
                temp[0] = value;
                _array = temp;
            }
        }

        public void Insert(int value, int index)
        {
            if ((index > Top || index < 0) || (Top == -1))
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Top + 1)
            {
                AddLast(index);
            }
            else
            {
                if (Top < _array.Length - 1)
                {
                    Top++;
                    for (var i = Top; i > index; i--)
                    {
                        _array[i] = _array[i - 1];
                    }
                    _array[index] = value;
                }
                else
                {
                    var temp = Resize();
                    Top++;

                    for (var i = 0; i <= Top; i++)
                    {
                        if (i < index)
                        {
                            temp[i] = _array[i];
                        }
                        else if (i > index)
                        {
                            temp[i] = _array[i - 1];
                        }
                        else
                        {
                            temp[i] = value;
                        }
                    }
                    _array = temp;
                }
            }
        }

        public void AddLast(int value)
        {
            if (Top < _array.Length - 1)
            {
                Top++;
                _array[Top] = value;
            }
            else
            {
                var temp = Resize();

                for (var i = 0; i <= Top; i++)
                {
                    temp[i] = _array[i];
                }

                Top++;
                temp[Top] = value;
                _array = temp;
            }
        }


        public int DelFirst()
        {
            var value = 0;
            switch (Top)
            {
                case -1: throw new ArgumentNullException();
                case 0:
                    value = _array[0];
                    _array = new int[0];
                    break;
                default:
                    value = _array[0];
                    for (var i = 0; i < Top; i++)
                    {
                        _array[i] = _array[i + 1];
                    }
                    break;
            }
            Top--;
            return value;
        }

        public int DelPosition(int position)
        {
            if (position < 0 || position > Top || Top == -1)
            {
                throw new IndexOutOfRangeException();
            }

            var value = 0;
            switch (Top)
            {
                case -1: throw new ArgumentNullException();
                case 0:
                    value = _array[0];
                    _array = new int[0];
                    break;
                default:
                    value = _array[position];
                    for (var i = position + 1; i < Top; i++)
                    {
                            _array[i] = _array[i + 1];
                    }
                    break;
            }
            Top--;
            return value;
        }

        public int DelLast()
        {
            var value = 0;
            switch (Top)
            {
                case -1: throw new ArgumentNullException();
                case 0:
                    value = _array[0];
                    _array = new int[0];
                    break;
                default:
                    value = _array[Top];
                    _array[Top] = 0;
                    break;
            }
            Top--;
            return value;
        }


        public int MinValue()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return _array[0];
                default:
                    var value = _array[0];
                    for (var i = 0; i <= Top; i++)
                    {
                        if (value > _array[i])
                        {
                            value = _array[i];
                        }
                    }
                    return value;
            }

        }

        public int MaxValue()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return _array[0];
                default:
                    var value = _array[0];
                    for (var i = 0; i <= Top; i++)
                    {
                        if (value < _array[i])
                        {
                            value = _array[i];
                        }
                    }
                    return value;
            }

        }


        public int MinValueIndex()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return 0;
                default:
                    var index = 0;
                    var result = _array[0];
                    for (var i = 0; i <= Top; i++)
                    {
                        if (_array[i] >= result) continue;
                        result = _array[i];
                        index = i;
                    }
                    return index;
            }
        }

        public int MaxValueIndex()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return 0;
                default:
                    var index = 0;
                    var result = _array[0];
                    for (var i = 0; i <= Top; i++)
                    {
                        if (_array[i] <= result) continue;
                        result = _array[i];
                        index = i;
                    }
                    return index;
            }
        }


        public void Reverse()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return;
                default:
                    var temp = new int[Top + 1];
                    for (var i = 0; i <= Top; i++)
                    {
                        temp[i] = _array[Top - i];
                    }
                    _array = temp;
                    break;
            }
        }

        public void HalfReverse()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return;
                default:
                    var index = ((Top + 1) % 2 == 0) ? (Top + 1) / 2 : (Top + 1) / 2 + 1;
                    for (var i = 0; i < (Top + 1) / 2; i++)
                    {
                        var temp = _array[index + i];
                        _array[index + i] = _array[i];
                        _array[i] = temp;
                    }
                    break;
            }
        }


        public int Get(int index)
        {
            if ((index > Top || index < 0) || (Top == -1))
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public void Set(int value, int index)
        {
            if (index > Top || index < 0 || Top == -1)
            {
                throw new IndexOutOfRangeException();
            }

            _array[index] = value;
        }

        public void Sort()
        {
            switch (Top)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return;
                default:
                    for (var i = 0; i <= Top; i++)
                    {
                        for (var j = Top; j > i; j--)
                        {
                            if (_array[j] >= _array[j - 1]) continue;
                            var temp = _array[j];
                            _array[j] = _array[j - 1];
                            _array[j - 1] = temp;
                        }
                    }
                    break;
            }
        }
    }
}
