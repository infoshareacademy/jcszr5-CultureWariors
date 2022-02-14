using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class UsersList
    {
        public List<RegularUser> Users { get; set; }
        public UsersList()
        {
            Users = new List<RegularUser>();
        }
        public void AddUser()
        {
            RegularUser user = CreateUser();
            Users.Add(user);
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
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }

            return null;

        }
        public bool UserLoginCheck(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public RegularUser CreateUser()
        {
            string username;
            string password;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Wprowadź nazwę użytkownika: ");
                username = Console.ReadLine();
                Console.WriteLine("Wprowadź hasło: ");
                password = Console.ReadLine();
                if (username.Length < 5 && password.Length < 5)
                {
                    Console.WriteLine("Zbyt krótka nazwa użytkownika lub hasło");
                }

                else if (Users.Where(u => u.Username == username).Any()) //LINQ fun
                {
                    Console.WriteLine("Taki użytkownik już istnieje");
                }
                else break;

            }
            RegularUser user = new RegularUser(username, password);
            Console.Clear();
            return user;
            
            
            
        }
    }
}
