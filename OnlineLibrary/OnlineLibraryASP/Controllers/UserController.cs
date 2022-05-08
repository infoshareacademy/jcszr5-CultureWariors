using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP.ViewModels;

namespace OnlineLibraryASP.Controllers
{
    public class UserController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserController(IBookService bookService, IAuthorService authorService, IWebHostEnvironment webHostEnvironment)
        {
            //_bookService = new BookService();
            _bookService = bookService;
            _authorService = authorService;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: BookController
        public ActionResult Index(string bookType, string searchString, string searchAuthor)
        {
            var typeQuery = _bookService.GetAll().Select(b => b.BookType.ToString()).ToList();
            var books = _bookService.GetAll().GroupBy(x => x.Title).Select(y => y.First()).ToList();


            if (!String.IsNullOrEmpty(searchString))
            {
                books = _bookService.SearchByTitle(searchString);
            }
            if (!String.IsNullOrEmpty(bookType))
            {
                books = _bookService.SearchByType(bookType);
            }
            if (!String.IsNullOrEmpty(searchAuthor))
            {
                books = _bookService.SearchByAuthor(searchAuthor);
            }
            var bookTypeVM = new BookTypeViewModel
            {
                Types = new SelectList(typeQuery.Distinct().ToList()),
                Books = books
            };
            return View(bookTypeVM);

        }
        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var model = _bookService.GetById(id);
            return View(model);
        }
    }
}
