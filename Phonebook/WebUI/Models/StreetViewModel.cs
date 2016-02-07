using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class StreetViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }


        public string StreetName { get; set; }
        public List<PersonViewModel> Persons { get; set; }
    }
}