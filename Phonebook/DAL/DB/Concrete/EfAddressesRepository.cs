using System.Collections.Generic;
using Cross_Cutting.Security;
using DAL.DB.Abstract;
using DAL.Entities;

namespace DAL.DB.Concrete
{
    public class EfAddressesRepository : IRepository<Address>
    {
        private readonly EfDbContext _db = new EfDbContext();

        public Address Get(int id)
        {
            return _db.Addresses.Find(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return _db.Addresses;
        }

        public void Create(Address address)
        {
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }

        public void Update(Address address)
        {
            var dbEntryAddress = _db.Addresses.Find(address.Id);
            if (dbEntryAddress == null) return;
            dbEntryAddress.Street = address.Street;
            if (address.Phones != null)
            {
                var tempPhones = new List<Phone>();
                foreach (var phone in address.Phones)
                {
                    var dbEntryPhone = _db.Phones.Find(phone.Id);
                    if (dbEntryPhone == null)
                    {
                        _db.Phones.Add(phone);
                    }
                    else
                    {
                        dbEntryPhone.Number = phone.Number;
                        dbEntryPhone.Type = phone.Type;
                        tempPhones.Add(dbEntryPhone);
                    }
                }
                dbEntryAddress.Phones = tempPhones;
            }

            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = _db.Addresses.Find(id);
            if (dbEntry != null)
            {
                _db.Addresses.Remove(dbEntry);
                _db.SaveChanges();
            }
            else
            {
                throw new ValidationException($"Cant't delete address with id: {id}", "");
            }
        }
    }
}
