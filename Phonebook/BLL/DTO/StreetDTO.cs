using System.Collections.Generic;

namespace BLL.DTO
{
    public class StreetDTO
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public List<PersonDTO> Persons { get; set; }
    }
}
