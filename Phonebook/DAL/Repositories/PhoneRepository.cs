using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private readonly EfDbContext _db;

        public PhoneRepository(EfDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Phone> GetAll()
        {
            return _db.Phones;
        }

        public Phone Get(int id)
        {
            return _db.Phones.Find(id);
        }

        public void Create(Phone phone)
        {
            _db.Phones.Add(phone);
            _db.SaveChanges();
        }

        public void Update(Phone phone)
        {
            _db.Entry(phone).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var phone = _db.Phones.Find(id);

            if (phone != null)
            {
                _db.Phones.Remove(phone);
                _db.SaveChanges();
            }
        }
    }
}
