using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InternalName { get; set; }
        public virtual IList<Group> Groups { get; set; }

        public Role()
        {
            Groups = new List<Group>();
        }
    }
}