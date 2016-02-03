using System.Collections.Generic;

namespace DAL.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public virtual List<Phone> Phones { get; set; }
    }
}
