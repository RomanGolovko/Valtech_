using System.Web.Mvc;
using BLL;
using CrossCutting;

namespace Architecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly Authorization _auth = new Authorization();
        private readonly Commercial _commerc = new Commercial();
        private readonly Message _msg = new Message();
        private readonly Payment _paym = new Payment();
        private readonly PersonalAccount _pa = new PersonalAccount();
        private readonly Rate _rate = new Rate();
        private readonly RealJob _job = new RealJob();

        public ActionResult Index()
        {
            ViewBag.Auth = _auth.GetAuth();
            ViewBag.Msg = _msg.GetMsg();
            ViewBag.Commerc = _commerc.GetCommercial();
            ViewBag.Paym = _paym.GetPayment();
            ViewBag.PA = _pa.GetPersAcc();
            ViewBag.RealJob = _job.GetRealJob();
            ViewBag.Rate = _rate.GetRate();
            ViewBag.DAL = _job.GetFromDAL();

            return View();
        }
    }
}