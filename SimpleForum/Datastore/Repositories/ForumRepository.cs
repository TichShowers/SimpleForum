using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Datastore.Contracts;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Repositories
{
    public class ForumRepository : EfRepository<Forum>
    {
        public ForumRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<Forum> GetAllCategories()
        {
            return DbSet.Where(f => f.Parent == null).OrderBy(f => f.Weight + f.Name);
        }
    }
}