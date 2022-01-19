using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary
{
    public class Library : Book
    {
        private int capacity;
        public List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
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

    }
    
}
