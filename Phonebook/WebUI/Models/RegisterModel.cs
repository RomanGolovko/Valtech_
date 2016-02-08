using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}