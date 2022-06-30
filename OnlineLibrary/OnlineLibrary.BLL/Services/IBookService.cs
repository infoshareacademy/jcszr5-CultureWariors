using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Services
{
    public interface IBookService
    {
        public List<Book> GetAll();
        public Book GetById(int id);
        public void Create(Book book);
        public void Update(Book model);
        public void Delete(int id);
        public List<Book> SearchByTitle(string title);
        public List<Book> SearchByType(string type);
        public List<Book> SearchByAuthor(string author);
        public List<Book> SearchByString(string search);
        public Book RandomBookByCategory(string bookType);
        public Book RandomBookByAll();
    }
}