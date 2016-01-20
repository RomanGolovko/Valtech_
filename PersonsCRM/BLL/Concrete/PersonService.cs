using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using DAL.DB.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class PersonService : IService<PersonDTO>
    {
        private IRepository<Person> db { get; set; }

        public PersonService(IRepository<Person> repo)
        {
            db = repo;
        }

        public PersonDTO GetCurrent(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            var person = db.Get(id.Value);
            if (person == null)
            {
                throw new ArgumentNullException("Person not found", "");
            }

            Mapper.CreateMap<Person, PersonDTO>();
            return Mapper.Map<Person, PersonDTO>(person);
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            Mapper.CreateMap<Person, PersonDTO>();
            return Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(db.GetAll());
        }

        public void Save(PersonDTO item)
        {
            var person = new Person
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Age = item.Age
            };

            if (db.Get(item.Id) == null)
            {
                db.Create(person);
            }
            else
            {
                db.Update(person);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            var person = db.Get(id.Value);
            if (person == null)
            {
                throw new ArgumentNullException("Person not found", "");
            }

            db.Delete(id.Value);
        }
    }
}
