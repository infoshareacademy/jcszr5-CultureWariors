using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;

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
                Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
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
            }

            Console.WriteLine("\nNacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
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
            return choose-1;
        }
        public void DeleteBookFromLibrary()
        {
            Console.Clear();
            PrintBooksWithTextBefore("Wybierz książkę którą chcesz usunąć wpisując jej indeks\nlub wybrać 0 aby powrócić\n");
            
            while (true)
                try
                {
                    int choice = ChooseBook();
                    if(choice == -1)
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
                    library[choice].Type = ChooseType();
                    Console.Clear();
                    Console.WriteLine("Edytuj tytuł: ");
                    library[choice].Title = Console.ReadLine();
                    Console.WriteLine("Edytuj autora: ");
                    library[choice].Author = Console.ReadLine();
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
                if(choice == -1)
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
                Console.WriteLine($"{index+1} {book.Title} {book.Author} {book.Type}");
            }
        }
    }
}



        
    

    
    

