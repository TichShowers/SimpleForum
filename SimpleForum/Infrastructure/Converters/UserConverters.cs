using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ObjectBuilder2;
using SimpleForum.Models;
using SimpleForum.ViewModels;

namespace SimpleForum.Infrastructure.Converters
{
    public static class UserConverters
    {
        public static UserView ConvertToUserView(this User source)
        {
            return new UserView()
            {
                Username = source.Username,
                Email = source.Email,
                TopicsMade = source.Topics.Select(x => x.ConvertTopicToUserTopic()),
                TopicsPostedIn = source.Posts.Select(x => x.ConvertPostToUserTopic()),
                Groups = source.Groups.Select(x => x.Name).JoinStrings(", ")
            };
        }

        public static UserTopic ConvertTopicToUserTopic(this Topic source)
        {
            return new UserTopic()
            {
                Id = source.Id,
                Name = source.Title,
                Slug = source.Slug
            };
        }

        public static UserTopic ConvertPostToUserTopic(this Post source)
        {
            return source.Topic.ConvertTopicToUserTopic();
        }
    }
}