using OnlineLibraryASP.Models;
using OnlineLibraryASP.Repositories;

namespace OnlineLibraryASP.Services
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
        
    }
}
