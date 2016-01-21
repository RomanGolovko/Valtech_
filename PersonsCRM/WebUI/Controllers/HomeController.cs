using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using WebUI.Models;
using Cross_Cutting.Security;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<PersonDTO> _db;

        public HomeController(IService<PersonDTO> personService)
        {
            _db = personService;
        }

        // GET: Home
        public ActionResult Index()
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAll());

            return View(persons);
        }

        public ActionResult Grid()
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAll());

            return View(persons);
        }

        // Get: Home/Create
        public ActionResult Create()
        {
            return View("Edit", new PersonViewModel());
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.GetCurrent(id));

            return View(person);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personModel)
        {
            try
            {
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                var person = Mapper.Map<PersonViewModel, PersonDTO>(personModel);
                _db.Save(person);
                TempData["message"] = $"{person.FirstName} {person.LastName} has been saved";

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(personModel);
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                _db.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
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
    }
}