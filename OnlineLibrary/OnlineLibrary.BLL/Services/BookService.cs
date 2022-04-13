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
            return _bookRepository.GetAll().Where(b => b.BookType.ToString().Contains(type)).ToList();
        }
        public List<Book> SearchByAuthor(string author)
        {
            return _bookRepository.GetAll().Where(b=>b.Author.Name.ToLower().Contains(author.ToLower())).ToList();
        }

        public Book RandomBook(BookType bookType)
        {

            Random random = new Random();
            var selected = _bookRepository.GetAll()
                .Where(b => b.BookType == bookType)
                .ToList();
            var happynumber = random.Next(selected.Count());
            var blindchoose = selected[happynumber];
            var id = blindchoose.Id;
            

            return _bookRepository.GetById(id);

        }


        //public static SelectList TypeListGenerator()
        //{
        //    ViewData["TypeOfBook"]
        //    var _bookTypes = from BookType d in Enum.GetValues(typeof(BookType))
        //                     select new { ID = (int)d, Name = d.ToString() };
        //    return new SelectList (_bookTypes, "ID", "Name");
        //}

        //private void PopulateViewdata4selectLists(BookType bookType)
        //{
        //    ViewData["Typy"] = from BookType d in Enum.GetValues(typeof(BookType))
        //                       select new SelectListItem
        //                       {
        //                           Value = ((int)d).ToString(),
        //                           Text = d.ToString(),
        //                           Selected =bookType == d
        //                       }
        //}


    }
}

