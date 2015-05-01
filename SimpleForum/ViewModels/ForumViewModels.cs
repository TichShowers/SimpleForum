using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.ViewModels
{
    public class ForumIndex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ForumSubForums> SubForums { get; set; }
        public IEnumerable<ForumTopic> Topics { get; set; } 
    }

    public class ForumSubForums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int TotalTopics { get; set; }
        public DateTime LastReplyTime { get; set; }
        public int TotalReplies { get; set; }
    }

    public class ForumTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public SharedProfileLink Author { get; set; }
        public DateTime LastReplyTime { get; set; }
        public int ReplyCount { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}