using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleForum.Models;
using SimpleForum.ViewModels;

namespace SimpleForum.Infrastructure.Converters
{
    public static class ForumConverters
    {
        public static ForumIndex ConvertForumToForumIndex(this Forum source)
        {
            return new ForumIndex()
            {
                Id = source.Id,
                Name = source.Name,
                SubForums = source.SubForums.Select(x => x.ConvertToForumSubForums()),
                Topics = source.Topics.Select(x => x.ConvertToForumTopic())
            };
        }

        public static ForumSubForums ConvertToForumSubForums(this Forum source)
        {
            return new ForumSubForums()
            {
                Id = source.Id,
                Description = source.Description,
                Name = source.Name,
                Slug = source.Slug,
                LastReplyTime = source.GetLastReplyTime(),
                TotalReplies = source.GetAmountOfReplies(),
                TotalTopics = source.Topics.Count
            };
        }

        public static ForumTopic ConvertToForumTopic(this Topic source)
        {
            return new ForumTopic()
            {
                Id = source.Id,
                Slug = source.Slug,
                Author = source.Creator.ConvertUserToProfileLink(),
                CreatedTime = source.CreatedAt,
                LastReplyTime = source.LastPostedAt,
                Name = source.Title,
                ReplyCount = source.Posts.Count
            };
        }
    }
}