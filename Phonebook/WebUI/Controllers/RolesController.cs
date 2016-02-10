using AutoMapper;
using Cross_Cutting.Security.Identity.Entities;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class RolesController : Controller
    {
        private ApplicationRoleManager RoleManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }

        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationRole, RoleModel>()).CreateMapper();
            var roles = mapper.Map<IEnumerable<ApplicationRole>, List<RoleModel>>(RoleManager.Roles);

            return View(roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await RoleManager.CreateAsync(new ApplicationRole
                {
                    Name = model.Name,
                    Description = model.Description
                });

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Some thing going wrong");
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            if (role != null)
            {
                return View(new EditRoleModel { Id = role.Id, Name = role.Name, Description = role.Description });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationRole role = await RoleManager.FindByIdAsync(model.Id);

                if (role != null)
                {
                    role.Description = model.Description;
                    role.Name = model.Name;
                    var result = await RoleManager.UpdateAsync(role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Some thing going wrong");
                    }
                }
            }

            return View(model);
        }

        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await RoleManager.DeleteAsync(role);
            }

            return RedirectToAction("Index");
        }
    }
}