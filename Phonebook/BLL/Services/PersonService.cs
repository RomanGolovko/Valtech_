using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Cross_Cutting.Security.ExceptionHandler;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public class PersonService : IService<PersonDTO>
    {
        private readonly IDalUnitOfWork _db;

        public PersonService(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IEnumerable<PersonDTO> GetAll(string userId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Country, CountryDTO>();
            });
            var mapper = config.CreateMapper();
            var persons = mapper.Map<IEnumerable<Person>, List<PersonDTO>>(_db.Persons.GetAll());
            //var currentPersons = persons.Where(x => x.ApplicationUserId == userId);
            return persons;
        }

        public PersonDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException(@"Persons id not set", "");
            }

            var person = _db.Persons.Get(id.Value);

            if (person == null)
            {
                throw new ValidationException(@"Person not found", "");
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Country, CountryDTO>();

            });
            var mapper = config.CreateMapper();
            var currentPerson = mapper.Map<PersonDTO>(_db.Persons.Get(id.Value));

            return currentPerson;
        }

        public void Save(PersonDTO personDTO)
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<PersonDTO, Person>();
                cfg.CreateMap<PhoneDTO, Phone>();
                cfg.CreateMap<StreetDTO, Street>();
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<CountryDTO, Country>();
            });
            var mapper = config.CreateMapper();
            var person = mapper.Map<Person>(_db.Persons.Get(personDTO.Id));

            if (personDTO.Id == 0)
            {
                _db.Persons.Create(person);
            }
            else
            {
                _db.Persons.Update(person);
            }
        }

        public  void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException(@"Persons id not set", "");
            }

            var person = _db.Persons.Get(id.Value);

            if (person == null)
            {
                throw new ValidationException(@"Person not found", "");
            }

            _db.Persons.Delete(id.Value);
        }
    }
}
