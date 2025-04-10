using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetCareSystem.Models;
using PetCareSystem.Data;

namespace PetCareSystem.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var users = db.Users.ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RegisterViewModel model, string selectedRole)
        {
            if (ModelState.IsValid)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    NombreCompleto = model.NombreCompleto,
                    Telefono = model.Telefono
                };

                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, selectedRole);
                    return RedirectToAction("Index");
                }
                AddErrors(result);
            }

            ViewBag.Roles = new SelectList(db.Roles.ToList(), "Name", "Name", selectedRole);
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
