using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly AppContext _db;

        public PersonRepository(AppContext context)
        {
            _db = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.Persons.Include(p => _db.Streets.Find(p.StreetId));
        }

        public IEnumerable<Person> Find(Func<Person, bool> predicat)
        {
            return _db.Persons.Where(predicat).ToList();
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
            }
            _db.SaveChanges();
        }
    }
}
