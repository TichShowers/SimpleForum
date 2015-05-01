using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleForum.ViewModels
{
    public class HomeIndex
    {
        public IEnumerable<HomeCategory> Categories { get; set; }
    }

    public class HomeCategory
    {
        public string Name { get; set; }
        public IEnumerable<HomeForum> Forums { get; set; }
    }

    public class HomeForum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int TotalTopics { get; set; }
        public DateTime LastReplyTime { get; set; }
        public int TotalReplies { get; set; }
    }


}