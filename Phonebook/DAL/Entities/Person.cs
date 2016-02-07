using System.Collections.Generic;

namespace DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Phone> Phones { get; set; }

        public int? StreetId { get; set; }
        public Street Street { get; set; }
    }
}
