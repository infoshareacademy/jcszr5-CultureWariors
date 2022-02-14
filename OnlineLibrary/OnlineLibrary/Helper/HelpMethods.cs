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
            Console.WriteLine("Username:");
            return Console.ReadLine();
        }
        public static string GetPassword()
        {
            Console.Clear();
            Console.WriteLine("Password:");
            return Console.ReadLine();
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
    }
}

