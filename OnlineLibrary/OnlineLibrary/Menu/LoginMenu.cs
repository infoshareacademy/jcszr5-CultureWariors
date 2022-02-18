using System.Security;
namespace OnlineLibrary
{
    public class LoginMenu : IMenu
    {
        public void Login(AdminMenu adminMenu, RegularUserMenu regularUserMenu, Admin admin, Library library, UsersList usersList)
        {
            while (true)
            {
                ShowMenu();
                switch (NavigateMenu())
                {
                    case 1:

                        RegularUser user = usersList.GetRegularUser(Helper.GetUsername(), Helper.GetPassword());
                        if (user != null)
                        {
                            regularUserMenu.RegularUser(user, library);
                            break;
                        }
                        else
                        {
                            ConsoleMessages.WrongLoginOrPassword();
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
                            ConsoleMessages.WrongLoginOrPassword();
                            break;
                        }
                    case 4:
                        library.AboutLibrary();
                        break;
                        
                    case 5:
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
                    ConsoleMessages.WrongCommand("4");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 5)
                    {
                        break;
                    }
                    ConsoleMessages.WrongCommand("4");
                }
            }
            return navigate;
        }

    }
}
