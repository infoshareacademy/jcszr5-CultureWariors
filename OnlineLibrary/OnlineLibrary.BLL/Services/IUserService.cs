using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Services;

public interface IUserService
{
    ApplicationUser GetById(string id);
    void RentBook(Book book, ApplicationUser user);
    void ReturnBook(Book book, ApplicationUser user);
    public List<Book> GetUserRentedBooks(string id);
}