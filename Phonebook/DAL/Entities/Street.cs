using System.Collections.Generic;

namespace DAL.Entities
{
    public class Street
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Person> Persons { get; set; }
        public virtual int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
