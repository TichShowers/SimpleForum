using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleForum.Models;
using SimpleForum.ViewModels;

namespace SimpleForum.Infrastructure.Converters
{
    public static class SharedExtensions
    {
        public static SharedProfileLink ConvertUserToProfileLink(this User source)
        {
            return new SharedProfileLink()
            {
                Id = source.Id,
                Slug = source.Slug,
                Username = source.Username
            };
        }
    }
}