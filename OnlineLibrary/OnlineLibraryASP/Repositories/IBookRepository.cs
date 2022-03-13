using OnlineLibraryASP.Models;

namespace OnlineLibraryASP.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetAll();
        public void Create(Book book);
        public int GetNextId();
        public Book GetById(int id);
        public void Delete(int id);
        public void Update(Book model);
    }
}
