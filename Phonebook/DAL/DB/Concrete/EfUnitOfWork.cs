using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete
{
    public class EfUnitOfWork : IDalUnitOfWork
    {
        private EfDbContext _db;
        private EfPersonsRepository personRepository;
        private EfAddressesRepository addressRepository;

        public EfUnitOfWork()
        {
            _db = new EfDbContext();
        }

        public IRepository<Person> Persons
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new EfPersonsRepository();
                }

                return personRepository;
            }
        }

        public IRepository<Address> Addresses
        {
            get
            {
                if (addressRepository == null)
                {
                    addressRepository = new EfAddressesRepository();
                }

                return addressRepository;
            }
        }
    }
}
