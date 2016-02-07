using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class PersonViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter persons first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter persons last name")]
        public string LastName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int? StreetId { get; set; }
        public List<PhoneViewModel> Phones { get; set; }
    }
}