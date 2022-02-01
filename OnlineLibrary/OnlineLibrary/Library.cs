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
        public void AddBook(Book book)
        {
            Console.Clear();
            library.Add(book);
            Console.WriteLine("Pomyślnie dodano ksiąkę, nacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }
        public Book CreateBook()
        {
            Book book = new Book();
            book.Type = book.ChooseType();
            Console.Clear();
            Console.WriteLine($"Wybrany typ to: {book.Type}");
            Console.WriteLine("\nWprowadź tutuł:");
            book.Title = Console.ReadLine();
            Console.WriteLine("\nPodaj autora:");
            book.Author = Console.ReadLine();
            Console.Clear();
            return book;
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
        public string ChooseTypeToFind()
        {
            string type;
            int choose;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:\n");
                Console.WriteLine("1 Fantastyka");
                Console.WriteLine("2 Kryminał");
                Console.WriteLine("3 Romans");
                Console.WriteLine("4 Naukowa");
                Console.WriteLine("5 Dramat");
                Console.WriteLine("6 Dziecięca");
                Console.WriteLine("7 Obyczajowa");
                Console.WriteLine("8 Wszystkie książki");
                if (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.Clear();
                    Console.WriteLine("Proszę wybrać właściwą kategorię");
                }

                else if (choose <= 0 || choose >= 9)
                {
                    Console.Clear();
                    Console.WriteLine("Proszę wybrać właściwą kategorię");
                }

                switch (choose)
                {
                    case 1:
                        return type = "Fantastyka";
                    case 2:
                        return type = "Kryminał";
                    case 3:
                        return type = "Romans";
                    case 4:
                        return type = "Naukowa";
                    case 5:
                        return type = "Dramat";
                    case 6:
                        return type = "Dziecięca";
                    case 7:
                        return type = "Obyczajowa";
                    case 8:
                        return type = "All";
                }
            }
        }
        public void ShowFoundBooks(string type)
        {
            Console.Clear();
            foreach (var book in library)
            {
                if (book.Type.Contains(type))
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                }
                else if (type == "All")
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

            return choose;
        }
        public void DeleteBook()
        {
            Console.Clear();
            Console.WriteLine("Wybierz książkę którą chcesz usunąć wpisując jej indeks\n");
            foreach (var books in library)
            {
                int index = library.IndexOf(books);
                Console.WriteLine($"{index} {books.Title} {books.Author} {books.Type}");
            }

            while (true)
                try
                {
                    library.RemoveAt(ChooseBook());
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            Console.Clear();
            Console.WriteLine("Pomyślnie usunięto książkę, nacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }
        public void EditBookFromLibrary()
        {
            Console.WriteLine("Wybierz książkę którą chcesz edytować wpisując jej indeks\n");
            foreach (var books in library)
            {
                int index = library.IndexOf(books);
                Console.WriteLine($"{index} {books.Title} {books.Author} {books.Type}");
            }


            while (true)
            {
                int chosenIndex = ChooseBook();
                try
                {
                    library[chosenIndex].Title = "";
                    Console.WriteLine("Edytuj tytuł: ");
                    library[chosenIndex].Title = Console.ReadLine();
                    Console.WriteLine("Edytuj autora: ");
                    library[chosenIndex].Author = Console.ReadLine();
                    library[chosenIndex].Type = ChooseType();
                    break;

                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            }
        }

        public Book MoveFromLibraryToFavourites()
        {
            Console.Clear();
            Console.WriteLine("Wybierz książkę którą chcesz dodać do wypożyczonych wpisując jej indeks\n");
            foreach (var books in library)
            {
                int index = library.IndexOf(books);
                Console.WriteLine($"{index} {books.Title} {books.Author} {books.Type}");
            }
            while (true)
            {
                int chooseBook = ChooseBook();
                try
                {
                    return library[chooseBook];
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("Błędny indeks");
                }
            }
        }
        public string ChooseType()
        {
            string choose;
            string type;
            Console.Clear();
            while (true)
            {

                Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:\n");
                Console.WriteLine("1 Fantastyka");
                Console.WriteLine("2 Kryminał");
                Console.WriteLine("3 Romans");
                Console.WriteLine("4 Naukowa");
                Console.WriteLine("5 Dramat");
                Console.WriteLine("6 Dziecięca");
                Console.WriteLine("7 Obyczajowa");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        return type = "Fantastyka";
                    case "2":
                        return type = "Kryminał";
                    case "3":
                        return type = "Romans";
                    case "4":
                        return type = "Naukowa";
                    case "5":
                        return type = "Dramat";
                    case "6":
                        return type = "Dziecięca";
                    case "7":
                        return type = "Obyczajowa";
                    default:
                        Console.WriteLine("Proszę wybrać właściwą kategorię");
                        continue;

                }


            }
        }
    }
}



        
    

    
    

