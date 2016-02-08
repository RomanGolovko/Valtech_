using Microsoft.AspNet.Identity.EntityFramework;

namespace Cross_Cutting.Security.Identity.Entities
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext() : base("PhonebookDB") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
