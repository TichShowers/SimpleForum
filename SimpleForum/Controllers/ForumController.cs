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
    public class ForumController : Controller
    {
        public ForumRepository ForumRepository { get; set; }

        public ForumController(ForumRepository repository)
        {
            ForumRepository = repository;
        }

        // GET: Forum
        public ActionResult Index(string idAndSlug, int page = 1)
        {
            var parts = idAndSlug.SplitIdFromSlug();

            if (parts == null)
                return HttpNotFound();

            var forum = ForumRepository.GetById(parts.Item1);

            if (forum == null)
                return HttpNotFound();

            if (!forum.Slug.Equals(parts.Item2, StringComparison.CurrentCultureIgnoreCase))
                return RedirectToRoutePermanent("Forum", new { id = parts.Item1, slug = forum.Slug });

            return View(forum.ConvertForumToForumIndex());
        }
    }
}