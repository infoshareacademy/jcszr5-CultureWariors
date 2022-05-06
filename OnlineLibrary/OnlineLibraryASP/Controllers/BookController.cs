using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP.ViewModels;

namespace OnlineLibraryASP.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        public BookController(IBookService bookService,IAuthorService authorService)
        {
            //_bookService = new BookService();
            _bookService = bookService;
            _authorService = authorService;
        }
        // GET: BookController
        public ActionResult Index(string bookType, string searchString,string searchAuthor)
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
                books= _bookService.SearchByAuthor(searchAuthor);
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

        // GET: BookController/Create
        public ActionResult Create()
        {
            BookCreateViewModel bookVM = new()
            {
                Book = new(),
                AuthorsList = _authorService.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };
            
            return View(bookVM);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreateViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                _bookService.Create(bookVM.Book);
            }
            return RedirectToAction("Index");



        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {

            var book = _bookService.GetById(id);
            BookCreateViewModel bookVM = new()
            {
                Book = book,
                AuthorsList = _authorService.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                })
            };

            return View(bookVM);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookCreateViewModel model)
        {
            if (ModelState.IsValid)
            {


                _bookService.Update(model.Book);
                return RedirectToAction(nameof(Index));
            }
            return View();

            
        }

        // GET: MeetingController/Delete/5
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            var model = _bookService.GetById(id);

            return View(model);
        }

        // POST: MeetingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete/{id:int}")]
        public ActionResult Delete(int id, Book model)
        {
            try
            {
                _bookService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        public ActionResult Search(string search)
        {
            List<Book> model;
            if (search == null)
            {
                 model = _bookService.GetAll();
                
            }
            else
            {
                 model = _bookService.SearchByString(search);
            }

            return View(model);
        }
        public IActionResult About()
        {
           var model = _bookService.GetAll();
            return View(model);
        }
    }
}
