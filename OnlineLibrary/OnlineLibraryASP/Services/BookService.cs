using OnlineLibraryASP.Models;

namespace OnlineLibraryASP.Services
{
    public class BookService
    {
        
        public static int BooksCounter;
        public static List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Wiedźmin",
                Author = "Sapkowski",
                BookType = Enums.BookType.Fantastyka,
                PublicationDate = 1999
            },
            new Book
            {
                Id = 2,
                Title = "Lalka",
                Author = "Prus",
                BookType = Enums.BookType.Obyczajowa,
                PublicationDate = 1889
            },
            new Book
            {
                Id = 3,
                Title = "Władca Pierścieni",
                Author = "Tolkien",
                BookType = Enums.BookType.Fantastyka,
                PublicationDate = 1960
    }
        };
            public List<Book> GetAll()
        {
            return Books;
        }
        public Book GetById(int id)
        {
            return Books.FirstOrDefault(b => b.Id == id);
        } 
    }
}
