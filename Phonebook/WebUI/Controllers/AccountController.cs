using AutoMapper;
using Cross_Cutting.Security.Identity.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserModel>().ReverseMap());
            var mapper = config.CreateMapper();
            var currentUser = UserManager.FindByEmail(User.Identity.Name);
            var user = mapper.Map<ApplicationUser, UserModel>(currentUser);

            return View(user);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Name = model.Name, Email = model.Email, Age = model.Age, Image = model.Image };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }

            return View(model);
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindAsync(model.Email, model.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }
                else
                {
                    var claim = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);

                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction(returnUrl);
                    }
                }
            }

            ViewBag.returnUrl = returnUrl;

            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            var user = await UserManager.FindByEmailAsync(User.Identity.Name);

            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> Edit()
        {
            var user = await UserManager.FindByEmailAsync(User.Identity.Name);

            if (user != null)
            {
                var model = new EditModel { Age = user.Age, Image = user.Image };
                return View(model);
            }

            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model, HttpPostedFile uploadImage)
        {
            var user = await UserManager.FindByEmailAsync(User.Identity.Name);

            if (user != null)
            {
                user.Name = model.Name;
                user.Age = model.Age;

                if (ModelState.IsValid && uploadImage != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }

                    user.Image = imageData;
                }

                var result = await UserManager.UpdateAsync(user);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Something going wrong");
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }

            return View(model);
        }
    }
}