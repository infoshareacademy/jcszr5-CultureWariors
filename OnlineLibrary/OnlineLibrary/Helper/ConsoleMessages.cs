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
            Console.WriteLine("Witaj w bibliotece online\n");
            Console.WriteLine("1 Zaloguj się");
            Console.WriteLine("2 Zarejestruj się");
            Console.WriteLine("3 Administrator");
            Console.WriteLine("4 O bibliotece");
            Console.WriteLine("5 Wyjdź");
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
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Przeglądaj książki");
            Console.WriteLine("2: Dodaj książki do wypożyczenia");
            Console.WriteLine("3: Zobacz wypożyczane książki");
            Console.WriteLine("4: Powróć do ekranu logowania");
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
        public static void UserAndLoginWrongCommand()
        {
            Console.WriteLine("Podałeś błędną komendę!");
            Console.WriteLine("Podaj numer od 1-4:");
        }
        public static void AdminWrongCommand()
        {
            Console.WriteLine("Podałeś błędną komendę!");
            Console.WriteLine("Podaj numer od 1-5:");
        }
        public static void Statistics(int allBooks,int fantasy,int criminals, int romanse, int science,int drama, int kids, int novels )
        {
            Console.Clear();
            Console.WriteLine("Biblioteka została stworzona przez zespół CULTURE WARRIORS!\n");
            Console.WriteLine($"W zasobach biblioteki znajduje się {allBooks} książęk!");
            Console.WriteLine($"Fantastyka: {fantasy} pozycji");
            Console.WriteLine($"Kryminały: {criminals} pozycji");
            Console.WriteLine($"Romanse: {romanse} pozycji");
            Console.WriteLine($"Naukowe: {science} pozycji");
            Console.WriteLine($"Dramaty: {drama} pozycji");
            Console.WriteLine($"Dziecięce: {kids} pozycji");
            Console.WriteLine($"Obyczajowe: {novels} pozycji");
            Console.WriteLine($"\n\nDzisiaj jest {DateTime.Now}");
        }
    }
}
