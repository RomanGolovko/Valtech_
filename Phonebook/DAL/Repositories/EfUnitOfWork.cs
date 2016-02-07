using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EfUnitOfWork : IDalUnitOfWork
    {
        private readonly AppContext _db;
        private PersonRepository _personRepository;
        private PhoneRepository _phoneRepository;
        private StreetRepository _streetRepository;

        public EfUnitOfWork(string connectionString)
        {
            _db = new AppContext(connectionString);
        }

        public IRepository<Person> Persons => _personRepository ?? (_personRepository = new PersonRepository(_db));
        public IRepository<Phone> Phones => _phoneRepository ?? (_phoneRepository = new PhoneRepository(_db));
        public IRepository<Street> Streets => _streetRepository ?? (_streetRepository = new StreetRepository(_db));
    }
}
