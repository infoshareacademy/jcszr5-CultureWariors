using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP;

namespace OnlineLibrary.BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        private readonly IAuthorService _authorService;
        public BookRepository(BookContext context,IAuthorService authorService)
        {
            _authorService = authorService;
            _context = context;
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }
        public void Create(Book book)
        {
            book.Author = _authorService.GetById(book.AuthorId);
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        
        public Book GetById(int id)
        {
            return _context.Books.FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var book = GetById(id);
            _context.Books.Remove(book);
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
