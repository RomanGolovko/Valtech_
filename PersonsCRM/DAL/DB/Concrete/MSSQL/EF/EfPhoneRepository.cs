using System.Collections.Generic;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.EF
{
    public class EfPhoneRepository : IRepository<Phone>
    {
        private readonly EfDbContext _db = new EfDbContext();

        public Phone Get(int id)
        {
            return _db.Phones.Find(id);
        }

        public IEnumerable<Phone> GetAll()
        {
            return _db.Phones;
        }

        public void Create(Phone phone)
        {
            _db.Phones.Add(phone);
            _db.SaveChanges();
        }

        public void Update(Phone phone)
        {
            var dbEntry = _db.Phones.Find(phone.Id);
            if (dbEntry == null) return;
            dbEntry.Number = phone.Number;
            dbEntry.Type = phone.Type;
            dbEntry.PersonId = phone.PersonId;
            dbEntry.Person = phone.Person;
            _db.SaveChanges();

        }

        public void Delete(int id)
        {
            var dbEntry = _db.Phones.Find(id);
            if (dbEntry != null)
            {
                _db.Phones.Remove(dbEntry);
                _db.SaveChanges();
            }
            else
            {
                throw new ValidationException($"Cant't delete person with id: {id}", "");
            }
        }
    }
}
