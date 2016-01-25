using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PersonController : Controller
    {
        private readonly IService _db;

        public PersonController(IService serv)
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

        // GET: Home/JqGrid
        public ActionResult JqGrid()
        {
            return View();
        }

        public string GetData()
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAllPersons());

            return JsonConvert.SerializeObject(persons);
        }

        // Get: Person/Create
        public ActionResult Create()
        {
            return View("Edit", new PersonViewModel());
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();

            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.GetPerson(id));

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personModel)
        {
            try
            {
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                Mapper.CreateMap<PhoneViewModel, PhoneDTO>();

                var person = Mapper.Map<PersonViewModel, PersonDTO>(personModel);

                _db.SavePerson(person);
                TempData["message"] = $"{person.FirstName} {person.LastName} has been saved";

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(personModel);
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