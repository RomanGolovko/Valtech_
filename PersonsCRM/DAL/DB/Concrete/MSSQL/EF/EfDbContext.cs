using DAL.Entities;
using System.Data.Entity;

namespace DAL.DB.Concrete.MSSQL.EF
{
    public class EfDbContext : DbContext
    {
        public EfDbContext() : base("PersonsDB") { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
