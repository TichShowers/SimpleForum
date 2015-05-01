using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleForum.Datastore.Repositories;
using SimpleForum.Infrastructure.Converters;
using SimpleForum.Infrastructure.Extensions;

namespace SimpleForum.Controllers
{
    public class ProfileController : Controller
    {
        public UserRepository UserRepository { get; set; }

        public ProfileController(UserRepository repository)
        {
            UserRepository = repository;
        }

        // GET: Profile
// ReSharper disable once CSharpWarnings::CS0108
        public ActionResult View(string idAndSlug)
        {
            var parts = idAndSlug.SplitIdFromSlug();

            if (parts == null)
                return HttpNotFound();

            var user = UserRepository.GetById(parts.Item1);

            if (user == null)
                return HttpNotFound();

            if (!user.Slug.Equals(parts.Item2, StringComparison.CurrentCultureIgnoreCase))
                return RedirectToRoutePermanent("User", new { id = parts.Item1, slug = user.Slug });

            return View(user.ConvertToUserView());
        }
    }
}