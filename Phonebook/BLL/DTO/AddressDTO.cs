using System.Collections.Generic;

namespace BLL.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public List<PhoneDTO> Phones { get; set; }
    }
}
