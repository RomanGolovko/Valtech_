using DAL.Entities;
using System.Data.Entity;

namespace DAL.DB.Concrete.EF
{
    public class EfDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
