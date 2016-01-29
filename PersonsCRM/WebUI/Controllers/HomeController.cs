using System;
using System.Threading;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Calculator()
        {
            return PartialView();
        }

        public string GetTime()
        {
            Thread.Sleep(1000);
            return $"{DateTime.Now.Hour} : {DateTime.Now.Minute} : {DateTime.Now.Second}";
        }
    }
}