using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.ViewModels
{
    public class UserView
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Groups { get; set; }
        public IEnumerable<UserTopic> TopicsMade { get; set; }
        public IEnumerable<UserTopic> TopicsPostedIn { get; set; } 
    }

    public class UserTopic
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
    }
}