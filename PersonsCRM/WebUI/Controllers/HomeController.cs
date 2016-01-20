using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<PersonDTO> _db;

        public HomeController(IService<PersonDTO>personService )
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
            Mapper.CreateMap<PersonViewModel, PersonDTO>();
            var person = Mapper.Map<PersonViewModel, PersonDTO>(personModel);
            _db.Save(person);
            TempData["message"] = $"{person.FirstName} {person.LastName} has been saved";

            return RedirectToAction("Index");
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                _db.Delete(id);
            }
            catch (Exception)
            {
                
                throw;
            }

            return RedirectToAction("Index");
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