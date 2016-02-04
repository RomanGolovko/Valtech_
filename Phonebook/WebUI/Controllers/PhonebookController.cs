using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PhonebookController : Controller
    {
        private readonly IBllUnitOfWork _db;

        public PhonebookController(IBllUnitOfWork buow)
        {
            _db = buow;
        }

        // GET: Phonebook
        public ActionResult Index()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<AddressDTO, AddressViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.Persons.GetAll());

            ViewBag.streets = Mapper.Map<IEnumerable<AddressDTO>, List<AddressViewModel>>(_db.Addresses.GetAll());

            return View(persons);
        }

        // GET: Phonebook/Create
        public ActionResult Create()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<AddressDTO, AddressViewModel>();
            var streets = Mapper.Map<IEnumerable<AddressDTO>, List<AddressViewModel>>(_db.Addresses.GetAll());
            ViewBag.streets = new SelectList(streets, "Id", "Street");

            return View("Edit", new PersonViewModel());
        }

        // GET: Phonebook/Edit/5
        public ActionResult Edit(int? id)
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<AddressDTO, AddressViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.Persons.Get(id));

            var streets = Mapper.Map<IEnumerable<AddressDTO>, List<AddressViewModel>>(_db.Addresses.GetAll());
            ViewBag.streets = new SelectList(streets, "Id", "Street");

            return View(person);
        }

        // POST: Phonebook/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personViewModel, string AddressId)
        {
            ///TODO: убрать костыль с AddressId, должен отрабатывать binder
            try
            {
                personViewModel.Phones[0].AddressId = int.Parse(AddressId);
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                Mapper.CreateMap<AddressViewModel, AddressDTO>();
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

        // GET: Phonebook/Delete/5
        public ActionResult Delete(int? id)
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
    }
}
