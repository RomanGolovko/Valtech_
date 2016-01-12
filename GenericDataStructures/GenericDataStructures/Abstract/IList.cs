using System;

namespace GenericDataStructures.Abstract
{
    public interface IMyList<T>
    {
        int Size();

        void Clear();
        void Init(T[] array);
        T[] ToArray();

        void AddFirst(T value);
        void Insert(T value, int index);
        void AddLast(T value);


        T DelFirst();
        T DelPosition(int position);
        T DelLast();


        T MinValue();
        T MaxValue();

        int MinValueIndex();
        int MaxValueIndex();

        void Reverse();
        void HalfReverse();

        T Get(int index);
        void Set(T value, int index);

        void Sort();
    }
}
