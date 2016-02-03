using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BLL.Abstract;
using BLL.DTO;
using Cross_Cutting.Security;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IService<AddressDTO> _db;

        public AddressController(IService<AddressDTO> serv)
        {
            _db = serv;
        } 

        // GET: Address
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, AddressViewModel>());
            var mapper = config.CreateMapper();

            return View(mapper.Map<IEnumerable<AddressViewModel>>(_db.GetAll()));
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View("Edit", new AddressViewModel());
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressDTO, AddressViewModel>());
            var mapper = config.CreateMapper();

            return View(mapper.Map<AddressViewModel>(_db.Get(id)));
        }

        // POST: Address/Edit/5
        [HttpPost]
        public ActionResult Edit(AddressViewModel addressViewModel)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AddressViewModel, AddressDTO>());
                var mapper = config.CreateMapper();
                var address = mapper.Map<AddressDTO>(addressViewModel);

                _db.Save(address);
                TempData["message"] = $"{address.Street} has been saved";

                return RedirectToAction("Index");
            }
            catch(ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
                return View(addressViewModel);
            }
        }

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
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
