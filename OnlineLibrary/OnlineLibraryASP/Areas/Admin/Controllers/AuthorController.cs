using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibrary.BLL.Utility;

namespace OnlineLibraryASP.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class AuthorController : Controller
    {


        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        Uri baseAdress = new Uri("https://wolnelektury.pl/api");
        HttpClient client;
        public AuthorController(IAuthorService authorService,IBookService bookService)
        {
            client = new HttpClient();
            client.BaseAddress = baseAdress;
            _authorService = authorService;
            _bookService = bookService;
        }
        // GET: HomeController1
        public ActionResult Index()
        {
            var model = _authorService.GetAll().OrderBy(a=>a.Name);
            
            return View(model);
        }

        // GET: HomeController1/Details/5
        public ActionResult Details(int id)
        {
            var model = _authorService.GetById(id);
            return View(model);
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author model)
        {
            
            
                try
                {
                    if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    _authorService.Create(model);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _authorService.GetById(id);
            return View(model);
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Author model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _authorService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _authorService.GetById(id);

            return View(model);
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Author model)
        {
            try
            {
                _authorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Refresh()
        {
            var authorsDb = _authorService.GetAll();
            List<Author> modelList = new List<Author>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/authors").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Author>>(data);
            }
            foreach (var author in modelList)
            {
                if (!authorsDb.Select(a => a.Name).Contains(author.Name))
                {
                    _authorService.Create(author);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
