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
    }
}