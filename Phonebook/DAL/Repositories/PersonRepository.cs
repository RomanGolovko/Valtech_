using System.Collections.Generic;
using System.Data.Entity;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly EfDbContext _db;

        public PersonRepository(EfDbContext context)
        {
            _db = context;
        }

        public IEnumerable<Person> GetAll()
        {
            var pers = _db.Persons;
            return pers;
        }

        public Person Get(int id)
        {
            return _db.Persons.Find(id); 
        }

        public void Create(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
        } 

        public void Update(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var person = _db.Persons.Find(id);

            if (person != null)
            {
                _db.Persons.Remove(person);
                _db.SaveChanges();
            }
        }
    }
}
