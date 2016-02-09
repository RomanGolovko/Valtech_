using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Cross_Cutting.Security.ExceptionHandler;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CountryService : IService<CountryDTO>
    {
        private readonly IDalUnitOfWork _db;

        public CountryService(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IEnumerable<CountryDTO> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountryDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
            });
            var mapper = config.CreateMapper();
            var countries = mapper.Map<List<CountryDTO>>(_db.Countries.GetAll());

            return countries;
        }

        public CountryDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException(@"Country id not set", "");
            }

            var country = _db.Countries.Get(id.Value);

            if (country == null)
            {
                throw new ValidationException(@"Country not found", "");
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, CountryDTO>();
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
            });
            var mapper = config.CreateMapper();
            var currentCountry = mapper.Map<CountryDTO>(_db.Cities.Get(id.Value));

            return currentCountry;
        }

        public void Save(CountryDTO countryDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CountryDTO, Country>();
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<StreetDTO, Street>();
                cfg.CreateMap<PersonDTO, Person>();
                cfg.CreateMap<PhoneDTO, Phone>();
            });
            var mapper = config.CreateMapper();
            var country = mapper.Map<Country>(_db.Countries.Get(countryDTO.Id));

            if (countryDTO.Id == 0)
            {
                _db.Countries.Create(country);
            }
            else
            {
                _db.Countries.Update(country);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException(@"Country id not set", "");
            }

            var country = _db.Countries.Get(id.Value);

            if (country == null)
            {
                throw new ValidationException(@"Country not found", "");
            }

            _db.Countries.Delete(id.Value);
        }
    }
}
