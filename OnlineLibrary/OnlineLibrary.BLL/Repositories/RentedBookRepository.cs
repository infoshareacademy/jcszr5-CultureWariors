using Microsoft.EntityFrameworkCore;
using OnlineLibrary.BLL.Models;
using OnlineLibraryASP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Repositories
{
    public class RentedBookRepository :IRentedBookRepository
    {
        private readonly BookContext _context;

        public RentedBookRepository(BookContext context)
        {
            _context = context; 

        }

        public List<RentedBook> GetAll()
        {
            var books = _context.RentedBooks
                .Include(b=>b.Book)
                .Include(b => b.Book.Author)
                .Include(b => b.ApplicationUser)
                .ToList();
            return books;
        }

        public void Create(RentedBook rent)
        {
            _context.Add(rent);
            _context.SaveChanges();
     
        }

        public RentedBook GetById(int id)
        {
            return _context.RentedBooks.FirstOrDefault(c => c.Id == id);
        }
        public void Delete(int id)
        {
            var book = GetById(id);
            _context.RentedBooks.Remove(book);
            _context.SaveChanges();
        }

        //public void Relasing(RentedBook model)
        //{
        //    var book = GetById(model.Id);
        //    book.Status = model.Status;
        //    book.RentedTime = DateTime.Today;
        //    book.ReturnTime = DateTime.Today.AddDays(14);
            

        //    _context.SaveChanges();

        //}
        public void ToRelasing(RentedBook model)
        {
            var book = GetById(model.Id);
            book.Status = Enums.BookStatus.Ready;
            


            _context.SaveChanges();

        }
        public void ToRenting(RentedBook model)
        {
            var book = GetById(model.Id);
            book.Status = Enums.BookStatus.Rented;
            book.RentedTime = DateTime.Today;
            book.ReturnTime = DateTime.Today.AddDays(14);


            _context.SaveChanges();

        }
        public void ToReturnig(RentedBook model)
        {
            var book = GetById(model.Id);
            book.Status = Enums.BookStatus.Returned;
            book.RentedTime = null;
            book.ReturnTime = DateTime.Today;
                

            _context.SaveChanges();

        }
    }
}
