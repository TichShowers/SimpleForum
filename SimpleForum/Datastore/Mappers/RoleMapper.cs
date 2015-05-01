using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Datastore.Mappers
{
    public class RoleMapper : EntityTypeConfiguration<Role>
    {
        public RoleMapper()
        {
            HasKey(r => r.Id);
            HasMany(r => r.Groups).WithMany(g => g.Roles).Map(m => m.ToTable("GroupRoles"));
        }
    }
}