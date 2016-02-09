using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class CityModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City")]
        [Range(2, 20, ErrorMessage = "This city name is incorrect")]
        public string Name { get; set; }

        public List<StreetModel> Streets { get; set; }
    }
}