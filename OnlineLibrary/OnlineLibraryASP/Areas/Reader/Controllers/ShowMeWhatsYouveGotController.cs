using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP.ViewModels;

namespace OnlineLibraryASP.Controllers
{
    [Area("Reader")]
    public class ShowMeWhatsYouveGotController : Controller
    {
        private IBookService _bookservice;
        private IAuthorService _authorservice;
        private readonly IWebHostEnvironment _webHostEnvironment;
        Uri baseAdress = new Uri("https://wolnelektury.pl/api");
        HttpClient client;
        public ShowMeWhatsYouveGotController(IBookService bookService, IAuthorService authorService,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookservice = bookService;
            _authorservice = authorService;
            _webHostEnvironment = webHostEnvironment;
            client = new HttpClient();
            client.BaseAddress = baseAdress;
        }

        // Wyświetlenie zakładki zaskocz mnie! - wybierz rodzaj
        public ActionResult Index()
        {
            var books = _bookservice.GetAll();
            List<GenresFromApi> modelList = new List<GenresFromApi>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/genres").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<GenresFromApi>>(data);
            }
            var genres = new List<string>();
            var booksGenres = books.Select(x => x.BookType).ToList();
            foreach (var genreName in modelList)
            {
                if (booksGenres.Contains(genreName.name))
                {
                    genres.Add(genreName.name);
                }
            }
            var bookTypeVM = new BookRollViewModel
            {
                Types = new SelectList(genres.Distinct().ToList()),
                BookType = genres
            };
            return View(bookTypeVM);
        }


        public ActionResult Roll(string bookType)
        {
            var model = _bookservice.RandomBookByCategory(bookType);

            return View(model);
        }

        public ActionResult RollAllCategory()
        {
            var model = _bookservice.RandomBookByAll();

            return View(model);
        }







    }
}
