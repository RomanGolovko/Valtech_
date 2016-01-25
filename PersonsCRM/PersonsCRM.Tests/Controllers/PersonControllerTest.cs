using System.Collections.Generic;
using System.Web.Mvc;
using BLL.Abstract;
using BLL.DTO;
using Moq;
using NUnit.Framework;
using WebUI.Controllers;
using WebUI.Models;

namespace PersonsCRM.Tests.Controllers
{
    [TestFixture]
    public class PersonControllerTest
    {
        [Test]
        public void IndexViewModelNotNull()
        {
            var mock = new Mock<IService>();
            mock.Setup(x => x.GetAllPersons()).Returns(new List<PersonDTO>());
            var controller = new PersonController(mock.Object);

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void CreateViewModelNotNull()
        {
            var mock = new Mock<IService>();
            var controller = new PersonController(mock.Object);

            var result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [Test]
        public void EditViewModelNotNull()
        {
            var person = new PersonDTO();
            var mock = new Mock<IService>();
            mock.Setup(a => a.GetPerson(person.Id)).Returns(new PersonDTO());
            var controller = new PersonController(mock.Object);

            var result = controller.Edit(person.Id) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void EditPostAction_RedirectToIndexView()
        {
            var personViewModel = new PersonViewModel();
            var person = new PersonDTO();
            var mock = new Mock<IService>();
            mock.Setup(x => x.SavePerson(person)).Verifiable();
            var controller = new PersonController(mock.Object);

            var result = controller.Edit(personViewModel) as RedirectToRouteResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void DeletePostAction_DeleteModel()
        {
            var person = new PersonDTO();
            var mock = new Mock<IService>();
            var controller = new PersonController(mock.Object);

            var result = controller.Delete(person.Id) as RedirectToRouteResult;

            mock.Verify(a => a.DeletePerson(person.Id));
        }
    }
}
