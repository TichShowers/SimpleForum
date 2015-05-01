﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SimpleForum.Datastore.Contracts;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Repositories
{
    public class GroupRepository : EfRepository<Group>
    {
        public GroupRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}