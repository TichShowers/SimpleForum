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
    public class HomeController : Controller
    {
        public ForumRepository ForumRepository { get; set; }

        public HomeController(ForumRepository repository)
        {
            ForumRepository = repository;
        }

        public ActionResult Index()
        {
            var categories = ForumRepository.GetAllCategories().ToList();

            return View(categories.ConvertToHomeIndex());
        }
    }
}