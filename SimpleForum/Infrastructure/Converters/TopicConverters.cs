using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleForum.Models;
using SimpleForum.ViewModels;

namespace SimpleForum.Infrastructure.Converters
{
    public static class TopicConverters
    {
        public static TopicIndex ConvertToTopicIndex(this Topic source)
        {
            return new TopicIndex()
            {
                Name = source.Title,
                Posts = source.Posts.OrderByDescending(x=>x.CreatedAt).Select(x => x.ConvertToTopicPost())
            };
        }

        public static TopicPost ConvertToTopicPost(this Post source)
        {
            return new TopicPost()
            {
                Content = source.Content,
                Author = source.Author.ConvertUserToProfileLink(),
                PostedOn = source.CreatedAt
            };
        }
    }
}