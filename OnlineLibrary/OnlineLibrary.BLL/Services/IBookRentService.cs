using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Services
{
    public interface IBookRentService
    {
        public BookRent CreateBookRent(Book book);
    }
}