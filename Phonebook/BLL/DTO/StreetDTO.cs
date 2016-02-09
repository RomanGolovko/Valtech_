using System.Collections.Generic;

namespace BLL.DTO
{
    public class StreetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public CityDTO City { get; set; }
        public List<PersonDTO> Persons { get; set; }
    }
}
