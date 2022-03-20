using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;

namespace OnlineLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }
        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }
        public void Create(Book book)
        {
            _bookRepository.Create(book);
        }
        public void Update(Book model)
        {
            _bookRepository.Update(model);
        }
        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }
        public List<Book> SearchByTitle(string title)
        {
            return _bookRepository.GetAll().Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
        }
        public List<Book> SearchByType(string type)
        {
            return _bookRepository.GetAll().Where(b => b.BookType.ToString().Contains(type)).ToList();
        }

    }
}

