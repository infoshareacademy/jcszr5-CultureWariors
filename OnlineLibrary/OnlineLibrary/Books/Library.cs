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
            Console.ReadKey();
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
                Console.WriteLine("\nWciśnij \"0\" jeżeli chcesz wrócić do menu.");

                switch (Console.ReadLine())
                {
                    case "0":
                        return BookType.Powrót;
                    case "1":
                        return BookType.Fantastyka; 
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
                        return BookType.Wszystkie;
                    default:
                        ConsoleMessages.ChooseTheRightCategory();
                        break;
                }
              
                Console.Clear();
            }
        }
        public string EnterStringToFind()
        {
            Console.Clear();
            Console.WriteLine("Podaj autora lub tytuł:");
            string nameOrAuthor = Console.ReadLine();
            return nameOrAuthor;

        }
        public void ShowFoundBooksByString(string nameOrAuthor)
        {
            var foundBooksTitle = library.Where(b => b.Title.ToLower().Contains(nameOrAuthor.ToLower())).ToList();
            var foundBooksAuthor = library.Where(b => b.Author.ToLower().Contains(nameOrAuthor.ToLower())).ToList();
            if (foundBooksTitle.Count()!=0) 
            {
                foreach (var book in foundBooksTitle)
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                } 
            }
            else if(foundBooksAuthor.Count() != 0)
            {
                foreach (var book in foundBooksAuthor)
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                }
            }
            else Console.WriteLine("Brak takich książek");
            ConsoleMessages.ChooseAnyKey();
            Console.Clear();

        }
        public void ShowFoundBooksByType(BookType type)
        {
            Console.Clear();

            foreach (var book in library)
            {
                if (book.Type == type)
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                }
                else if (type == BookType.Wszystkie)
                {
                    PrintLibrary();
                    break;
                }
                else if (type == BookType.Powrót)
                {
                    return;
                }
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
            Console.ReadKey();
            Console.Clear();
        }
        public void EditBookFromLibrary()
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz edytować wpisując jej indeks\nlub 0 aby powrócić\n");

            while (true)
            {
                int choice = ChooseBook();
                if (choice == -1)
                {
                    return;
                }
                try
                {
                    var choosenBook =library[choice]; //testing the correct index
                    Console.Clear();
                    Console.WriteLine($"Wybrana książka: {choosenBook.Title}\nCo chcesz zrobić?\n");
                    ConsoleMessages.BookEditMenu();
                    switch (Helper.Navigate())
                    {
                        case 0:
                            return;
                        case 1:
                            library[choice].Type = ChooseType();
                            Console.Clear();
                            Console.WriteLine("Edytuj tytuł: ");
                            library[choice].Title = Console.ReadLine();
                            Console.WriteLine("Edytuj autora: ");
                            library[choice].Author = Console.ReadLine();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Edytuj tytuł: ");
                            library[choice].Title = Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Edytuj autora: ");
                            library[choice].Author = Console.ReadLine();
                            break;
                        case 4:
                            library[choice].Type = ChooseType();
                            Console.Clear();
                            break;
                    }
                    break;


                    }
                catch (ArgumentOutOfRangeException)
                {
                    ConsoleMessages.WrongIndex();
                }
                
            }
            Console.Clear();
            ConsoleMessages.SuccesMessage("edytowano");
        }

        public Book MoveFromLibraryToFavourites()
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz dodać do wypożyczonych wpisując jej indeks\nlub wybrać 0 aby powrócić\n");
            while (true)
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

        public void AboutLibrary()
        {
            var allBooks = library
                .Count();
            var fantasy = library
                .Count(book => book.Type == BookType.Fantastyka);
            var criminals = library
                .Count(book => book.Type == BookType.Kryminał);
            var romanse = library
                .Count(book => book.Type == BookType.Romans);
            var science = library
                .Count(book => book.Type == BookType.Naukowa);
            var drama = library
                .Count(book => book.Type == BookType.Dramat);
            var kids = library
                .Count(book => book.Type == BookType.Dziecięca);
            var novels = library
                .Count(book => book.Type == BookType.Obyczajowa);


            ConsoleMessages.Statistics(allBooks, fantasy, criminals, romanse, science, drama, kids, novels);
            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }
        public void ShowMeWhatYouGot()
        {
            var random = new Random();
            var happynumber = random.Next(library.Count());
            var blindchoose = library[happynumber];
           ConsoleMessages.RandomBookMessage(blindchoose);
        }
    }
}









