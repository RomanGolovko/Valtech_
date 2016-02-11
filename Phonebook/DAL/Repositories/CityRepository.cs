using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private readonly EfDbContext _db;

        public CityRepository(EfDbContext context)
        {
            _db = context;
        }

        public IEnumerable<City> GetAll()
        {
            return _db.Cities;
        }

        public City Get(int id)
        {
            return _db.Cities.Find(id);
        }

        public void Create(City city)
        {
            _db.Cities.Add(city);
            _db.SaveChanges();
        }

        public void Update(City city)
        {
            _db.Entry(city).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var city = _db.Cities.Find(id);

            if (city != null)
            {
                _db.Cities.Remove(city);
                _db.SaveChanges();
            }
        }
    }
}
