using System;
using DataStructures.Abstract;

namespace DataStructures.Concrete.Lists
{
    public class Node1
    {
        public int Value { get; set; }
        public Node1 Next { get; set; }

        public Node1(int value)
        {
            Value = value;
        }
    }

    public class LList1 : IList
    {
        private Node1 _head;

        public int Size()
        {
            var index = 0;
            var current = _head;
            while (current != null)
            {
                index++;
                current = current.Next;
            }
            return index;
        }

        public void Clear()
        {
            _head = null;
        }

        public void Init(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException();
            }

            for (var i = array.Length - 1; i >= 0; i--)
            {
                AddFirst(array[i]);
            }
        }

        public int[] ToArray()
        {
            if (Size() == 0)
            {
                throw new ArgumentNullException();
            }

            var array = new int[Size()];
            var index = 0;
            var current = _head;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.Next;
            }

            return array;
        }


        public void AddFirst(int value)
        {
            _head = new Node1(value) { Next = _head };
        }

        public void Insert(int value, int index)
        {
            if (index > Size() || index < 0 || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Size())
            {
                AddLast(index);
            }
            else
            {
                var loop = 0;
                var current = _head;

                while (current != null)
                {
                    if (loop == index)
                    {
                        current.Next = current;
                        current.Value = value;
                        break;
                    }
                    loop++;
                    current = current.Next;
                }
            }
        }

        public void AddLast(int value)
        {
            var node = new Node1(value);
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                var current = _head;
                while (current != null)
                {
                    current = current.Next;
                }

                current.Next = node;
            }
        }


        public int DelFirst()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = _head.Value;
            _head = _head.Next;

            return value;
        }

        public int DelPosition(int position)
        {
            if (position <= 0 || position > Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = 0;
            var index = 0;
            Node1 previous = null;
            var current = _head;

            while (current != null)
            {
                if (index == position)
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                    }
                    else
                    {
                        _head = _head.Next;
                    }

                    value = current.Value;
                }
                previous = current;
                current = current.Next;
                index++;
            }

            return value;
        }

        public int DelLast()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = 0;
            var current = _head;

            while (current != null)
            {
                if (current.Next == null)
                {
                    value = current.Value;
                }

                current = current.Next;
            }

            return value;
        }


        public int MinValue()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return _head.Value;
                default:
                    var current = _head;
                    var value = current.Value;

                    while (current != null)
                    {
                        if (value > current.Value)
                        {
                            value = current.Value;
                        }
                        current = current.Next;
                    }
                    return value;
            }
        }

        public int MaxValue()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return _head.Value;
                default:
                    var current = _head;
                    var value = _head.Value;

                    while (current != null)
                    {
                        if (value < current.Value)
                        {
                            value = current.Value;
                        }
                        current = current.Next;
                    }
                    return value;
            }
        }


        public int MinValueIndex()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return 0;
                default:
                    var index = 0;
                    var loop = 0;
                    var current = _head;
                    var value = current.Value;

                    while (current != null)
                    {
                        if (value > current.Value)
                        {
                            value = current.Value;
                            index = loop;
                        }
                        loop++;
                        current = current.Next;
                    }
                    return index;
            }
        }

        public int MaxValueIndex()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return 0;
                default:
                    var index = 0;
                    var loop = 0;
                    var current = _head;
                    var value = current.Value;

                    while (current != null)
                    {
                        if (value < current.Value)
                        {
                            value = current.Value;
                            index = loop;
                        }
                        loop++;
                        current = current.Next;
                    }

                    return index;
            }
        }


        public void Reverse()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return;
                default:
                    var array = ToArray();
                    var temp = new int[array.Length];

                    for (var i = 0; i < array.Length; i++)
                    {
                        temp[i] = array[(array.Length - 1) - i];
                    }

                    Init(temp);
                    break;
            }
        }

        public void HalfReverse()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return;
                default:
                    var array = ToArray();
                    var index = (Size() % 2 == 0) ? Size() / 2 : Size() / 2 + 1;

                    for (var i = 0; i < Size() / 2; i++)
                    {
                        var temp = array[index + i];
                        array[index + i] = array[i];
                        array[i] = temp;
                    }

                    Init(array);
                    break;
            }
        }


        public int Get(int index)
        {
            if (index > Size() || index < 0 || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var loop = 0;
            var current = _head;
            var value = 0;

            while (current != null)
            {
                if (loop == index)
                {
                    value = current.Value;
                    break;
                }

                loop++;
                current = current.Next;
            }
            return value;
        }

        public void Set(int value, int index)
        {
            if (index > Size() || index < 0 || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var loop = 0;
            var current = _head;

            while (current != null)
            {
                if (loop == index)
                {
                    current.Value = value;
                    break;
                }

                loop++;
                current = current.Next;
            }
        }

        public void Sort()
        {
            switch (Size())
            {
                case 0:
                    throw new ArgumentNullException();
                case 1:
                    return;
                default:
                    var array = ToArray();

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

                    Init(array);
                    break;
            }
        }
    }
}
