using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.LiteDb
{
    public class LiteDbUnitOfWork : IUnitOfWork
    {
        private LiteDbPersonsRepository _personRepository;
        private LiteDbPhoneRepository _phoneRepository;

        public IRepository<Person> Persons => _personRepository ?? (_personRepository = new LiteDbPersonsRepository());

        public IRepository<Phone> Phones => _phoneRepository ?? (_phoneRepository = new LiteDbPhoneRepository());
    }
}
