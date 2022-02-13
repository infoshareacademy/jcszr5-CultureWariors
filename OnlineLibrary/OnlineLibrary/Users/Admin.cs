using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class Admin : User
    {

        public Admin(string username = "Admin", string password = "12345") : base(username, password)
        {

        }
        public bool AdminLogin()
        {
            string usernameCheck;
            string passwordCheck;
            Console.Clear();
            Console.WriteLine("Username:");
            usernameCheck = Console.ReadLine();
            Console.WriteLine("Password:");
            passwordCheck = Console.ReadLine();
            if (usernameCheck == Username && passwordCheck == Password)
            {
                return true;
            }
            return false;
        }
    }
}
