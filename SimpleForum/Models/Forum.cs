using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool AcceptsNewTopics { get; set; }
        public int Weight { get; set; }
        public virtual IList<Topic> Topics { get; set; }
        public virtual Forum Parent { get; set; }
        public virtual IList<Forum> SubForums { get; set; }

        public int GetAmountOfReplies()
        {
            return Topics.Sum(topic => topic.Posts.Count);
        }

        public DateTime GetLastReplyTime()
        {
            var lastTopic = Topics.OrderByDescending(t => t.LastPostedAt).FirstOrDefault();
            if (lastTopic == null)
            {
                return DateTime.UtcNow;
            }
            return lastTopic.LastPostedAt;
        }

    }
}