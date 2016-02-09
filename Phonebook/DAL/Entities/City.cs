using System.Collections.Generic;

namespace DAL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Street> Streets { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }
    }
}
