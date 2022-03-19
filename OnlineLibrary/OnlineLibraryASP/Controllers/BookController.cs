using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryASP.Models;
using OnlineLibraryASP.Services;

namespace OnlineLibraryASP.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            //_bookService = new BookService();
            _bookService = bookService;
        }
        // GET: BookController
        public ActionResult Index()
        {
            var model = _bookService.GetAll();
            return View(model);
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
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                _bookService.Create(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
    }
}
