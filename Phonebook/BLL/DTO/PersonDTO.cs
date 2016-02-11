using System.Collections.Generic;

namespace BLL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PhoneDTO> Phones { get; set; }

        public string UserId { get; set; }

        public int StreetId { get; set; }
        public StreetDTO Street { get; set; }
    }
}
