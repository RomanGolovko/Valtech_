using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IDalUnitOfWork
    {
        IRepository<Person> Persons { get; }
        IRepository<Phone> Phones { get; }
        IRepository<Street> Streets { get; }   
    }
}
