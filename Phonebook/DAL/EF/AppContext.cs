using System.Data.Entity;
using DAL.Entities;

namespace DAL.EF
{
    public class AppContext : DbContext
    {
        public AppContext() { }

        public AppContext(string connectionString) : base(connectionString) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Street> Streets { get; set; }
    }
}
