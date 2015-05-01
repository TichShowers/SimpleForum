using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SimpleForum.Datastore.Repositories;
using SimpleForum.Infrastructure.Common;
using SimpleForum.ViewModels;

namespace SimpleForum.Controllers
{
    public class AuthController : Controller
    {
        public UserRepository UserRepository { get; set; }

        public AuthController(UserRepository users)
        {
            UserRepository = users;
        }

        public ActionResult Login()
        {
            return View(new AuthLogin());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(AuthLogin model, string returnUrl)
        {
            var user = UserRepository.GetByUsername(model.Username);

            if (user == null)
            {
                Passwords.FakeHash(model.Password);
                return View(model);
            }

            if (!user.CheckPassword(model.Password))
            {
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(user.Username, true);

            return RedirectToRoute("Home");
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }
    }
}