using OnlineLibrary;

int navigate;
Console.WriteLine("Witaj W bibliotece Online!");
MainMenu();
if (navigate == 1)
{
    Console.WriteLine("Dodaj książkę");
}
if (navigate == 2)
{
    Console.WriteLine("Przeglądaj ksiązki");
}
if (navigate == 3)
{
    Console.WriteLine("Usuń książkę");
}
if (navigate == 4)
{
    Console.WriteLine("Dodaj do przeczytanych");
}
if (navigate == 5)
{
    Console.WriteLine("Zapisz Liste");
}
if (navigate == 6)
{
    Console.WriteLine("Wczytaj listę");
}
if (navigate == 7)
{
    Console.WriteLine("Zamknij program");
    
}

Book book  = new Book();
book.Title = "Wiedzmin";
book.Author = "Andrzej";
book.Type = book.Types(book.ChooseType());
Console.WriteLine(book.Type);



void MainMenu()
{
    
    Console.WriteLine("\nMENU GŁÓWNE");
    Console.WriteLine("1 Dodaj książke");
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

