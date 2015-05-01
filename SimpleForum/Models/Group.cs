using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace SimpleForum.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Role> Roles { get; set; }
        public virtual IList<User> Users { get; set; }

        public Group()
        {
            Roles = new List<Role>();
            Users = new List<User>();
        }
    }
}