using OnlineLibraryASP.Models;

namespace OnlineLibraryASP.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
    }
}