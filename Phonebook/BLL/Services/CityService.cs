using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Cross_Cutting.Security.ExceptionHandler;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class CityService : IService<CityDTO>
    {
        private readonly IDalUnitOfWork _db;

        public CityService(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IEnumerable<CityDTO> GetAll(string userId)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
            });
            var mapper = config.CreateMapper();
            var cities = mapper.Map<List<CityDTO>>(_db.Cities.GetAll());

            return cities;
        }

        public CityDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException(@"City id not set", "");
            }

            var city = _db.Cities.Get(id.Value);

            if (city == null)
            {
                throw new ValidationException(@"City not found", "");
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
            });
            var mapper = config.CreateMapper();
            var currentCity = mapper.Map<CityDTO>(_db.Cities.Get(id.Value));

            return currentCity;
        }

        public void Save(CityDTO cityDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<StreetDTO, Street>();
                cfg.CreateMap<PersonDTO, Person>();
                cfg.CreateMap<PhoneDTO, Phone>();
            });
            var mapper = config.CreateMapper();
            var city = mapper.Map<City>(_db.Cities.Get(cityDTO.Id));

            if (cityDTO.Id == 0)
            {
                _db.Cities.Create(city);
            }
            else
            {
                _db.Cities.Update(city);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException(@"City id not set", "");
            }

            var street = _db.Streets.Get(id.Value);

            if (street == null)
            {
                throw new ValidationException(@"City not found", "");
            }

            _db.Streets.Delete(id.Value);
        }
    }
}
