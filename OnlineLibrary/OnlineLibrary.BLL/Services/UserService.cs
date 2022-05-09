using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Models;
using OnlineLibraryASP;

namespace OnlineLibrary.BLL.Services
{
    public class UserService : IUserService
    {
        public readonly BookContext _context;
        public readonly IBookService _bookService;
        public UserService(BookContext context,IBookService bookService)
        {
            _context = context;
            _bookService = bookService;
        }
        public ApplicationUser GetById(string id)
        {
            return _context.ApplicationUsers
                .Include(u => u.RentedBooks)
                .ThenInclude(b => b.Author)
                .FirstOrDefault(u => u.Id == id);

        }

        public List<Book> GetUserRentedBooks(string id)
        {
            var user = GetById(id);
            return user.RentedBooks;

        }
        public void RentBook(Book book, ApplicationUser user)
        {
            
            user.RentedBooks.Add(book);
           //_bookService.Delete(book.Id);
            _context.SaveChanges();
        }

        public void ReturnBook(Book book, ApplicationUser user)
        {
            
            user.RentedBooks.Remove(book);
            _context.SaveChanges();
        }
    }
}
