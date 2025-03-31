using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShelf_Business
{
    public class AppHelper
    {
        public static string GetDBConnectionString()
        {
            return "Server=(localdb)\\MSSQLLocalDB;Database=MyShelf;Trusted_Connection=True;";
        }

        public static string GeneratePasswordHash(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            return passwordHash;
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }
    }
}
