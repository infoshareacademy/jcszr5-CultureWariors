namespace OnlineLibrary
{
    public class Library
    {
        public List<Book> library = new List<Book>();
        public void AddBookToLibrary(Book book)
        {
            Console.Clear();
            library.Add(book);
            ConsoleMessages.SuccesMessage("dodano");
            Console.Clear();
        }
        public void PrintLibrary()
        {
            int a = 0;
            foreach (var book in library)
            {
                a++;
                Console.WriteLine($"{a}.{book.Title}, {book.Author}, {book.Type}");
            }
        }
        public BookType ChooseTypeToFind()
        {
            Console.Clear();
            while (true)
            {
                ConsoleMessages.ChooseCategoryMessage();
                Console.WriteLine("8 Wszystkie książki");
                switch (Console.ReadLine())
                {
                    case "0":
                        return BookType.Back;
                    case "1":
                        return BookType.Fantastyka; ;
                    case "2":
                        return BookType.Kryminał;
                    case "3":
                        return BookType.Romans;
                    case "4":
                        return BookType.Naukowa;
                    case "5":
                        return BookType.Dramat;
                    case "6":
                        return BookType.Dziecięca;
                    case "7":
                        return BookType.Obyczajowa;
                    case "8":
                        return BookType.All;
                    default:
                        ConsoleMessages.ChooseTheRightCategory();
                        continue;
                }
                Console.Clear();
            }
        }
        public void ShowFoundBooks(BookType type)
        {
            Console.Clear();

            foreach (var book in library)
            {
                if (book.Type == type)
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                }
                else if (type == BookType.All)
                {
                    PrintLibrary();
                    break;

                }
                else if (type == BookType.Back)
                    return;

            }
            ConsoleMessages.ChooseAnyKey();
            Console.Clear();
        }
        public int ChooseBook()
        {
            int choose;
            while (true)
            {

                if (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.WriteLine("Proszę wybrać numer");
                }

                else break;
            }
            return choose - 1;
        }
        public void DeleteBookFromLibrary()
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz usunąć wpisując jej indeks\nlub wybrać 0 aby powrócić\n");

            while (true)
                try
                {
                    int choice = ChooseBook();
                    if (choice == -1)
                    {
                        return;
                    }
                    library.RemoveAt(choice);

                    break;
                }
                catch (ArgumentOutOfRangeException)
                {

                    ConsoleMessages.WrongIndex();
                }
            Console.Clear();
            ConsoleMessages.SuccesMessage("usunięto");
            Console.Clear();
        }
        public void EditBookFromLibrary()
        {

            Console.Clear();

            while (true)
            {
                PrintBooksWithTextBefore("Wybierz książkę którą chcesz edytować wpisując jej indeks\nlub 0 aby powrócić\n");
                int choice = ChooseBook();
                if (choice == -1)
                {
                    return;
                }
                try
                {
                    var check = library[choice];
                    Console.Clear();
                    Console.WriteLine($"Wybrana książka {library[choice].Title}\n ");
                    ConsoleMessages.WhatToEdit();
                    switch (Console.ReadLine())
                    {
                        case "1":
                            library[choice]();
                            Console.Clear Console.Clear();
                            ConsoleMessages.SuccesMessage("edytowano");
                            return;
                        case "2":
                            Console.WriteLine;
                            library[choice].Title = Console.ReadLine = Console.ReadLine();
                            Console.Clear();
                            ConsoleMessages.SuccesMessage("edytowano");

                            return;
                        case "3":
                            Console.WriteLine("Edytuj autora: ");
                            library[choice].Author = Console.ReadLine();
                            Console.Clear();
                            ConsoleMessages.SuccesMessage("edytowano");
                            return;
                        case "0":
                            return;
                        default:
                            ConsoleMessages.WrongCommand("3");
                            break;


                    }

                }
                catch (ArgumentOutOfRangeException)
                {
                    ConsoleMessages.WrongIndex();
                }

            }
        }

        public Book MoveFromLibraryToFavourites()
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz dodać do wypożyczonych wpisując jej indeks\nlub wybrać 0 aby powrócić\n");
            (true)
            {
                int choice = ChooseBook();
                if (choice == -1)
                {
                    return null;
                }
                try
                {
                    return library[choice];
                }
                catch (ArgumentOutOfRangeException)
                {
                    ConsoleMessages.WrongIndex();
                }
            }
        }
        public BookType ChooseType()
        {
            string choose;
            Console.Clear();
            while (true)
            {
                ConsoleMessages.ChooseCategoryMessage();
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        return BookType.Fantastyka; ;
                    case "2":
                        return BookType.Kryminał;
                    case "3":
                        return BookType.Romans;
                    case "4":
                        return BookType.Naukowa;
                    case "5":
                        return BookType.Dramat;
                    case "6":
                        return BookType.Dziecięca;
                    case "7":
                        return BookType.Obyczajowa;

                    default:
                        ConsoleMessages.ChooseTheRightCategory();
                        continue;

                }


            }
        }

        public void PrintBooksWithTextBefore(string message)
        {
            Console.WriteLine(message);
            foreach (Book book in library)
            {
                int index = library.IndexOf(book);
                Console.WriteLine($"{index + 1} {book.Title} {book.Author} {book.Type}");
            }
        }
    }
}
    }
}









