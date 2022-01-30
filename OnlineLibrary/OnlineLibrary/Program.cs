using System.Text.Json;
using System.Text.Json.Nodes;
using OnlineLibrary;

int navigate;
Library library = new Library();
Console.WriteLine("Witaj W bibliotece Online!");
MainMenu();
while (true)
{
    if (navigate == 1)
    {

        string y;

        Console.Clear();
        Console.WriteLine("Podaj ilość książek, które chciałbyś dodać:");
        library.Capacity = Capacity();
        for (int i = 1; i < library.Capacity + 1; i++)
        {
            Book book = new Book();
            book.Type = book.Types(book.ChooseType());
            Console.Clear();
            Console.WriteLine($"Wybrany typ to: {book.Type}");
            Console.WriteLine("\nWprowadź tutuł:");
            book.Title = Console.ReadLine();
            Console.WriteLine("\nPodaj autora:");
            book.Author = Console.ReadLine();
            Console.Clear();
            library.AddBook(book);
        }

        Console.WriteLine("Dodane pozycje:");
        library.PrintLibrary();
        Console.WriteLine("\nKsiążki zostały dodane do biblioteki");
        Console.WriteLine("\nWciśnij 'y' jeżeli chcesz wrócić do menu głównego");
        y = Console.ReadLine();
        if (y == "y")
        {
            Console.Clear();
            MainMenu();
        }
        else
        {
            Environment.Exit(0);
        }
    }

    int Capacity()
    {
        int capacity;
        string check;
        do
        {
            check = Console.ReadLine();
            if (!int.TryParse(check, out capacity))
            {
                Console.WriteLine("Podaj numer");
            }
            else if (capacity <= 0)
            {
                Console.WriteLine("Podaj wartość większą od zera");
            }

        } while (!int.TryParse(check, out capacity) || capacity <= 0);

        return capacity;
    }

    if (navigate == 2)
    {
        Console.Clear();
        Console.WriteLine("Wybierz typ książki");
        library.ChooseBookTypeToFind(library.ChooseTypeToFind());
        Console.Clear();
        MainMenu();
    }

    if (navigate == 3)
    {
        Console.Clear();
        library.DeleteBook();
        Console.Clear();
        MainMenu();
    }

    if (navigate == 4)
    {
        Console.WriteLine("Dodaj do przeczytanych");
    }

    if (navigate == 5)
    {
        Console.Clear();
        string json = JsonSerializer.Serialize(library.books);
        File.WriteAllText(@".\path123.json", json);
        Console.WriteLine("Ksiązki zostały zapisane");
        MainMenu();
    }

    if (navigate == 6)
    {
        Console.Clear();
        string jsonFromFile = File.ReadAllText(@"C:\Users\eweli\Documents\Programing_lovers\ISA\Projekt\jcszr5-CultureWariors\OnlineLibrary\OnlineLibrary\bin\Debug\net6.0\path123.json");
        List<Book> booksFromFile = JsonSerializer.Deserialize<List<Book>>(jsonFromFile);
        Console.WriteLine(booksFromFile[0]);
        library.books=booksFromFile;
        MainMenu();
    }

    if (navigate == 7)
    {
        Console.Clear();
        Console.WriteLine("Do zobaczenia");
        Environment.Exit(0);

    }



}
void MainMenu()
{

    Console.WriteLine("\nMENU GŁÓWNE");
    Console.WriteLine("1 Dodaj książki");
    Console.WriteLine("2 Przeglądaj książki");
    Console.WriteLine("3 Usuń książki");
    Console.WriteLine("4 Dodaj książkę do przeczytanych");
    Console.WriteLine("5 Zapisz listę");
    Console.WriteLine("6 Wczytaj listę");
    Console.WriteLine("7 Zamknij program");
    Console.WriteLine("\nCo chcesz zrobić? :");
    while (true)

    {

        if (!int.TryParse(Console.ReadLine(), out navigate))
        {
            Console.WriteLine("Podałeś błędną komendę!");
            Console.WriteLine("Podaj numer od 1-7:");
        }
        else
        {
            if (navigate >= 1 && navigate <= 7)
            {
                break;
            }
            Console.WriteLine("Podałeś błędną komendę!");
            Console.WriteLine("Podaj numer od 1-7:");
        }




    }

}


