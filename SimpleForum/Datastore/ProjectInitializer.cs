using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Infrastructure.Common;
using SimpleForum.Infrastructure.Extensions;
using SimpleForum.Models;

namespace SimpleForum.Datastore
{
    public class ProjectInitializer : DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            DefaultSeed(context);

            var tich = new User() { Username = "Tich", Slug = "Tich".Slugify() };
            tich.SetPassword("apples");

            context.Users.Add(tich);

            context.SaveChanges();
        }

        private void DefaultSeed(ProjectContext context)
        {
            //Roles

            var roles = new List<Role>()
            {
                new Role() { InternalName = "administrator" , Name = "Administrator"},
                new Role() { InternalName = "moderator", Name = "Moderator"}
            };

            context.Roles.AddRange(roles);

            context.SaveChanges();

            //Groups

            var administrator = new Group()
            {
                Name = "Administrator", Roles = roles
            };

            var global_moderator = new Group()
            {
                Name = "Global Moderator",
                Roles = roles.Where(r => r.InternalName == "moderator").ToList()
            };

            var users = new Group() { Name = "Users" };

            context.Groups.Add(administrator);
            context.Groups.Add(global_moderator);
            context.Groups.Add(users);

            //First user

            var root = new User() { Username = "root", Slug ="root".Slugify()};
            root.Groups.Add(administrator);
            root.SetPassword("letmein");

            context.Users.Add(root);

            context.SaveChanges();
            //Sample Forum

            var cat = new Forum()
            {
                Name = "Sample Category",
                Slug = "Sample Category".Slugify(),
                Weight = 0
            };

            context.Forums.Add(cat);

            var forum = new Forum()
            {
                Name = "Sample Forum",
                Slug = "Sample Forum".Slugify(),
                Weight = 0,
                Parent = cat,
                Description = "This is a sample forum"
            };

            context.Forums.Add(forum);

            context.SaveChanges();

            // Sample Topic

            var topic = new Topic()
            {
                CreatedAt = DateTime.UtcNow,
                LastPostedAt = DateTime.UtcNow,
                Creator = root,
                Forum = forum,
                Title = "Sample Topic",
                Slug = "Sample Topic".Slugify()
            };

            context.Topics.Add(topic);
            context.SaveChanges();

            var post = new Post()
            {
                Author = root, 
                Content = "This is a first topic, with a first post",
                CreatedAt = DateTime.UtcNow,
                Topic = topic
            };

            context.Posts.Add(post);

            context.SaveChanges();

        }
    }
}