using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using System.Web.Mvc;

namespace OnlineLibrary.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorService _authorService;
        public BookService(IBookRepository bookRepository,IAuthorService authorService)
        {
            _bookRepository = bookRepository;
            _authorService = authorService;
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
            return _bookRepository.GetAll().Where(b => b.BookType.Contains(type)).ToList();
        }
        public List<Book> SearchByAuthor(string author)
        {
            return _bookRepository.GetAll().Where(b=>b.Author.Name.ToLower().Contains(author.ToLower())).ToList();
        }
        public List<Book> SearchByString(string search)
        {
            if (search == null)
            {
                return null;
            }
            return _bookRepository.GetAll().Where(
                b => b.Title.ToLower().Contains(search.ToLower()) || b.Author.Name.ToLower().Contains(search.ToLower())).ToList();
        }

        public Book RandomBookByAll()
        {
            var selected = _bookRepository.GetAll().ToList();
            return Randomizer(selected);
        }

        public Book RandomBookByCategory(string bookType)
        {
            var selected = _bookRepository.GetAll()
            .Where(b => b.BookType == bookType)
            .ToList();

            return Randomizer(selected);

        }

        private Book Randomizer(List<Book> selected)
        {
            Random random = new Random();
            var happynumber = random.Next(selected.Count());
            var blindchoose = selected[happynumber];
            var id = blindchoose.Id;

            return _bookRepository.GetById(id);
        }
    }
}

