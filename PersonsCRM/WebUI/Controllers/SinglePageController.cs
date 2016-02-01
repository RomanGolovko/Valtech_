using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class SinglePageController : Controller
    {
        private readonly IService _db;

        public SinglePageController(IService serv)
        {
            _db = serv;

        }

        // GET: Person
        public ActionResult Index()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAllPersons());

            return View(persons);
        }

        // Get: Person/Create
        public ActionResult Create()
        {
            return PartialView("Edit", new PersonViewModel());
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();

            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.GetPerson(id));

            return PartialView(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personViewModel)
        {
            try
            {
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                Mapper.CreateMap<PhoneViewModel, PhoneDTO>();

                var person = Mapper.Map<PersonViewModel, PersonDTO>(personViewModel);

                _db.SavePerson(person);
                TempData["message"] = $"{person.FirstName} {person.LastName} has been saved";

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return PartialView(personViewModel);
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                _db.DeletePerson(id);
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
