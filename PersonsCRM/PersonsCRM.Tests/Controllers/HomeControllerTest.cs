using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers;

namespace PersonsCRM.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            var controller = new HomeController();

            var result = controller.About() as ViewResult;

            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            var controller = new HomeController();

            var result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
        }
    }
}
