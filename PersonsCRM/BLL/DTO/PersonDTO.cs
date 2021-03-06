﻿using System.Collections.Generic;

namespace BLL.DTO
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<PhoneDTO> Phones { get; set; }
    }
}
