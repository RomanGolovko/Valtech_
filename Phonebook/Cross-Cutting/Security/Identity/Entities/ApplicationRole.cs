using Microsoft.AspNet.Identity.EntityFramework;

namespace Cross_Cutting.Security.Identity.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
