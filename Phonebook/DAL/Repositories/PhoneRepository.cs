using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PhoneRepository : IRepository<Phone>
    {
        private readonly AppContext _db;

        public PhoneRepository(AppContext context)
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

        public IEnumerable<Phone> Find(Func<Phone, bool> predicat)
        {
            return _db.Phones.Where(predicat).ToList();
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
            }
            _db.SaveChanges();
        }
    }
}
