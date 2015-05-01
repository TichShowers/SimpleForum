using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleForum
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );

            routes.MapRoute("UserWithIdAndSlug", "user/{idAndSlug}", new { controller = "Profile", action = "View" });
            routes.MapRoute("User", "user/{id}-{slug}", new { controller = "profile", action = "View" });

            routes.MapRoute("ForumWithIdAndSlug", "forum/{idAndSlug}", new { controller = "Forum", action = "Index" });
            routes.MapRoute("Forum", "forum/{id}-{slug}", new { controller = "Forum", action = "Index" });

            routes.MapRoute("TopicWithIdAndSlug", "topic/{idAndSlug}", new { controller = "Topic", action = "Index" });
            routes.MapRoute("Topic", "topic/{id}-{slug}", new { controller = "Topic", action = "Index" });
        }
    }
}
