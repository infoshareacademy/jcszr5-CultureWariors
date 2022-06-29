using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP;

namespace OnlineLibrary.BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;
        
        public BookRepository(BookContext context)
        {
            
            _context = context;
        }
        public List<Book> GetAll()
        {
            var books = _context.Books.Include(b=>b.Author).ToList();
            
            return books;
        }
        public void Create(Book book)
        {
            _context.Add(book);
            
            _context.SaveChanges();
        }
        
        public Book GetById(int id)
        {
            return _context.Books.Include(b=>b.Author).FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var book = GetById(id);
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        public void Update(Book model)
        {
            var book = GetById(model.Id);
            book.Title = model.Title;
            book.AuthorId = model.AuthorId;
            book.BookType = model.BookType;
            book.Epoch = model.Epoch;
            if (book.ImageUrl != null)
            {
                book.ImageUrl = model.ImageUrl;
            }
            
            

            
            _context.SaveChanges();
        }
    }
}
