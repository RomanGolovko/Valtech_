using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Cross_Cutting.Security.ExceptionHandler;
using DAL.Entities;
using DAL.Interfaces;
using System.Collections.Generic;

namespace BLL.Services
{
    public class StreetService : IService<StreetDTO>
    {
        private readonly IDalUnitOfWork _db;

        public StreetService(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IEnumerable<StreetDTO> GetAll()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
            });
            var mapper = config.CreateMapper();
            var persons = mapper.Map<List<StreetDTO>>(_db.Streets.GetAll());

            return persons;
        }

        public StreetDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("@Street id not set", "");
            }

            var person = _db.Streets.Get(id.Value);

            if (person == null)
            {
                throw new ValidationException(@"Street not found", "");
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<Phone, PhoneDTO>();
            });
            var mapper = config.CreateMapper();
            var currentStreet = mapper.Map<StreetDTO>(_db.Streets.Get(id.Value));

            return currentStreet;
        }

        public void Save(StreetDTO streetDTO)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StreetDTO, Street>();
                cfg.CreateMap<PersonDTO, Person>();
                cfg.CreateMap<PhoneDTO, Phone>();
            });
            var mapper = config.CreateMapper();
            var street = mapper.Map<Street>(_db.Streets.Get(streetDTO.Id));

            if (streetDTO.Id == 0)
            {
                _db.Streets.Create(street);
            }
            else
            {
                _db.Streets.Update(street);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("@Persons id not set", "");
            }

            var street = _db.Streets.Get(id.Value);

            if (street == null)
            {
                throw new ValidationException(@"Person not found", "");
            }

            _db.Streets.Delete(id.Value);
        }
    }
}
