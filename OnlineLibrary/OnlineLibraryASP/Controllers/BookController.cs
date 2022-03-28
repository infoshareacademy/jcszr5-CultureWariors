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
        public ActionResult Index(string bookType, string searchString)
        {
            var typeQuery = _bookService.GetAll().Select(b => b.BookType.ToString()).ToList();
            var books = _bookService.GetAll();
                
            
            if (!String.IsNullOrEmpty(searchString))
            {
                books = _bookService.SearchByTitle(searchString);
            }
            if (!String.IsNullOrEmpty(bookType))
            {
               books = _bookService.SearchByType(bookType);
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
            ViewData["AuthorId"] = new SelectList(_authorService.GetAll(), "Id", "Surname");
            //var vm = new CreateRentViewModel()
            //{
            //    Books = _bookService.GetAll(),
            //    Users = _bookService.GetAll()
            //};


            //return View(vm);
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
         {
            
            try
            {

                //if (!ModelState.IsValid)
                //{
                //    return View(model);
                //}
                
                _bookService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            ViewData["AuthorId"] = new SelectList(_authorService.GetAll(), "Id", "Surname", model.AuthorId);
        }
        

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _bookService.GetById(id);
            return View(model);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _bookService.Update(model);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
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
        public IActionResult About()
        {
           var model = _bookService.GetAll();
            return View(model);
        }
    }
}
