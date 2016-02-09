using System;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Services
{
    public class ServiceUnitOfWork : IBllUnitOfWork
    {
        private readonly IDalUnitOfWork _db;
        private IService<PersonDTO> _personService;
        private IService<StreetDTO> _streetService;
        private IService<CityDTO> _cityService;
        private IService<CountryDTO> _countryService;

        public ServiceUnitOfWork(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IService<PersonDTO> PersonsService => _personService ?? new PersonService(_db);
        public IService<StreetDTO> StreetsService => _streetService ?? new StreetService(_db);
        public IService<CityDTO> CitiesService => _cityService ?? new CityService(_db);
        public IService<CountryDTO> CountriesService => _countryService ?? new CountryService(_db);
    }
}
