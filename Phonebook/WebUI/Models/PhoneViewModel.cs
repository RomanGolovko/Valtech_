using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class PhoneViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string Number { get; set; }

        public string Type { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int PersonId { get; set; }
    }
}