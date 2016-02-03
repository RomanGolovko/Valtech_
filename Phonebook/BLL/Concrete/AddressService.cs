using System.Collections.Generic;
using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;

namespace BLL.Concrete
{
    public class AddressService : IService<AddressDTO>
    {
        private readonly IRepository<Address> _db;

        public AddressService(IRepository<Address> repo)
        {
            _db = repo;
        }

        public AddressDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var address = _db.Get(id.Value);
            if (address == null)
            {
                throw new ValidationException(@"Address not found", "");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressDTO>());
            var mapper = config.CreateMapper();

            return mapper.Map<AddressDTO>(address);
        }

        public IEnumerable<AddressDTO> GetAll()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Address, AddressDTO>());
            var mapper = config.CreateMapper();

            return mapper.Map<List<AddressDTO>>(_db.GetAll());
        }

        public void Save(AddressDTO address)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, Address>());
            var mapper = config.CreateMapper();

            var currentAddress = mapper.Map<Address>(address);

            if (_db.Get(address.Id) == null)
            {
                _db.Create(currentAddress);
            }
            else
            {
                _db.Update(currentAddress);
            }
        }

        public void Delete(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Wrong inserted parameters", "");
            }

            var address = _db.Get(id.Value);
            if (address == null)
            {
                throw new ValidationException(@"Address not found", "");
            }

            _db.Delete(id.Value);
        }
    }
}
