using System.Collections.Generic;

namespace DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }
}
