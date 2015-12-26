using System;
using DataStructures.Abstract;

namespace DataStructures.Concrete.Arrays
{
    public class AListR : IList
    {
        private int[] _array;

        public int Begin { get; private set; }
        public int End { get; private set; }

        public AListR()
        {
            Begin = 25;
            End = 4;
            _array = new int[30];
            var j = 0;

            for (var i = Begin; i < _array.Length; i++)
            {
                _array[i] = ++j;
            }
            for (var i = 0; i <= End; i++)
            {
                _array[i] = ++j;
            }
        }

        public AListR(int[] array)
        {
            if (Size() > array.Length)
            {
                Begin = Size() - (array.Length / 2);
                End = array.Length / 2;
            }
            else
            {
                _array = array;
                Begin = 0;
                End = array.Length - 1;
            }

            var j = 0;
            for (var i = Begin; i < _array.Length; i++, j++)
            {
                _array[i] = array[j];
            }
            for (var i = 0; i <= End; i++, j++)
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
            Begin = End = 14;
            _array = new int[30];
        }

        public void Init(int[] array)
        {
            if (array.Length == 0)
            {
                _array = new int[0];
                Begin = 0;
                End = -1;
                return;
            }

            Begin = array.Length / 2;
            End = array.Length / 2 - 1;
            _array = new int[array.Length];

            var j = 0;
            for (var i = Begin; i < array.Length; i++, j++)
            {
                _array[i] = array[j];
            }
            for (var i = 0; i <= End; i++, j++)
            {
                _array[i] = array[j];
            }

        }

        public int[] ToArray()
        {
            var temp = new int[_array.Length - Begin + End];

            var j = 0;
            for (var i = Begin ; i < _array.Length; i++, j++)
            {
                temp[j] = _array[i];
            }
            for (var i = 0; i <= End; i++, j++)
            {
                temp[j] = _array[i];
            }

            return temp;
        }

        private int _tempBegin;
        private int _tempEnd;
        private int[] Resize(out int tempBegin, out int tempEnd)
        {
            var size = Convert.ToInt32(_array.Length + (_array.Length * 0.4));
            var newArray = new int[size];
            tempBegin = newArray.Length - (_array.Length / 2);
            tempEnd = _array.Length / 2 - 1;
            Begin = tempBegin;
            End = tempEnd;

            return newArray;
        }

        public void AddFirst(int value)
        {
            if (Begin <= End + 1)
            {
                var tempArray = Resize(out _tempBegin, out _tempEnd);

                for (int i = _tempBegin, j = Begin; j < _array.Length; i++, j++)
                {
                    tempArray[i] = _array[j];
                }

                for (var i = 0; i <= End; i++)
                {
                    tempArray[i] = _array[i];
                }
                _array = tempArray;
                Begin = _tempBegin;
                End = _tempEnd;
            }

            Begin--;
            _array[Begin] = value;
        }

        public void Insert(int value, int index)
        {
            if (index < Begin - 1 && index > End + 1)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == Begin - 1)
            {
                AddFirst(value);
            }
            else if (index == End + 1)
            {
                AddLast(index);
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

        public void AddLast(int value)
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


        public int DelFirst()
        {
            int value;
            switch (End - Begin)
            {
                case 0: throw new ArgumentNullException();
                case 1:
                    value = _array[0];
                    _array = new int[0];
                    break;
                default:
                    value = _array[Begin];
                    break;
            }
            Begin++;
            return value;
        }

        public int DelPosition(int position)
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

        public int DelLast()
        {
            if (End - Begin < 0)
            {
                throw new ArgumentNullException();
            }

            var value = _array[End];
            End--;
            return value;
        }


        public int MinValue()
        {
            switch (Begin - End)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return _array[0];
                default:
                    var value = _array[Begin];
                    for (var i = Begin; i < _array.Length; i++)
                    {
                        if (value > _array[i])
                        {
                            value = _array[i];
                        }
                    }
                    for (var i = 0; i <= End; i++)
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
            switch (Begin - End)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return _array[0];
                default:
                    var value = _array[Begin];
                    for (var i = Begin; i < _array.Length; i++)
                    {
                        if (value < _array[i])
                        {
                            value = _array[i];
                        }
                    }
                    for (var i = 0; i <= End; i++)
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
            switch (Begin - End)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return 0;
                default:
                    var index = Begin;
                    var result = _array[Begin];
                    for (var i = Begin; i < _array.Length; i++)
                    {
                        if (_array[i] >= result) continue;
                        result = _array[i];
                        index = i;
                    }
                    for (var i = 0; i <= _array.Length; i++)
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
            switch (Begin - End)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return 0;
                default:
                    var index = Begin;
                    var result = _array[Begin];
                    for (var i = Begin; i < _array.Length; i++)
                    {
                        if (_array[i] <= result) continue;
                        result = _array[i];
                        index = i;
                    }
                    for (var i = 0; i <= End; i++)
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
            switch (Begin - End)
            {
                case -1:
                    throw new ArgumentNullException();
                case 0:
                    return;
                default:
                    var temp = new int[Size()];
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
            switch (Begin - End)
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


        public int Get(int index)
        {
            if (index > End && index < Begin)
            {
                throw new IndexOutOfRangeException();
            }

            return _array[index];
        }

        public void Set(int value, int index)
        {
            if ((index > End && index < Begin) || Begin - End < 0)
            {
                throw new IndexOutOfRangeException();
            }

            _array[index] = value;
        }

        public void Sort()
        {
            if (Begin - End < 0)
            {
                throw new ArgumentNullException();
            }

            for (var i = Begin; i <= End; i++)
            {
                for (var j = End; j > i; j--)
                {
                    if (_array[j] >= _array[j - 1]) continue;
                    var temp = _array[j];
                    _array[j] = _array[j - 1];
                    _array[j - 1] = temp;
                }
            }
        }
    }
}
