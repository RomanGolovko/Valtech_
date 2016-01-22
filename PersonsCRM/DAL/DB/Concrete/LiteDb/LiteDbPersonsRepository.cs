using DAL.DB.Abstract;
using DAL.Entities;
using LiteDB;
using System.Collections.Generic;

namespace DAL.DB.Concrete.LiteDb
{
    public class LiteDbPersonsRepository : IRepository<Person>
    {
        private readonly LiteDatabase _db = new LiteDatabase("Person.db");

        public Person Get(int id)
        {
            var person = new Person();

            foreach (var item in _db.GetCollection<Person>("Persons").Find(p => p.Id == id))
            {
                person.Id = item.Id;
                person.FirstName = item.FirstName;
                person.LastName = item.LastName;
                person.Age = item.Age;
                person.Phones = item.Phones;
            }

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return _db.GetCollection<Person>("Persons").FindAll();
        }

        public void Create(Person person)
        {
            _db.GetCollection<Person>("Persons").Insert(person);
        }

        public void Update(Person person)
        {
            _db.GetCollection<Person>("Persons").Update(person);
        }

        public void Delete(int id)
        {
            var person = _db.GetCollection<Person>("Persons").Delete(p => p.Id == id);
        }
    }
}
