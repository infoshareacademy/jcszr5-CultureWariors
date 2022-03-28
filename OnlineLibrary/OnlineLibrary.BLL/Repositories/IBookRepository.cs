using OnlineLibrary.BLL.Models;

namespace OnlineLibrary.BLL.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public void Create(Book book);
       
        public Book GetById(int id);
        public void Delete(int id);
        public void Update(Book model);
    }
}
