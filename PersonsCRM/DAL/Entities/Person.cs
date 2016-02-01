using System.Collections.Generic;

namespace DAL.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Age { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        //public List<Phone> Phones { get; set; }
    }
}
