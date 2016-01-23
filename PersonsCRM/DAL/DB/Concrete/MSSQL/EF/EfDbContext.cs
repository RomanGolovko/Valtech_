using System.Data.Entity;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.EF
{
    public class EfDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
