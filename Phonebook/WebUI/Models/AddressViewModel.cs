using System.Collections.Generic;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class AddressViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Street { get; set; }
        public List<PhoneViewModel> Phones { get; set; }
    }
}