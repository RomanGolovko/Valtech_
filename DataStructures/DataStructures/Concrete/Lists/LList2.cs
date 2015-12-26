using System;
using DataStructures.Abstract;

namespace DataStructures.Concrete.Lists
{
    public class Node2
    {
        public int Value { get; set; }
        public Node2 Next { get; set; }
        public Node2 Previous { get; set; }

        public Node2(int value)
        {
            Value = value;
        }
    }

    public class LList2 : IList
    {
        private Node2 _head;
        private Node2 _tail;

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
            _tail = null;
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
            _head = new Node2(value) { Next = _head, Previous = null};
            if (Size() == 1)
            {
                _tail = _head;
            }
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
                AddLast(value);
            }
            else
            {
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
        }

        public void AddLast(int value)
        {
            var node = new Node2(value);

            if (Size() == 0)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
        }


        public int DelFirst()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = _head.Value;
            _head = _head.Next;

            if (Size() == 0)
            {
                _tail = null;
            }
            else
            {
                _head.Previous = null;
            }

            return value;
        }

        public int DelPosition(int position)
        {
            if (position <= 0 || position > Size() || Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = 0;
            if (Size() == 1)
            {
                value = _head.Value;
            }
            else
            {
                Node2 previous = null;
                var current = _head;
                var index = 0;

                while (current != null)
                {
                    if (index == position)
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                            {
                                _tail = previous;
                            }
                        }
                        else
                        {
                            _head = _head.Next;

                            if (_head == null)
                            {
                                _tail = null;
                            }
                        }

                        value = current.Value;
                    }
                    previous = current;
                    current = current.Next;
                    index++;
                }
            }
            return value;
        }

        public int DelLast()
        {
            if (Size() == 0)
            {
                throw new IndexOutOfRangeException();
            }

            var value = _tail.Value;
            if (Size() == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                _tail.Previous.Next = null;
                _tail = _tail.Previous;
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
