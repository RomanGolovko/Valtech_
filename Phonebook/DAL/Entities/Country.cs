using System.Collections.Generic;

namespace DAL.Entities
{
    public class Country
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual List<City> Cities { get; set; }
    }
}
