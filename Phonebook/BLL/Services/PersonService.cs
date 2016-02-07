using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Cross_Cutting.Security;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class PersonService : IService<PersonDTO>
    {
        private readonly IDalUnitOfWork _db;

        public PersonService(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            Mapper.CreateMap<Street, StreetDTO>();
            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Person, PersonDTO>();
            var persons =  Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(_db.Persons.GetAll());

            return persons;
        }

        public PersonDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var person = _db.Persons.Get(id.Value);
            if (person == null)
            {
                throw new ValidationException(@"Person not found", "");
            }

            Mapper.CreateMap<Street, StreetDTO>();
            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Person, PersonDTO>();
            var result = Mapper.Map<Person, PersonDTO>(_db.Persons.Get(id.Value));

            return result;
        }

        public IEnumerable<PersonDTO> Find(Func<PersonDTO, bool> predicat)
        {
            throw new NotImplementedException();
        }

        public void Save(PersonDTO person)
        {
            Mapper.CreateMap<PersonDTO, Person>();
            Mapper.CreateMap<PhoneDTO, Phone>();
            Mapper.CreateMap<StreetDTO, Street>();

            var currentPerson = Mapper.Map<PersonDTO, Person>(person);

            if (_db.Persons.Get(person.Id) == null)
            {
                _db.Persons.Create(currentPerson);
            }
            else
            {
                _db.Persons.Update(currentPerson);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var person = _db.Persons.Get(id.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }

            _db.Persons.Delete(id.Value);
        }
    }
}
