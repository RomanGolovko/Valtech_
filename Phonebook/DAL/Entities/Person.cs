using System.Collections.Generic;

namespace DAL.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual List<Phone> Phones { get; set; }
        public virtual string UserId { get; set; }
        public virtual int StreetId { get; set; }
        public virtual Street Street { get; set; }
    }
}
