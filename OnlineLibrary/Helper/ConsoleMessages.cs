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
            Console.WriteLine("4 O bibliotece");
            Console.WriteLine("5 Wyjdź");
        }
        public static void AdminMenu()
        {
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Dodaj książki");
            Console.WriteLine("2: Wyszukaj książkę po tytule lub autorze");
            Console.WriteLine("3: Przeglądaj książki po kategorii");
            Console.WriteLine("4: Usuń książki");
            Console.WriteLine("5: Edytuj książki");
            Console.WriteLine("6: Zamknij program");
            Console.WriteLine("\nCo chcesz zrobić? :");
        }
        public static void RegularUserMenu()
        {
            Console.Clear();
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Przeglądaj książki");
            Console.WriteLine("2: Wyszukaj książkę po tytule lub autorze");
            Console.WriteLine("3: Dodaj książki do wypożyczenia");
            Console.WriteLine("4: Zobacz wypożyczane książki");
            Console.WriteLine("5: Zaskocz mnie!");
            Console.WriteLine("6: Powróć do ekranu logowania");
            Console.WriteLine("\nCo chcesz zrobić? :");
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
            Console.ReadKey();
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
        public static void BookEditMenu()
        {
            Console.WriteLine("1.Edytuj całą książkę");
            Console.WriteLine("2.Edytuj tytuł");
            Console.WriteLine("3.Edytuj autora");
            Console.WriteLine("4.Edytuj typ książki");
            Console.WriteLine("\nWciśnij \"0\" jeżeli chcesz wrócić do menu.");

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
        public static void RandomBookMessage(Book blind)
        {
            Console.Clear();
            Console.WriteLine("Zobaczmy...");
            Thread.Sleep(700);
            Console.WriteLine("Co by Ci zaproponować...");
            Thread.Sleep(700);
            Console.WriteLine("Hmmm....");
            Thread.Sleep(700);
            Console.WriteLine("Może to ?\n\n");
            Console.WriteLine($"\n{blind.Title} {blind.Author} {blind.Type}\n");
            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
