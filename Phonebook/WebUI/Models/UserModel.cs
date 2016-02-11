using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class UserModel
    {
        [HiddenInput(DisplayValue = true)]
        public string Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int Age { get; set; }
        public byte[] Image { get; set; }
    }
}