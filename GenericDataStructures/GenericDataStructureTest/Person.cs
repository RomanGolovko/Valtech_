using System;

namespace GenericDataStructureTest
{
    public class Person : IComparable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            var temp = obj as Person;
            if (Id > temp.Id)
            {
                return 1;
            }
            else if (Id == temp.Id)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
