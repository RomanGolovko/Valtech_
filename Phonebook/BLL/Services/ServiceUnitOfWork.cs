using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ServiceUnitOfWork : IBllUnitOfWork
    {
        private readonly IDalUnitOfWork _db;
        private IService<PersonDTO> _personService;

        public ServiceUnitOfWork(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IService<PersonDTO> PersonsService => _personService ?? new PersonService(_db);
    }
}
