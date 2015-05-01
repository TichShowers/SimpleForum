using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Mappers
{
    public class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            HasKey(u => u.Id);

            HasMany(y => y.Groups).WithMany(g => g.Users).Map(m => m.ToTable("UserGroups"));
        }
    }
}