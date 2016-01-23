using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.EF
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private EfPersonRepository _personRepository;
        private EfPhoneRepository _phoneRepository;

        public IRepository<Person> Persons => _personRepository ?? (_personRepository = new EfPersonRepository());
        public IRepository<Phone> Phones => _phoneRepository ?? (_phoneRepository = new EfPhoneRepository());
    }
}
