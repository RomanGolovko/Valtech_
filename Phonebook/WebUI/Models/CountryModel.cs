using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class CountryModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter street name")]
        [Display(Name = "Country")]
        public string Name { get; set; }

        public List<CityModel> Cities { get; set; }
    }
}