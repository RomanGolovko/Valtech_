using System.Collections.Generic;

namespace BLL.DTO
{
    public class CountryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityDTO> Cities { get; set; }
    }
}
