using GenericDataStructures.Abstract;
using System;
using System.Linq;

namespace GenericDataStructures.Concrete
{
    public class AList0<T> : IMyList<T> where T : IComparable
    {
        private T[] _array;

        public AList0()
        {
            _array = new T[0];
        }

        public int Size()
        {
            return _array.Length;
        }

        public void Clear()
        {
            _array = new T[0];
        }

        public void Init(T[] array)
        {
            _array = new T[array.Length];

            if (array.Length == 0) return;

            for (var i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
        }

        public T[] ToArray()
        {
            return _array;
        }


        private T[] Resize()
        {
            var newArray = new T[_array.Length + 1];
            return newArray;
        }

        public void AddFirst(T value)
        {
            var temp = Resize();

            for (var i = 0; i < _array.Length; i++)
            {
                temp[i + 1] = _array[i];
            }

            temp[0] = value;

            _array = temp;
        }

        public void Insert(T value, int index)
        {
            if (index >= _array.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var temp = Resize();
            temp[index] = value;

            for (var i = 0; i < _array.Length; i++)
            {
                if (i < index)
                {
                    temp[i] = _array[i];
                }
                else
                {
                    temp[i + 1] = _array[i];
                }
            }

            _array = temp;
        }

        public void AddLast(T value)
        {
            var temp = Resize();

            for (var i = 0; i < _array.Length; i++)
            {
                temp[i] = _array[i];
            }

            temp[_array.Length] = value;

            _array = temp;
        }


        public T DelFirst()
        {
            T value;
            switch (Size())
            {
                case 0: throw new ArgumentNullException();
                case 1:
                    value = _array[0];
                    _array = new T[0];
                    break;
                default:
                    value = _array[0];
                    var temp = new T[Size() - 1];
                    for (var i = 0; i < temp.Length; i++)
                    {
                        temp[i] = _array[i + 1];
                    }
                    _array = temp;
                    break;
            }
            return value;
        }

        public T DelPosition(int position)
        {
            if (position <= 0 || position > Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            T value;
            switch (Size())
            {
                case 0: throw new ArgumentNullException();
                case 1:
                    value = _array[0];
                    _array = new T[0];
                    break;
                default:
                    value = _array[0];
                    var temp = new T[Size() - 1];
                    for (var i = 0; i < Size(); i++)
                    {
                        if (i < position)
                        {
                            temp[i] = _array[i];
                        }
                        else if (i == position)
                        {
                            value = _array[i];
                        }
                        else
                        {
                            temp[i - 1] = _array[i];
                        }
                    }
                    _array = temp;
                    break;
            }
            return value;
        }

        public T DelLast()
        {
            T value;
            switch (Size())
            {
                case 0: throw new ArgumentNullException();
                case 1:
                    value = _array[0];
                    _array = new T[0];
                    break;
                default:
                    value = _array[0];
                    var temp = new T[Size() - 1];
                    for (var i = 0; i < temp.Length; i++)
                    {
                        temp[i] = _array[i];
                    }
                    _array = temp;
                    break;
            }
            return value;
        }


        public T MinValue()
        {
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return _array[0];
                default:
                    var value = _array[0];
                    value = _array.Concat(new[] { value }).Min();
                    return value;
            }
        }

        public T MaxValue()
        {
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return _array[0];
                default:
                    var value = _array[0];
                    value = _array.Concat(new[] { value }).Max();
                    return value;
            }

        }


        public int MinValueIndex()
        {
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return 0;
                default:
                    var index = 0;
                    var result = _array[0];
                    for (var i = 0; i < _array.Length; i++)
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
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return 0;
                default:
                    var index = 0;
                    var result = _array[0];
                    for (var i = 0; i < _array.Length; i++)
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
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return;
                default:
                    var temp = new T[_array.Length];
                    for (var i = 0; i < _array.Length; i++)
                    {
                        temp[i] = _array[(_array.Length - 1) - i];
                    }
                    _array = temp;
                    break;
            }
        }

        public void HalfReverse()
        {
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return;
                default:
                    var index = _array.Length % 2 == 0 ? _array.Length / 2 : _array.Length / 2 + 1;
                    for (var i = 0; i < _array.Length / 2; i++)
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
            if ((index >= _array.Length || index < 0) || (_array.Length == 0))
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public void Set(T value, int index)
        {
            if ((index >= _array.Length || index < 0) || (_array.Length == 0))
            {
                throw new IndexOutOfRangeException();
            }

            _array[index] = value;
        }


        public void Sort()
        {
            switch (_array.Length)
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return;
                default:
                    for (var i = 0; i < _array.Length; i++)
                    {
                        for (var j = _array.Length - 1; j > i; j--)
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
