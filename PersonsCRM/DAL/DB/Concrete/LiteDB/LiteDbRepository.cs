﻿using DAL.DB.Abstract;
using DAL.Entities;
using LiteDB;
using System.Collections.Generic;

namespace DAL.DB.Concrete.LiteDB
{
    public class LiteDbRepository : IRepository<Person>
    {
        private readonly LiteDatabase _db = new LiteDatabase("Person.db");

        public Person Get(int id)
        {
            Person person = null;

            foreach (var item in _db.GetCollection<Person>("Persons").Find(p => p.Id == id))
            {
                person = new Person
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Age = item.Age,
                    Phones = item.Phones
                };
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
            _db.GetCollection<Person>("Persons").Delete(p => p.Id == id);
        }
    }
}
