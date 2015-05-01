using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.Practices.ObjectBuilder2;

namespace SimpleForum.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify<T>(this T target, Func<T, string> function)
        {
            return function(target).Slugify();
        }

        public static string Slugify(this string target)
        {
            var current = Regex.Replace(target, @"[^a-zA-Z0-9\s]", "");
            current = current.ToLower();
            current = Regex.Replace(current, @"\s", "-");

            return current;
        }

        public static Tuple<int, string> SplitIdFromSlug(this string source)
        {
            var matches = Regex.Match(source, @"^(\d+)\-(.*)?$");

            if (!matches.Success)
            {
                return null;
            }

            var id = int.Parse(matches.Result("$1"));
            var slug = matches.Result("$2");

            return Tuple.Create(id, slug);
        }
    }
}