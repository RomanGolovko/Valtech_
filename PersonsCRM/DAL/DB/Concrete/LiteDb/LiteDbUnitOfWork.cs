using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.LiteDb
{
    public class LiteDbUnitOfWork : IUnitOfWork
    {
        private LiteDbPersonsRepository personRepository;
        private LiteDbPhoneRepository phoneRepository;

        public IRepository<Person> Persons
        {
            get
            {
                if (personRepository == null)
                {
                    personRepository = new LiteDbPersonsRepository();
                }
                return personRepository;
            }
        }

        public IRepository<Phone> Phones
        {
            get
            {
                if (phoneRepository == null)
                {
                    phoneRepository = new LiteDbPhoneRepository();
                }
                return phoneRepository;
            }
        }
    }
}
