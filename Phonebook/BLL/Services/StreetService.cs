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
    public class StreetService : IService<StreetDTO>
    {
        private readonly IDalUnitOfWork _db;

        public StreetService(IDalUnitOfWork uow)
        {
            _db = uow;
        }

        public IEnumerable<StreetDTO> GetAll()
        {
            Mapper.CreateMap<Street, StreetDTO>();
            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Person, PersonDTO>();
            var streets = Mapper.Map<IEnumerable<Street>, List<StreetDTO>>(_db.Streets.GetAll());

            return streets;
        }

        public StreetDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var street = _db.Streets.Get(id.Value);
            if (street == null)
            {
                throw new ValidationException(@"Street not found", "");
            }

            Mapper.CreateMap<Street, StreetDTO>();
            Mapper.CreateMap<Phone, PhoneDTO>();
            Mapper.CreateMap<Person, PersonDTO>();
            var result = Mapper.Map<Street, StreetDTO>(_db.Streets.Get(id.Value));

            return result;
        }

        public IEnumerable<StreetDTO> Find(Func<StreetDTO, bool> predicat)
        {
            throw new NotImplementedException();
        }

        public void Save(StreetDTO street)
        {
            Mapper.CreateMap<PersonDTO, Person>();
            Mapper.CreateMap<PhoneDTO, Phone>();
            Mapper.CreateMap<StreetDTO, Street>();

            var currentStreet = Mapper.Map<StreetDTO, Street>(street);

            if (_db.Streets.Get(street.Id) == null)
            {
                _db.Streets.Create(currentStreet);
            }
            else
            {
                _db.Streets.Update(currentStreet);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var street = _db.Streets.Get(id.Value);
            if (street == null)
            {
                throw new ValidationException("Street not found", "");
            }

            _db.Streets.Delete(id.Value);
        }
    }
}
