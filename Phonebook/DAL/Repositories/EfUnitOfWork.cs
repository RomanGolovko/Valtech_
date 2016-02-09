using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class EfUnitOfWork : IDalUnitOfWork
    {
        private readonly EfDbContext _db;
        private PersonRepository _personRepository;
        private StreetRepository _streetRepository;
        private CityRepository _cityRepository;
        private CountryRepository _countryRepository;

        public EfUnitOfWork(string connectionString)
        {
            _db = new EfDbContext(connectionString);
        }

        public IRepository<Person> Persons => _personRepository ?? new PersonRepository(_db);
        public IRepository<Street> Streets => _streetRepository ?? new StreetRepository(_db);
        public IRepository<City> Cities => _cityRepository ?? new CityRepository(_db);
        public IRepository<Country> Countries => _countryRepository ?? new CountryRepository(_db);
    }
}
