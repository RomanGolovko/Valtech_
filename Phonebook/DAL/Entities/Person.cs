using System.Collections.Generic;
using Cross_Cutting.Security.Identity.Entities;

namespace DAL.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Phone> Phones { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int? StreetId { get; set; }
        public Street Street { get; set; }
    }
}
