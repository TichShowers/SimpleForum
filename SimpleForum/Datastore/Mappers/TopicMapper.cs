using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Mappers
{
    public class TopicMapper : EntityTypeConfiguration<Topic>
    {
        public TopicMapper()
        {
            HasKey(t => t.Id);

            HasMany(t => t.Posts).WithRequired(p => p.Topic);

            HasRequired(t => t.Creator).WithMany(u => u.Topics).WillCascadeOnDelete(false);

            Property(p => p.CreatedAt).IsRequired();
        }
    }
}