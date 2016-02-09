using System.Collections.Generic;

namespace BLL.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryDTO Country { get; set; }
        public List<StreetDTO> Streets { get; set; }
    }
}
