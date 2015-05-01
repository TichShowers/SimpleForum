using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.ViewModels
{
    public class TopicIndex
    {
        public string Name { get; set; }
        public IEnumerable<TopicPost> Posts { get; set; }
    }

    public class TopicPost
    {
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public SharedProfileLink Author { get; set; }
    }
}