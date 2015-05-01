using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual User Author { get; set; }
        public virtual Topic Topic { get; set; }
    }
}