using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Datastore.Contracts;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Repositories
{
    public class UserRepository : EfRepository<User>
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public User GetByUsername(string username)
        {
            return DbSet.FirstOrDefault(u => u.Username == username);
        }
    }
}