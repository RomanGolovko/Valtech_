using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class CityModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CountryId { get; set; }

        [HiddenInput(DisplayValue = false)]
        public CountryModel Country { get; set; }

        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City")]
        public string Name { get; set; }

        public List<StreetModel> Streets { get; set; }
    }
}