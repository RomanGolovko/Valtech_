using System.Collections.Generic;
using BLL.Concrete;
using BLL.DTO;
using DAL.DB.Abstract;
using DAL.Entities;
using Moq;
using NUnit.Framework;

namespace Phonebook.Tests.BLL.Tests
{
    [TestFixture]
    public class AddressServiceTests
    {
        [Test]
        public void CanGetAllAddresses()
        {
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(x => x.GetAll()).Returns(new List<Address>());
            var addressService = new AddressService(mock.Object);

            var result = addressService.GetAll();

            Assert.IsInstanceOf<IEnumerable<AddressDTO>>(result);
        }

        [Test]
        public void CanGetAddress()
        {
            var address = new Address();
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(x => x.Get(address.Id)).Returns(address);
            var addressService = new AddressService(mock.Object);

            var result = addressService.Get(address.Id);

            Assert.IsInstanceOf<AddressDTO>(result);
        }

        [Test]
        public void CanSaveAddress()
        {
            var address = new Address();
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(x => x.Create(address)).Verifiable();
            mock.Setup(x => x.Update(address)).Verifiable();
            var addressService = new AddressService(mock.Object);

            addressService.Save(new AddressDTO());
        }

        [Test]
        public void CanDeleteAddress()
        {
            var address = new Address();
            var mock = new Mock<IRepository<Address>>();
            mock.Setup(x => x.Get(address.Id)).Returns(address);
            mock.Setup(x => x.Delete(address.Id)).Verifiable();
            var addressService = new AddressService(mock.Object);

            addressService.Delete(address.Id);
        }
    }
}
