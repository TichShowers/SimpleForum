using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleForum.Models;
using SimpleForum.ViewModels;

namespace SimpleForum.Infrastructure.Converters
{
    public static class HomeConverters
    {
        public static HomeIndex ConvertToHomeIndex(this IEnumerable<Forum> source)
        {
            return new HomeIndex() {Categories = source.Select(f => f.ConverCategories())};
        }

        public static HomeCategory ConverCategories(this Forum source)
        {
            return new HomeCategory()
            {
                Name = source.Name,
                Forums = source.SubForums.Select(f => f.ConvertToHomeForum())
            };
        }

        public static HomeForum ConvertToHomeForum(this Forum source)
        {
            return new HomeForum()
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
    }
}