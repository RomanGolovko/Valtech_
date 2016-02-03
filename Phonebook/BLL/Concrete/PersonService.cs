using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Concrete
{
    public class PersonService : IService<PersonDTO>
    {
        private readonly IRepository<Person> _db;

        public PersonService(IRepository<Person> repo)
        {
            _db = repo;
        }

        public PersonDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var person = _db.Get(id.Value);
            if (person == null)
            {
                throw new ValidationException(@"Person not found", "");
            }

            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Address, AddressDTO>();
            Mapper.CreateMap<Person, PersonDTO>();

            return Mapper.Map<Person, PersonDTO>(person);
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Address, AddressDTO>();
            Mapper.CreateMap<Person, PersonDTO>();
            var result = Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(_db.GetAll());

            return result;
        }

        public void Save(PersonDTO person)
        {
            Mapper.CreateMap<PersonDTO, Person>();
            Mapper.CreateMap<AddressDTO, Address>();
            Mapper.CreateMap<PhoneDTO, Phone>();

            var currentPerson = Mapper.Map<PersonDTO, Person>(person);

            if (_db.Get(person.Id) == null)
            {
                _db.Create(currentPerson);
            }
            else
            {
                _db.Update(currentPerson);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var person = _db.Get(id.Value);
            if (person == null)
            {
                throw new ValidationException("Person not found", "");
            }

            _db.Delete(id.Value);
        }
    }
}
