using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class StreetRepository : IRepository<Street>
    {
        private readonly EfDbContext _db;

        public StreetRepository(EfDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Street> GetAll()
        {
            return _db.Streets;
        }

        public Street Get(int id)
        {
            return _db.Streets.Find(id);
        }

        public void Create(Street street)
        {
            _db.Streets.Add(street);
            _db.SaveChanges();
        }

        public void Update(Street street)
        {
            _db.Entry(street).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var street = _db.Streets.Find(id);

            if (street != null)
            {
                _db.Streets.Remove(street);
                _db.SaveChanges();
            }
        }
    }
}
