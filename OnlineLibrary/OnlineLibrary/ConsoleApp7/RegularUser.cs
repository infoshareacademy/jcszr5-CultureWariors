using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    public class RegularUser:User,IMenu
    {
        private List<Book> favouriteBooks = new List<Book>();

        public RegularUser(string username,string password):base(username,password)
        {
            
        }

        public void ShowMenu()
        {
            Console.WriteLine("MENU GŁÓWNE\n");
            Console.WriteLine("1: Przeglądaj książki");
            Console.WriteLine("2: Dodaj książki do wypożyczenia");
            Console.WriteLine("3: Zobacz wypożyczane książki");
            Console.WriteLine("4: Powróć do ekranu logowania");
        }

        public void AddBookToFavourites(Book book)
        {
            Console.Clear();
            favouriteBooks.Add(book);
            Console.WriteLine("Pomyślnie dodano ksiąkę, nacisnij dowolny przycisk aby powrócić do menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void ShowFavouritesBooks()
        {
            Console.Clear();
            Console.WriteLine("Wypożyczane książki: ");
            int a = 0;
            foreach (var book in favouriteBooks)
            {
                a++;
                Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
            }
            Console.WriteLine("Naciśnij dowolny przycisk by kontynuować");
            Console.ReadKey();
            Console.Clear();
        }

        public int NavigateMenu()
        {
            int navigate;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out navigate))
                {
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
                else
                {
                    if (navigate >= 1 && navigate <= 4)
                    {
                        break;
                    }
                    Console.WriteLine("Podałeś błędną komendę!");
                    Console.WriteLine("Podaj numer od 1-4:");
                }
            }
            return navigate;
        }
        
    }
}
