using System.Collections.Generic;

namespace DAL.Entities
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Persons { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}
