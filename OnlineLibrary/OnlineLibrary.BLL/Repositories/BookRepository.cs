using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static int BooksCounter;
        private static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Wiedźmin",
                Author = "Sapkowski",
                BookType = BookType.Fantastyka,
                PublicationDate = 1999
            },
            new Book
            {
                Id = 2,
                Title = "Lalka",
                Author = "Prus",
                BookType = BookType.Obyczajowa,
                PublicationDate = 1889
            },
            new Book
            {
                Id = 3,
                Title = "Władca Pierścieni",
                Author = "Tolkien",
                BookType = BookType.Fantastyka,
                PublicationDate = 1960
    }

        };
        public List<Book> GetAll()
        {
            return Books;
        }
        public void Create(Book book)
        {
            book.Id = GetNextId();
            Books.Add(book);
        }
        public int GetNextId()
        {
            BooksCounter += 1;
            return BooksCounter;
        }
        public Book GetById(int id)
        {
            return Books.FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var book = GetById(id);
            Books.Remove(book);
        }
        public void Update(Book model)
        {
            var book = GetById(model.Id);
            book.Title = model.Title;
            book.Author = model.Author;
            book.BookType = model.BookType;
            book.PublicationDate = model.PublicationDate;

        }
    }
}
