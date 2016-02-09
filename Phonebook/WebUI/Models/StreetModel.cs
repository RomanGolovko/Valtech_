using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class StreetModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CityId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public CityModel City { get; set; }

        [Required(ErrorMessage = "Please enter street name")]
        [Display(Name = "Street")]
        [Range(2, 20, ErrorMessage = "This street name is incorrect")]
        public string Name { get; set; }

        public List<PersonModel> Persons { get; set; }
    }
}