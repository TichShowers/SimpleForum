using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Datastore.Mappers;
using SimpleForum.Models;

namespace SimpleForum.Datastore
{
    public class ProjectContext : DbContext
    {

        public ProjectContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new ProjectInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new RoleMapper());
            modelBuilder.Configurations.Add(new GroupMapper());
            modelBuilder.Configurations.Add(new TopicMapper());
            modelBuilder.Configurations.Add(new ForumMapper());
            modelBuilder.Configurations.Add(new PostsMapper());
        }
    }
}