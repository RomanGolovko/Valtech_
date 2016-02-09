using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionstring) : base(connectionstring) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
