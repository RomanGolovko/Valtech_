using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Cross_Cutting.Security;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PhonebookController : Controller
    {
        private readonly IBllUnitOfWork _db;

        public PhonebookController(IBllUnitOfWork uow)
        {
            _db = uow;
        }

        // GET: Person
        public ActionResult Index()
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<StreetDTO, StreetViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.Persons.GetAll());

            return View(persons);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<StreetDTO, StreetViewModel>();
            var streets = Mapper.Map<IEnumerable<StreetDTO>, List<StreetViewModel>>(_db.Streets.GetAll());
            ViewBag.streets = new SelectList(streets, "Id", "Street");

            return View("Edit", new PersonViewModel());
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<StreetDTO, StreetViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.Persons.Get(id));

            var streets = Mapper.Map<IEnumerable<StreetDTO>, List<StreetViewModel>>(_db.Streets.GetAll());
            ViewBag.streets = new SelectList(streets, "Id", "Street");

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personViewModel, string AddressId)
        {
            try
            {
                personViewModel.StreetId = int.Parse(AddressId);
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                Mapper.CreateMap<StreetViewModel, StreetDTO>();
                Mapper.CreateMap<PhoneViewModel, PhoneDTO>();
                var person = Mapper.Map<PersonViewModel, PersonDTO>(personViewModel);

                _db.Persons.Save(person);
                TempData["message"] = $"{person.FirstName} {person.LastName} has been saved";

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(personViewModel);
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _db.Persons.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View("Index");
            }
        }

        // GET: Person/CreateStreet
        public ActionResult CreateStreet()
        {
            return View(new StreetViewModel());
        }

        // POST: Person/CreateStreet
        public ActionResult CreateStreet(StreetViewModel street)
        {
            try
            {
                if (!ModelState.IsValid || street == null) return View();

                var config = new MapperConfiguration(cfg => cfg.CreateMap<StreetViewModel, StreetDTO>());
                var mapper = config.CreateMapper();
                var currentStreet = mapper.Map<StreetDTO>(street);
                _db.Streets.Save(currentStreet);

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View();
            }
        }
    }
}
