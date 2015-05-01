using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Slug { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public virtual IList<Group> Groups { get; set; }
        public virtual IList<Topic> Topics { get; set; }
        public virtual IList<Post> Posts { get; set; }

        public User()
        {
            Groups = new List<Group>();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return Groups.SelectMany(g => g.Roles).Distinct();
        } 
    }
}