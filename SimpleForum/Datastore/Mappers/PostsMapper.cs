using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Mappers
{
    public class PostsMapper : EntityTypeConfiguration<Post>
    {
        public PostsMapper()
        {
            HasKey(p => p.Id);

            HasRequired(p => p.Author).WithMany(u => u.Posts).WillCascadeOnDelete(false);

            Property(p => p.CreatedAt).IsRequired();
        }
    }
}