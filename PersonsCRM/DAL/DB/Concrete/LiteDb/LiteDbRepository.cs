using DAL.DB.Abstract;
using DAL.Entities;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace DAL.DB.Concrete.LiteDb
{
    public class LiteDbRepository : IRepository<Person>
    {
        LiteDatabase db = new LiteDatabase("Person.db");

        public Person Get(int id)
        {
            var person = new Person();

            foreach (var item in db.GetCollection<Person>("Persons").Find(p => p.Id == id))
            {
                person.Id = item.Id;
                person.FirstName = item.FirstName;
                person.LastName = item.LastName;
                person.Age = item.Age;
            }

            return person;
        }

        public IEnumerable<Person> GetAll()
        {
            return db.GetCollection<Person>("Persons").FindAll().AsEnumerable();
        }

        public void Create(Person person)
        {
            db.GetCollection<Person>("Persons").Insert(person);
        }

        public void Update(Person person)
        {
            db.GetCollection<Person>("Persons").Update(person);
        }

        public void Delete(int id)
        {
            db.GetCollection<Person>("Persons").Delete(p => p.Id == id);
        }
    }
}
