using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Agat.Models;

namespace Agat.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private ApplicationSignInManager _signInManager;
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        // GET: Employee
        public ActionResult Index()
        {
            EmployeeViewModel model = new EmployeeViewModel();
            model.GetList();
            return View(model);
        }
        public ActionResult Add()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(AddEmployeeViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.AddEmployee();

            return RedirectToAction("Index");
        }
        public ActionResult EditEmployee(int id)
        {
            EditEmployeeViewModel model = new EditEmployeeViewModel();
            model.Get(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(EditEmployeeViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            model.EditEmployee();
            return RedirectToAction("Index");
        }
        public ActionResult AddUser()
        {
            AddEmployeeUserViewModel model = new AddEmployeeUserViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser(AddEmployeeUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Login, Email = model.email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    model.AddEmployee(user.Id);
                    return RedirectToAction("Index", "Employee");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #region Helpers
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        #endregion
    }
}