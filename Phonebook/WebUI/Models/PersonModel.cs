using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class PersonModel
    {
        [HiddenInput(DisplayValue = true)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = true)]
        public string ApplicationUserId { get; set; }

        [HiddenInput(DisplayValue = true)]
        public int StreetId { get; set; }

        [HiddenInput(DisplayValue = true)]
        public StreetModel Street { get; set; }

        [Required(ErrorMessage = "Please enter persons first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter persons last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter persons age")]
        [Range(1, 100, ErrorMessage = "This age is incorrect")]
        public int Age { get; set; }

        public List<PhoneModel> Phones { get; set; }
    }
}