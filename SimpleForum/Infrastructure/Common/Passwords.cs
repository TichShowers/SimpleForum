using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleForum.Models;

namespace SimpleForum.Infrastructure.Common
{
    public static class Passwords
    {
        private const int Workfactor = 13;

        public static void SetPassword(this User target, string password)
        {
            target.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password, Workfactor);
        }

        public static bool CheckPassword(this User target, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, target.PasswordHash);
        }

        public static void FakeHash(string password)
        {
            BCrypt.Net.BCrypt.HashPassword(password, Workfactor);
        }
    }
}