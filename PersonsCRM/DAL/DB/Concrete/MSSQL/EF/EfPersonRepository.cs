using System.Collections.Generic;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete.MSSQL.EF
{
    public class EfPersonRepository : IRepository<Person>
    {
        private readonly EfDbContext _db = new EfDbContext();

        public Person Get(int id)
        {
            return _db.Persons.Find(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons;
        }

        public void Create(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
        }

        public void Update(Person person)
        {
            var dbEntry = _db.Persons.Find(person.Id);
            if (dbEntry == null) return;
            dbEntry.FirstName = person.FirstName;
            dbEntry.LastName = person.LastName;
            dbEntry.Age = person.Age;
            dbEntry.Phones = person.Phones;
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
