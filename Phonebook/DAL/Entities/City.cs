using System.Collections.Generic;

namespace DAL.Entities
{
    public class City
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Street> Streets { get; set; }
        public virtual int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
