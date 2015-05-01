using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public virtual Forum Forum { get; set; }
        public virtual User Creator { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastPostedAt { get; set; }
        public virtual IList<Post> Posts { get; set; }
    }
}