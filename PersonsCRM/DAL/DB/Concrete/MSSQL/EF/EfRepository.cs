using DAL.DB.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace DAL.DB.Concrete.EF
{
    public class EfRepository : IRepository<Person>
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
            if (person.Id == 0)
            {
                _db.Persons.Add(person);
            }
            else
            {
                var dbEntry = _db.Persons.Find(person.Id);
                if (dbEntry != null)
                {
                    dbEntry.FirstName = person.FirstName;
                    dbEntry.LastName = person.LastName;
                    dbEntry.Age = person.Age;
                }
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
                throw new ApplicationException($"Cant't delete person with id: {id}");
            }
        }
    }
}
