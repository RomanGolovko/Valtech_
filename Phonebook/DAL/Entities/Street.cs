using System.Collections.Generic;

namespace DAL.Entities
{
    public class Street
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public List<Person> Persons { get; set; } 
    }
}
