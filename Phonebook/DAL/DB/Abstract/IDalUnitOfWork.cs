using DAL.Entities;

namespace DAL.DB.Abstract
{
    public interface IDalUnitOfWork
    {
        IRepository<Person> Persons { get; }
        IRepository<Address> Addresses { get; }
    }
}
