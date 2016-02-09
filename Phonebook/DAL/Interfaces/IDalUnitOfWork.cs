using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IDalUnitOfWork
    {
        IRepository<Person> Persons { get; }
        IRepository<Street> Streets { get; }
        IRepository<City> Cities { get; }
        IRepository<Country> Countries { get; }
    }
}
