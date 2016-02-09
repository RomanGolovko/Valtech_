using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class CountryRepository : IRepository<Country>
    {
        private readonly EfDbContext _db;

        public CountryRepository(EfDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Country> GetAll()
        {
            return _db.Countries;
        }

        public Country Get(int id)
        {
            return _db.Countries.Find(id);
        }

        public void Create(Country country)
        {
            _db.Countries.Add(country);
        }

        public void Update(Country country)
        {
            _db.Entry(country).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var country = _db.Countries.Find(id);

            if (country != null)
            {
                _db.Countries.Remove(country);
            }
        }
    }
}
