using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using WebUI.Models;
using Cross_Cutting.Security;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService _db;

        public HomeController(IService personService)
        {
            _db = personService;
        }

        // GET: Home
        public ActionResult Index()
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAllPersons());

            return View(persons);
        }

        // GET: Home/Grid
        public ActionResult Grid()
        {
            Mapper.CreateMap<PersonDTO, PersonViewModel>();
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            var persons = Mapper.Map<IEnumerable<PersonDTO>, List<PersonViewModel>>(_db.GetAllPersons());

            return View(persons);
        }

        // // GET: Home/JqGrid
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

        // Get: Home/Create
        public ActionResult Create()
        {
            return View("Edit", new PersonViewModel());
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            Mapper.CreateMap<PhoneDTO, PhoneViewModel>();
            Mapper.CreateMap<PersonDTO, PersonViewModel>();

            var person = Mapper.Map<PersonDTO, PersonViewModel>(_db.GetPerson(id));

            return View(person);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonViewModel personModel, PhoneViewModel phoneModel)
        {
            try
            {
                Mapper.CreateMap<PersonViewModel, PersonDTO>();
                Mapper.CreateMap<PhoneViewModel, PhoneDTO>();

                var person = Mapper.Map<PersonViewModel, PersonDTO>(personModel);
                var phone = Mapper.Map<PhoneViewModel, PhoneDTO>(phoneModel);

                if (person.Phones.Find(p => p.Id == phone.Id) != null)
                {
                    person.Phones.Find(p => p.Id == phone.Id).Number = phone.Number;
                    person.Phones.Find(p => p.Id == phone.Id).Type = phone.Type;
                }
                else
                {
                    person.Phones.Add(phone);
                }

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

        // GET: Home/Delete/5
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