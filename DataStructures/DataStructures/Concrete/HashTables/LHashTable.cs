using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Abstract;

namespace DataStructures.Concrete.HashTables
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class HashTableItem<T, V>
    {
        public T Key { get; private set; }
        public V Value { get; private set; }

        public HashTableItem(T key, V value)
        {
            Key = key;
            Value = value;
        }
    }

    public class LHashTable<TKey, TValue> : IHashTable
    {
        private LinkedList<HashTableItem<int, Person>>[] _array;
        private int _capacity;
        private const double LOAD_FACTOR = 0.75;

        public LHashTable()
        {
            _capacity = 10;
            _array = new LinkedList<HashTableItem<int, Person>>[_capacity];
        }

        public int Size { get; private set; }
       
        public void Clear()
        {
            Size = 0;
            _array = new LinkedList<HashTableItem<int, Person>>[_capacity];
        }

        private int Hash(int key)
        {
            return Math.Abs(key.GetHashCode()) % _capacity;
            // return ((Math.Abs(key.GetHashCode()) << 5) + 13) % Size;
            // return (int)Math.Floor(((Math.Abs(key.GetHashCode()) * 0.13) % 1) * Size);
        }

        private double GetLoadFactor()
        {
            return Size / _capacity;
        }

        private void Resize()
        {
            _capacity = _capacity * 2;
            var oldArr = _array;
            Size = 0;
            _array = new LinkedList<HashTableItem<int, Person>>[_capacity];

            foreach (var pair in oldArr.Where(item => item != null).SelectMany(item => item.Where(pair => pair != null)))
            {
                Add(pair.Key, pair.Value);
            }
        }

        public void Add(int key, Person val)
        {
            if (GetLoadFactor() >= LOAD_FACTOR)
            {
                Resize();
            }

            var index = Hash(key);

            if (_array[index] == null)
            {
                _array[index] = new LinkedList<HashTableItem<int, Person>>();
            }

            var hashTableItem = new HashTableItem<int, Person>(key, val);

            var listNode = new LinkedListNode<HashTableItem<int, Person>>(hashTableItem);

            _array[index].AddFirst(listNode);

            Size++;
        }

        public bool Del(int key)
        {
            if (Size <= 0)
            {
                throw new ArgumentNullException();
            }
            var index = Hash(key);
            if (_array[index] == null)
            {
                return false;
            }

            foreach (var item in _array[index].Where(item => item.Key.Equals(key)))
            {
                _array[index].Remove(item);
                break;
            }
            Size--;
            return true;
        }

        public Person Get(int key)
        {
            if (Size <= 0)
            {
                throw new ArgumentNullException();
            }

            var index = Hash(key);

            return _array[index] == null ? default(Person) : 
                _array[index].Where(item => item.Key.Equals(key)).Select(item => item.Value).FirstOrDefault();
        }

        public Person[] ToArray()
        {
            if (Size <= 0)
            {
                throw new ArgumentNullException();
            }

            var temp = new Person[Size];
            var i = 0;
            foreach (var item in _array)
            {
                if (item != null)
                {
                    temp[i++] = item.First.Value.Value;
                }
            }
            return temp;
        }
    }
}
