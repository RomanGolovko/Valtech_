using DataStructures.Concrete.HashTables;

namespace DataStructures.Abstract
{
    public interface IHashTable
    {
        int Size { get; }

        void Clear();
        void Add(int key, Person val);
        bool Del(int key);
        Person Get(int key);
        Person[] ToArray();
    }
}
