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
        public int Capacity { get; set; }
        public List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }



        public void PrintLibrary()
        {
            int a = 0;
            foreach (var book in books)
            {
                a++;
                Console.WriteLine($"\nTyp: {book.Type}\nTytuł: {book.Title}\nAutor:{book.Author}");
            }
        }

        public string ChooseTypeToFind()
        {
            string type;
            int choose;
            string chooseCheck;
            Console.Clear();
            while (true)
            {

                Console.WriteLine("Proszę dokonać wyboru kategorii z poniższej listy:");
                Console.WriteLine("1 Fantastyka");
                Console.WriteLine("2 Kryminał");
                Console.WriteLine("3 Romans");
                Console.WriteLine("4 Naukowa");
                Console.WriteLine("5 Dramat");
                Console.WriteLine("6 Dziecięca");
                Console.WriteLine("7 Obyczajowa");
                Console.WriteLine("8 Wszystkie książki");
                chooseCheck = Console.ReadLine();
                if (!int.TryParse(chooseCheck, out choose))
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



        public void ChooseBookTypeToFind(string type)
        {
            Console.Clear();
            foreach (var book in books)
            {
                if (book.Type.Contains(type))
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                }
                else if (type == "All")
                {
                    Console.WriteLine($"{book.Title} {book.Author} {book.Type}");
                }
            }
        }

        public void DeleteBook()
        {
            string deleteAuthor;
            string deleteTitle;
            string sure;
            int temporaryIndex;
            Console.WriteLine("Podaj autora i lub tytuł książki");
            Console.WriteLine("Autor:");
            deleteAuthor = Console.ReadLine();
            Console.WriteLine("Tytuł:");
            deleteTitle = Console.ReadLine();
            foreach (var book in books)
            {
                if (book.Title.Contains(deleteTitle) && book.Author.Contains(deleteAuthor))
                {
                    temporaryIndex = books.IndexOf(book);
                    Console.WriteLine(
                        $"Znaleziono taką książkę:{books.IndexOf(book)} {book.Title} {book.Author} {book.Type}");
                    Console.WriteLine("Czy chcesz usunąć tę książkę z biblioteki ? y/n");
                    sure = Console.ReadLine().ToLower();
                    if (sure == "y")
                    {
                        books.RemoveAt(temporaryIndex);
                        Console.WriteLine("Książka została usunięta");
                        break;
                    }
                }
            }

        }
    }
}



        
    

    
    

