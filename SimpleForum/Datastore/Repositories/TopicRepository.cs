using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Datastore.Contracts;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Repositories
{
    public class TopicRepository : EfRepository<Topic>
    {
        public TopicRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}