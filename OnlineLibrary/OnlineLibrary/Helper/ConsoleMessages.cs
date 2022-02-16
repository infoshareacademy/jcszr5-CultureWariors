namespace OnlineLibrary
{
    public static class ConsoleMessages
    {
        public static void ChooseCategoryMessage()
        {
            Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:\n");
            Console.WriteLine("1 Fantastyka");
            Console.WriteLine("2 Kryminał");
            Console.WriteLine("3 Romans");
            Console.WriteLine("4 Naukowa");
            Console.WriteLine("5 Dramat");
            Console.WriteLine("6 Dziecięca");
            Console.WriteLine("7 Obyczajowa");
        }
        public static void LoginMenu()
        {
            Console.WriteLine("1 Zaloguj się");
            Console.WriteLine("2 Zarejestruj się");
            Console.WriteLine("3 Administrator");
            Console.WriteLine("4 Wyjdź");
        }
        public static void AdminMenu()
        {
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Dodaj książki");
            Console.WriteLine("2: Przeglądaj książki");
            Console.WriteLine("3: Usuń książki");
            Console.WriteLine("4: Edytuj książki");
            Console.WriteLine("5: Zamknij program");
            Console.WriteLine("\nCo chcesz zrobić? :");
        }
        public static void RegularUserMenu()
        {
            Console.Clear();
            Console.WriteLine("1: Przeglądaj książki");
            Console.WriteLine("2: Dodaj książki do wypożyczenia");
            Console.WriteLine("3: Zobacz wypożyczane książki");
            Console.WriteLine("4: Powróć do ekranu logowania");
        }
        public static void ChooseAnyKey()
        {
            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
        }
        public static void ChooseTheRightCategory()
        {
            Console.WriteLine("Proszę wybrać właściwą kategorię");
        }
        public static void WrongIndex()
        { Console.WriteLine("Prosze wybrać właściwy indeks"); }
        public static void SuccesMessage(string done)
        {
            Console.WriteLine($"Pomyślnie {done} książkę, nacisnij dowolny przycisk aby powrócić do menu");
        }
        public static void WrongLoginOrPassword()
        {
            Console.Clear();
            Console.WriteLine("Błędne dane do logowania\n");
        }
        
        public static void WrongCommand(string choice)
        {
            
            Console.WriteLine("Podałeś błędną komendę!");
            Console.WriteLine($"Podaj numer od 1-{choice}:\n");
            
        }
        
    }
}
