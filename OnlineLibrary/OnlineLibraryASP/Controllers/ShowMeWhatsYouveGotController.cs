using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryASP.Services;

namespace OnlineLibraryASP.Controllers
{
    public class ShowMeWhatsYouveGotController : Controller
    {
        private IBookService _bookservice;
        public ShowMeWhatsYouveGotController(IBookService bookService)
        {
               _bookservice = bookService;
        }

        // Wyświetlenie zakładki zaskocz mnie! - wybierz rodzaj
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShowMeWhatsYouveGotController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShowMeWhatsYouveGotController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShowMeWhatsYouveGotController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowMeWhatsYouveGotController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShowMeWhatsYouveGotController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShowMeWhatsYouveGotController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShowMeWhatsYouveGotController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
