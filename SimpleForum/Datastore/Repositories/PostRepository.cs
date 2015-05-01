using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Datastore.Contracts;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Repositories
{
    public class PostRepository : EfRepository<Post>
    {
        public PostRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}