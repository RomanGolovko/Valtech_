namespace DataStructures.Abstract
{
    public interface IList
    {
        int Size();

        void Clear();
        void Init(int[] array);
        int[] ToArray();

        void AddFirst(int value);
        void Insert(int value, int index);
        void AddLast(int value);


        int DelFirst();
        int DelPosition(int position);
        int DelLast();


        int MinValue();
        int MaxValue();

        int MinValueIndex();
        int MaxValueIndex();

        void Reverse();
        void HalfReverse();

        int Get(int index);
        void Set(int value, int index);

        void Sort();
    }
}
