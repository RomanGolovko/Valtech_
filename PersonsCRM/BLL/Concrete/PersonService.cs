using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class PersonService : IService
    {
        private IUnitOfWork _db { get; set; }

        public PersonService(IUnitOfWork uow)
        {
            _db = uow;
        }

        public PersonDTO GetPerson(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException();
            }

            var person = _db.Persons.Get(id.Value);
            if (person == null)
            {
                throw new ArgumentNullException("Person not found", "");
            }

            Mapper.CreateMap<Person, PersonDTO>();
            return Mapper.Map<Person, PersonDTO>(person);
        }

        public IEnumerable<PersonDTO> GetAllPersons()
        {
            Mapper.CreateMap<Person, PersonDTO>();
            return Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(_db.Persons.GetAll());
        }

        public void SavePerson(PersonDTO person)
        {
            Mapper.CreateMap<PersonDTO, Person>();
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

        public void SavePhone(int? personId, PhoneDTO phone)
        {
            var person = _db.Persons.Get(personId.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }

            Mapper.CreateMap<PhoneDTO, Phone>();
            var currentPhone = Mapper.Map<PhoneDTO, Phone>(phone);

            if (phone.Id == 0)
            {
                phone.PersonId = person.Id;
                person.Phones.Add(currentPhone);
                _db.Phones.Create(currentPhone);
                _db.Persons.Update(person);
            }
            else
            {
                _db.Phones.Update(currentPhone);
            }
        }

        public void DeletePerson(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong insert parameters", "");
            }

            var person = _db.Persons.Get(id.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }
            else
            {
                foreach (var phone in person.Phones)
                {
                    _db.Phones.Delete(phone.Id);
                }
            }

            _db.Phones.Delete(id.Value);
        }

        public void DeletePhone(int? personId, int? id)
        {
            var person = _db.Persons.Get(personId.Value);
            var phone = _db.Phones.Get(id.Value);
            if (phone == null || person == null)
            {
                throw new ValidationException("Person or phone not found", "");
            }

            person.Phones.Remove(phone);
            _db.Phones.Delete(id.Value);
        }
    }
}
