using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class UsersList
    {
        private List<RegularUser> users = new List<RegularUser>();

        public void AddUser()
        {
            Console.Clear();
            Console.WriteLine("Wprowadź nazwę użytkownika: ");
            string username = Console.ReadLine();
            Console.WriteLine("Wprowadź hasło: ");
            string password = Console.ReadLine();
            Console.Clear();
            RegularUser user = new RegularUser(username,password);
            users.Add(user);
            Console.WriteLine("Pomyślnie dodano użytkownika, naciśnij dowolny przycisk aby kontynuować");
            Console.ReadKey();
            Console.Clear();
        }
        public string EnterUsername()
        {
            Console.Clear();
            Console.WriteLine("Username:");
            return Console.ReadLine();
        }
        public string EnterPassword()
        {
            Console.WriteLine("Password:");
            return Console.ReadLine();
        }

        public RegularUser GetRegularUser(string username, string password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;

        }
        public bool UserLoginCheck(string username,string  password)
        {
            foreach (var user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
