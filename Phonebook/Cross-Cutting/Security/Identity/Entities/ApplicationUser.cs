using Microsoft.AspNet.Identity.EntityFramework;

namespace Cross_Cutting.Security.Identity.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public byte[] Image { get; set; }
    }
}
