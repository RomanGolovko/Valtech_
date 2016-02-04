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
            var mock = new Mock<IDalUnitOfWork>();
            mock.Setup(x => x.Addresses.GetAll()).Returns(new List<Address>());
            var addressService = new AddressService(mock.Object);

            var result = addressService.GetAll();

            Assert.IsInstanceOf<IEnumerable<AddressDTO>>(result);
        }

        [Test]
        public void CanGetAddress()
        {
            var address = new Address();
            var mock = new Mock<IDalUnitOfWork>();
            mock.Setup(x => x.Addresses.Get(address.Id)).Returns(address);
            var addressService = new AddressService(mock.Object);

            var result = addressService.Get(address.Id);

            Assert.IsInstanceOf<AddressDTO>(result);
        }

        [Test]
        public void CanSaveAddress()
        {
            var address = new Address();
            var mock = new Mock<IDalUnitOfWork>();
            mock.Setup(x => x.Addresses.Create(address)).Verifiable();
            mock.Setup(x => x.Addresses.Update(address)).Verifiable();
            var addressService = new AddressService(mock.Object);

            addressService.Save(new AddressDTO());
        }

        [Test]
        public void CanDeleteAddress()
        {
            var address = new Address();
            var mock = new Mock<IDalUnitOfWork>();
            mock.Setup(x => x.Addresses.Get(address.Id)).Returns(address);
            mock.Setup(x => x.Addresses.Delete(address.Id)).Verifiable();
            var addressService = new AddressService(mock.Object);

            addressService.Delete(address.Id);
        }
    }
}
