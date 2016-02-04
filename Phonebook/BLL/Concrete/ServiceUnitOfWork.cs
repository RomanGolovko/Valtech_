using BLL.Abstract;
using BLL.DTO;
using DAL.DB.Abstract;

namespace BLL.Concrete
{
    public class ServiceUnitOfWork : IBllUnitOfWork
    {
        private IDalUnitOfWork _db;
        private AddressService _addressService;
        private PersonService _personService;

        public ServiceUnitOfWork(IDalUnitOfWork duow)
        {
            _db = duow;
        }

        public IService<AddressDTO> Addresses
        {
            get
            {
                if (_addressService == null)
                {
                    _addressService = new AddressService(_db);
                }

                return _addressService;
            }
        }

        public IService<PersonDTO> Persons
        {
            get
            {
                if (_personService == null)
                {
                    _personService = new PersonService(_db);
                }

                return _personService;
            }
        }
    }
}
