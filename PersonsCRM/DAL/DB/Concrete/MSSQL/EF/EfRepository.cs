using DAL.DB.Abstract;
using DAL.Entities;
using System.Data.Entity;
using System.Collections.Generic;
using Cross_Cutting.Security;
using System.Linq;

namespace DAL.DB.Concrete.MSSQL.EF
{
    public class EfRepository : IRepository<Person>
    {
        private readonly EfDbContext _db = new EfDbContext();

        public Person Get(int id)
        {
            var person = _db.Persons.Find(id);
            if (person != null)
            {
                person.Phones = _db.Phones.Where(x => x.PersonId == person.Id).ToList(); 
            }
            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons.Include(p => p.Phones);
        }

        public void Create(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
        }

        public void Update(Person person)
        {
            var dbEntryPerson = _db.Persons.Find(person.Id);
            if (dbEntryPerson == null) return;
            dbEntryPerson.FirstName = person.FirstName;
            dbEntryPerson.LastName = person.LastName;
            dbEntryPerson.Age = person.Age;

            if (person.Phones != null)
            {
                var tempPhones = new List<Phone>();
                foreach (var phone in person.Phones)
                {
                    var dbEntryPhone = _db.Phones.Find(phone.Id);
                    dbEntryPhone.Number = phone.Number;
                    dbEntryPhone.Type = phone.Type;
                    tempPhones.Add(dbEntryPhone);
                }
                dbEntryPerson.Phones = tempPhones; 
            }

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = _db.Persons.Find(id);
            if (dbEntry != null)
            {
                _db.Persons.Remove(dbEntry);
                _db.SaveChanges();
            }
            else
            {
                throw new ValidationException($"Cant't delete person with id: {id}", "");
            }
        }
    }
}
