using DAL.Entities;
using System.Data.Entity;

namespace DAL.DB.Concrete
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("DefaultConnection") { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
