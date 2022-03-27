using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrary.BLL.Models
{
    public class BookRent:Book
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public BookRent(): base()
        {
            From = DateTime.Now;
            To = DateTime.Now.AddDays(14);
        }
        public BookRent(Book book) : base()
        {
            Id = book.Id;
            Title = book.Title;
            Author = book.Author;
            BookType = book.BookType;
            PublicationDate = book.PublicationDate;
            From = DateTime.Now;
            To = DateTime.Now.AddDays(14);
        }
    }
}
