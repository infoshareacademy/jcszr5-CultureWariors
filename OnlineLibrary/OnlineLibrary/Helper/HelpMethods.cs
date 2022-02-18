using System.Security;
    namespace OnlineLibrary
{
    public static class Helper
    {
        public static bool CreateUserValidation(string username, string password, List<RegularUser> usersList)
        {
            while (true)
            {
                if (username.Length < 5 && password.Length < 5)
                {
                    Console.WriteLine("Zbyt krótka nazwa użytkownika lub hasło");
                    return false;
                }

                else if (usersList.Any(u => u.Username == username)) //LINQ fun
                {
                    Console.WriteLine("Taki użytkownik już istnieje");
                    return false;
                }
                else break;
            }
            return true;
        }
        public static string GetUsername()
        {
            Console.Clear();
            Console.WriteLine("Nazwa użytkownika:");
            return Console.ReadLine();
        }

        public static string GetPassword()
        {
            Console.Clear();
            Console.WriteLine("Wprowadz hasło:");
            SecureString password = new SecureString();
            char sign = new char();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (!char.IsControl(key.KeyChar))
                {
                    password.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.RemoveAt(password.Length - 1);
                    Console.Write("\b \b");
                }
            }

            while (key.Key != ConsoleKey.Enter);
            {
                string stringPassword = new System.Net.NetworkCredential(string.Empty, password).Password;
                return stringPassword;
            }

        }

        //Przeniosłem get author i get title w celu ponownego użycia
        //przy wyszukiwaniu książki po autorze lub tytule
        public static string GetAuthor()
        {
            Console.Clear();
            Console.WriteLine("Wprowadź autora:");
            return Console.ReadLine();
        }
        public static string GetTitle()
        {
            Console.Clear();
            Console.WriteLine("Wprowadź nazwę książki:");
            return Console.ReadLine();
        }
        public static int Navigate()
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
                    if (navigate >= 0 && navigate <= 4)
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

