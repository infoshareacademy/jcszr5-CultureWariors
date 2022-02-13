using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class LoginMenu : IMenu
    {
        public void Login(AdminMenu adminMenu, RegularUserMenu regularUserMenu, Admin admin, Library library,UsersList usersList)
        {
            while (true)
            {
                ShowMenu();
                switch (NavigateMenu())
                {
                    case 1:
                        RegularUser user = usersList.GetRegularUser(usersList.EnterUsername(), usersList.EnterPassword());
                        if (user != null)
                        {
                            regularUserMenu.RegularUser(user, library);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Błędne dane do logowania");
                            break;
                        }
                    case 2:
                        usersList.AddUser();
                        WriteData.WriteUsersToFile(usersList);
                        break;
                    case 3:
                        if (admin.AdminLogin())
                        {
                            adminMenu.AdminUser(admin, library);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Błędne dane do logowania\n");
                            break;
                        }
                    case 4:
                        Console.WriteLine("Do widzenia!");
                        Environment.Exit(0);
                        break;
                }
            }
        }
            
        
        public void ShowMenu()
        {
            ConsoleMessages.LoginMenu();
        }

        public int NavigateMenu()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
            }
            return navigate;
        }

    }
}
