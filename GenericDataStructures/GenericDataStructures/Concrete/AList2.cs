using GenericDataStructures.Abstract;
using System;

namespace GenericDataStructures.Concrete
{
    public class AList2<T> : IMyList<T> where T : IComparable
    {
        private T[] _array;

        public int Begin { get; private set; }
        public int End { get; private set; }

        public AList2()
        {
            Begin = 9;
            End = 19;
            _array = new T[30];
        }

        public AList2(T[] array)
        {
            if (Size() > array.Length)
            {
                Begin = (Size() / 2) - (array.Length / 2);
                End = Begin + array.Length;
            }
            else
            {
                Begin = 0;
                End = array.Length - 1;
            }

            for (int i = Begin, j = 0; i <= End; i++, j++)
            {
                _array[i] = array[j];
            }
        }


        public int Size()
        {
            return _array.Length;
        }

        public void Clear()
        {
            Begin = End = 9;
            _array = new T[30];
        }

        public void Init(T[] array)
        {
            if (array.Length == 0)
            {
                _array = new T[0];
                Begin = 0;
                End = -1;
                return;
            }

            Begin = 0;
            End = array.Length - 1;
            _array = new T[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
        }

        public T[] ToArray()
        {
            var temp = new T[(End - Begin) + 1];

            for (int i = Begin, j = 0; i <= End; i++, j++)
            {
                temp[j] = _array[i];
            }

            return temp;
        }

        private int _tempBegin;
        private int _tempEnd;
        private T[] Resize(out int tempBegin, out int tempEnd)
        {
            var size = Convert.ToInt32(_array.Length + (_array.Length * 0.4));
            var newArray = new T[size];
            tempBegin = (newArray.Length / 2) - ((End - Begin) / 2);
            tempEnd = tempBegin + (End - Begin);
            Begin = tempBegin;
            End = tempEnd;

            return newArray;
        }

        public void AddFirst(T value)
        {
            if (Begin > 0)
            {
                Begin--;
                _array[Begin] = value;
            }
            else
            {
                var tempArray = Resize(out _tempBegin, out _tempEnd);

                for (int i = _tempBegin, j = Begin; i < _tempEnd; i++, j++)
                {
                    tempArray[i] = _array[j];
                }
                _tempBegin--;
                tempArray[_tempBegin] = value;

                _array = tempArray;
                Begin = _tempBegin;
                End = _tempEnd;
            }
        }

        public void Insert(T value, int index)  
        {
            if (index < Begin - 1 || index > End + 1)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == Begin - 1)
            {
                AddFirst(value);
            }
            else if (index == End + 1)
            {
                AddLast(value);
            }
            else
            {
                if (0 < Begin || End < _array.Length - 1)
                {
                    End++;
                    for (var i = End; i > index; i--)
                    {
                        _array[i] = _array[i - 1];
                    }
                    _array[index] = value;
                }
                else
                {
                    var temp = Resize(out _tempBegin, out _tempEnd);
                    End++;

                    for (int i = Begin, j = 0; i < End; i++, j++)
                    {
                        if (i < index)
                        {
                            temp[i] = _array[j];
                        }
                        else if (i > index)
                        {
                            temp[i] = _array[j];
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
            if (End < _array.Length - 1)
            {
                End++;
                _array[End] = value;
            }
            else
            {
                var tempArray = Resize(out _tempBegin, out _tempEnd);

                for (int i = _tempBegin, j = Begin; i < _tempEnd; i++, j++)
                {
                    tempArray[i] = _array[j];
                }
                tempArray[_tempEnd] = value;
                _tempEnd++;

                _array = tempArray;
                Begin = _tempBegin;
                End = _tempEnd;
            }
        }


        public T DelFirst()
        {
            T value;
            switch (End - Begin)
            {
                case 0: throw new ArgumentNullException();
                case 1:
                    value = _array[0];
                    _array = new T[0];
                    break;
                default:
                    value = _array[Begin];
                    break;
            }
            Begin++;
            return value;
        }

        public T DelPosition(int position)
        {
            if (position < Begin || position > End || End - Begin < 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = _array[position];
            for (var i = position + 1; i < End; i++)
            {
                _array[i] = _array[i + 1];
            }
            End--;
            return value;
        }

        public T DelLast()
        {
            if (End - Begin < 0)
            {
                throw new ArgumentNullException();
            }

            var value = _array[End];
            End--;
            return value;
        }


        public T MinValue()
        {
            switch (End - Begin)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return _array[0];
                default:
                    var value = _array[Begin];
                    for (var i = Begin; i <= End; i++)
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
            switch (End - Begin)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return _array[0];
                default:
                    var value = _array[Begin];
                    for (var i = Begin; i <= End; i++)
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
            switch (End - Begin)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return 0;
                default:
                    var index = Begin;
                    var result = _array[Begin];
                    for (var i = Begin; i <= End; i++)
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
            switch (End - Begin)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return 0;
                default:
                    var index = Begin;
                    var result = _array[Begin];
                    for (var i = Begin; i <= End; i++)
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
            switch (End - Begin)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return;
                default:
                    var temp = new T[Size()];
                    for (var i = Begin; i <= End; i++)
                    {
                        temp[i] = _array[(Size() - 1) - i];
                    }
                    _array = temp;
                    break;
            }
        }

        public void HalfReverse()
        {
            switch (End - Begin)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return;
                default:
                    var index = (End - Begin + 1) % 2 == 0 ? (End + 1) / 2 : (End + 1) / 2 + 1;
                    for (var i = Begin; i < (End + 1) / 2; i++)
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
            if (index > End || index < Begin)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public void Set(T value, int index)
        {
            if (index > End || index < Begin || End - Begin < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[index] = value;
        }

        public void Sort()
        {
            if (End - Begin < 0)
            {
                throw new ArgumentNullException();
            }

            for (var i = Begin; i <= End; i++)
            {
                for (var j = End; j > i; j--)
                {
                    if (_array[j].CompareTo(_array[j - 1]) == 1) continue;
                    var temp = _array[j];
                    _array[j] = _array[j - 1];
                    _array[j - 1] = temp;
                }
            }
        }
    }
}
