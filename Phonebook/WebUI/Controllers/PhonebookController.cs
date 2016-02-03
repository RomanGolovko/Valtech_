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
        private readonly IService<PersonDTO> _db;

        public PhonebookController(IService<PersonDTO> serv)
        {
            _db = serv;
        }

        // GET: Phonebook
        public ActionResult Index()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<AddressDTO, AddressViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAll());

            return View(persons);
        }

        // GET: Phonebook/Create
        public ActionResult Create()
        {
            return View("Edit", new PersonViewModel());
        }

        // GET: Phonebook/Edit/5
        public ActionResult Edit(int? id)
        {
            var streets = new List<string> { "Lenina street", "Karl Marks street", "Magnitogorskaya street", "Kirova street" };
            ViewBag.streets = new SelectList(streets);

            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<AddressDTO, AddressViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.Get(id));

            return View(person);
        }

        // POST: Phonebook/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personViewModel)
        {
            try
            {
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                Mapper.CreateMap<AddressViewModel, AddressDTO>();
                Mapper.CreateMap<PhoneViewModel, PhoneDTO>();
                var person = Mapper.Map<PersonViewModel, PersonDTO>(personViewModel);

                _db.Save(person);
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
                _db.Delete(id);
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
