using DAL.Entities;

namespace DAL.DB.Abstract
{
    public interface IUnitOfWork
    {
        IRepository<Person> Persons { get; }
        IRepository<Phone> Phones { get; }
    }
}
