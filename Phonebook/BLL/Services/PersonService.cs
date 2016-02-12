using System.Collections.Generic;
using System.Linq;
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
            var currentPersons = persons.Where(x => x.UserId == userId);

            return currentPersons;
        }

        public IEnumerable<PersonDTO> Search(string userId, string searchedParam)
        {
            var persons = GetAll(userId);

            if (!string.IsNullOrEmpty(searchedParam))
            {
                persons = persons.Where(x => x.FirstName.ToLower().Contains(searchedParam.Trim().ToLower()) 
                    /*|| x.Phones.Where(p => p.Number.ToString().Contains(searchedParam.Trim().ToLower()) || p.Type.Contains(searchedParam.Trim().ToLower()))*/
                    || x.LastName.ToLower().Contains(searchedParam.Trim().ToLower())
                    || x.Street.Name.ToLower().Contains(searchedParam.Trim().ToLower())
                    || x.Street.City.Name.ToLower().Contains(searchedParam.Trim().ToLower())
                    || x.Street.City.Country.Name.ToLower().Contains(searchedParam.Trim().ToLower()));
            }

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
            var person = mapper.Map<Person>(personDTO);
            var street = person.Street;
            SaveStreet(street);
            var city = street.City;
            SaveCity(city);
            var country = city.Country;
            SaveCountry(country);

            if (personDTO.Id == 0)
            {
                _db.Persons.Create(person);
            }
            else
            {
                _db.Persons.Update(person);
            }
        }

        public void Delete(int? id)
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

        private void SaveStreet(Street street)
        {
            if (street.Id == 0)
            {
                _db.Streets.Create(street);
            }
            else
            {
                _db.Streets.Update(street);
            }
        }

        private void SaveCity(City city)
        {
            if (city.Id == 0)
            {
                _db.Cities.Create(city);
            }
            else
            {
                _db.Cities.Update(city);
            }
        }

        private void SaveCountry(Country country)
        {
            if (country.Id == 0)
            {
                _db.Countries.Create(country);
            }
            else
            {
                _db.Countries.Update(country);
            }
        }
    }
}
