using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IBllUnitOfWork _db;

        public PersonController(IBllUnitOfWork uow)
        {
            _db = uow;
        }

        // GET: Person
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, PersonModel>();
                cfg.CreateMap<PhoneDTO, PhoneModel>();
            });
            var mapper = config.CreateMapper();
            var persons = mapper.Map<IEnumerable<PersonDTO>, List<PersonModel>>(_db.PersonsService.GetAll());

            return View(persons);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View("Edit", new PersonModel());
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
