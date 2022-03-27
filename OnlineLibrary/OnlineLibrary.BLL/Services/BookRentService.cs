using OnlineLibrary.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Services
{
    public class BookRentService
    {
        public readonly IBookService _bookService;
        
        public BookRentService(IBookService bookService,IUserService userService)
        {
            _bookService = bookService;
            
        }
        public BookRent CreateBookRent(Book book)
        {
            
            var bookRent = new BookRent
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                BookType = book.BookType,
                PublicationDate = book.PublicationDate,
            };
            return bookRent;
        }
        
    }
}
