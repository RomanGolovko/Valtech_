using DAL.DB.Abstract;
using DAL.Entities;
using LiteDB;
using System.Collections.Generic;

namespace DAL.DB.Concrete.LiteDb
{
    public class LiteDbPhoneRepository : IRepository<Phone>
    {
        private readonly LiteDatabase _db = new LiteDatabase("Person.db");

        public Phone Get(int id)
        {
            var phone = new Phone();

            foreach (var item in _db.GetCollection<Phone>("Phones").Find(p => p.Id == id))
            {
                phone.Id = item.Id;
                phone.Number = item.Number;
                phone.Type = item.Type;
            }

            return phone;
        }

        public IEnumerable<Phone> GetAll()
        {
            return _db.GetCollection<Phone>("Phones").FindAll();
        }

        public void Create(Phone phone)
        {
            _db.GetCollection<Phone>("Phones").Insert(phone);
        }

        public void Update(Phone phone)
        {
            _db.GetCollection<Phone>("Phones").Update(phone);
        }

        public void Delete(int id)
        {
            var person = _db.GetCollection<Phone>("Phones").Delete(p => p.Id == id);
        }
    }
}
