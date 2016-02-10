using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;
using Cross_Cutting.Security.ExceptionHandler;
using WebUI.Models;
using Microsoft.AspNet.Identity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Cross_Cutting.Security.Identity.Entities;

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
            var user = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().FindByEmail(User.Identity.Name);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, PersonModel>();
                cfg.CreateMap<PhoneDTO, PhoneModel>();
                cfg.CreateMap<StreetDTO, StreetModel>();
                cfg.CreateMap<CityDTO, CityModel>();
                cfg.CreateMap<CountryDTO, CountryModel>();
            });
            var mapper = config.CreateMapper();
            var persons = mapper.Map<IEnumerable<PersonDTO>, List<PersonModel>>(_db.PersonsService.GetAll(user.Id));

            return View(persons);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View("Edit", new PersonModel());
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PersonDTO, PersonModel>();
                cfg.CreateMap<PhoneDTO, PhoneModel>();
                cfg.CreateMap<StreetDTO, StreetModel>();
                cfg.CreateMap<CityDTO, CityModel>();
                cfg.CreateMap<CountryDTO, CountryModel>();
            });
            var mapper = config.CreateMapper();
            var person = mapper.Map<PersonModel>(_db.PersonsService.Get(id));

            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(PersonModel model)
        {
            try
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<PersonModel, PersonDTO>();
                    cfg.CreateMap<PhoneModel, PhoneDTO>();
                    cfg.CreateMap<StreetModel, StreetDTO>();
                    cfg.CreateMap<CityModel, CityDTO>();
                    cfg.CreateMap<CountryModel, CountryDTO>();
                });
                var mapper = config.CreateMapper();
                var person = mapper.Map<PersonDTO>(model);

                _db.PersonsService.Save(person);
                TempData["message"] = $"{person.FirstName} {person.LastName} has been saved";

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(model);
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _db.PersonsService.Delete(id);
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
