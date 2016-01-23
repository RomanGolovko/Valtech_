using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class PersonService : IService
    {
        private readonly IUnitOfWork _db;

        public PersonService(IUnitOfWork uow)
        {
            _db = uow;
        }

        public PersonDTO GetPerson(int? id)
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

            Mapper.CreateMap<Person, PersonDTO>();
            Mapper.CreateMap<Phone, PhoneDTO>();

            return Mapper.Map<Person, PersonDTO>(person);
        }

        public IEnumerable<PersonDTO> GetAllPersons()
        {
            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Person, PersonDTO>();
            var result = Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(_db.Persons.GetAll());

            return result;
        }

        public void SavePerson(PersonDTO person)
        {
            Mapper.CreateMap<PersonDTO, Person>();
            Mapper.CreateMap<PhoneDTO, Phone>();

            var currentPerson = Mapper.Map<PersonDTO, Person>(person);

            if (_db.Persons.Get(person.Id) == null)
            {
                _db.Persons.Create(currentPerson);
                foreach (var phone in person.Phones)
                {
                    SavePhone(currentPerson.Id, phone);
                }
            }

            _db.Persons.Update(currentPerson);
        }

        public void SavePhone(int? personId, PhoneDTO phone)
        {
            if (personId == null) return;
            var person = _db.Persons.Get(personId.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }

            Mapper.CreateMap<PhoneDTO, Phone>();
            var currentPhone = Mapper.Map<PhoneDTO, Phone>(phone);
            currentPhone.Person = person;

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
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var person = _db.Persons.Get(id.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }

            if (person.Phones != null)
            {
                foreach (var phone in person.Phones)
                {
                    _db.Phones.Delete(phone.Id);
                }
            }
            _db.Persons.Delete(id.Value);
        }

        public void DeletePhone(int? personId, int? id)
        {
            var person = _db.Persons.Get(personId.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }

            var phone = _db.Phones.Get(id.Value);
            if (phone == null)
            {
                throw new ValidationException("Phone not found", "");
            }

            person.Phones.Remove(phone);
            _db.Phones.Delete(id.Value);
        }
    }
}
