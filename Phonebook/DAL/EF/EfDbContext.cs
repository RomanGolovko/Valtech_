using System.Data.Entity;
using DAL.Entities;
using System.Data.Entity.Infrastructure;
using DAL.EF;

namespace DAL.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionString) : base(connectionString) { }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Street> Streets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}