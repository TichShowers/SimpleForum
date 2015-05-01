using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Mappers
{
    public class ForumMapper : EntityTypeConfiguration<Forum>
    {
        public ForumMapper()
        {
            HasKey(f => f.Id);

            HasOptional(f => f.Parent).WithMany(f => f.SubForums);

            HasMany(f => f.Topics).WithRequired(t => t.Forum);

        }
    }
}