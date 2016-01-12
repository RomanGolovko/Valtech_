using GenericDataStructures.Abstract;
using System;

namespace GenericDataStructures.Concrete
{
    public class AList1<T> : IMyList<T> where T : IComparable
    {
        private T[] _array;

        public int Top { get; private set; }

        public AList1()
        {
            Top = 3;
            _array = new T[10];
        }

        public AList1(T[] array)
        {
            Top = array.Length - 1;
            _array = (Size() > array.Length) ? new T[Size()] : new T[array.Length];

            for (var i = 0; i <= Top; i++)
            {
                _array[i] = array[i];
            }
        }

        public int Size()
        {
            return _array.Length;
        }

        public void Clear()
        {
            Top = -1;
            _array = new T[10];
        }

        public void Init(T[] array)
        {
            _array = new T[array.Length];

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

        public T[] ToArray()
        {
            if (_array.Length == 0)
            {
                return new T[0];
            }

            var temp = new T[Top + 1];

            for (var i = 0; i <= Top; i++)
            {
                temp[i] = _array[i];
            }

            return temp;
        }


        private T[] Resize()
        {
            var size = Convert.ToInt32(_array.Length + (_array.Length * 0.4));
            var newArray = new T[size];
            return newArray;
        }

        public void AddFirst(T value)
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

        public void Insert(T value, int index)
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
                AddLast(value);
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

        public void AddLast(T value)
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


        public T DelFirst()
        {
            T value;
            switch (Top)
            {
                case -1: throw new ArgumentNullException();
                case 0:
                    value = _array[0];
                    _array = new T[0];
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

        public T DelPosition(int position)
        {
            if (position < 0 || position > Top || Top == -1)
            {
                throw new IndexOutOfRangeException();
            }

            T value;
            switch (Top)
            {
                case -1: throw new ArgumentNullException();
                case 0:
                    value = _array[0];
                    _array = new T[0];
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

        public T DelLast()
        {
            T value;
            switch (Top)
            {
                case -1: throw new ArgumentNullException();
                case 0:
                    value = _array[0];
                    _array = new T[0];
                    break;
                default:
                    value = _array[Top];
                    _array[Top] = default(T);
                    break;
            }
            Top--;
            return value;
        }


        public T MinValue()
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
                        if (value.CompareTo(_array[i]) == 1)
                        {
                            value = _array[i];
                        }
                    }
                    return value;
            }
        }

        public T MaxValue()
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
                        if (value.CompareTo(_array[i]) < 1)
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
                        if (_array[i].CompareTo(result) == 1) continue;
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
                        if (_array[i].CompareTo(result) < 1) continue;
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
                    var temp = new T[Top + 1];
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


        public T Get(int index)
        {
            if ((index > Top || index < 0) || (Top == -1))
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public void Set(T value, int index)
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
                            if (_array[j].CompareTo(_array[j - 1]) == 1) continue;
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
