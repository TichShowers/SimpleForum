using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Mappers
{
    public class GroupMapper : EntityTypeConfiguration<Group>
    {
        public GroupMapper()
        {
            HasKey(g => g.Id);
        }
    }
}