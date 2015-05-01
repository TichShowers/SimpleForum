using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.UI;
using SimpleForum.Datastore.Repositories;
using SimpleForum.Infrastructure.Converters;
using SimpleForum.Infrastructure.Extensions;
using SimpleForum.Models;

namespace SimpleForum.Controllers
{
    public class TopicController : Controller
    {
        public TopicRepository TopicRepository { get; set; }

        public TopicController(TopicRepository repository)
        {
            TopicRepository = repository;
        }

        public ActionResult Index(string idAndSlug, int page = 1)
        {
            var parts = idAndSlug.SplitIdFromSlug();

            if (parts == null)
                return HttpNotFound();

            var topic = TopicRepository.GetById(parts.Item1);

            if (topic == null)
                return HttpNotFound();

            if (!topic.Slug.Equals(parts.Item2, StringComparison.CurrentCultureIgnoreCase))
                return RedirectToRoutePermanent("Topic", new { id = parts.Item1, slug = topic.Slug});

            return View(topic.ConvertToTopicIndex());
        }
    }
}