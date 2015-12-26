using System;
using DataStructures.Abstract;

namespace DataStructures.Concrete.HashTables
{
    public class AHashTable : IHashTable
    {
        private Person[] _array;
        private int _capacity;
        private const double LOAD_FACTOR = 0.75;

        public AHashTable()
        {
            _capacity = 997;
            _array = new Person[_capacity];
        }

        public int Size { get; private set; }

        public void Clear()
        {
            Size = 0;
            _array = new Person[_capacity];
        }

        private int Hash(int key)
        {
            return Math.Abs(key.GetHashCode()) % _capacity;
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
            _array = new Person[_capacity];
            var i = 0;

            foreach (var item in oldArr)
            {
                if (item != null)
                {
                    _array[i] = item;
                }
                i++;
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
                _array[index] = val;
            }
            else
            {
                _array[index + 13] = val;
            }

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

            while (_array[index].Id != key)
            {
                index += 13;
            }

            _array[index] = null;
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
            if (_array[index] == null)
            {
                return null;
            }

            while (_array[index].Id != key)
            {
                index += 13;
            }

            return _array[index];
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
                    temp[i++] = item;
                }
            }
            return temp;
        }
    }
}
