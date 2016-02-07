using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ServiceUnitOfWork : IBllUnitOfWork
    {
        private readonly IDalUnitOfWork _db;
        private PersonService _personService;
        private StreetService _streetService;

        public ServiceUnitOfWork(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IService<PersonDTO> Persons => _personService ?? (_personService = new PersonService(_db));
        public IService<StreetDTO> Streets => _streetService ?? (_streetService = new StreetService(_db));
    }
}
