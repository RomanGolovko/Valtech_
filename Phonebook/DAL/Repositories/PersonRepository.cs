using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;

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
            return _db.Persons;
        }

        public Person Get(int id)
        {
            return _db.Persons.Find(id);
        }

        public void Create(Person person)
        {
            _db.Persons.Add(person);
        }

        public void Update(Person person)
        {
            _db.Entry(person).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var person = _db.Persons.Find(id);

            if (person != null)
            {
                _db.Persons.Remove(person);
            }
        }
    }
}
