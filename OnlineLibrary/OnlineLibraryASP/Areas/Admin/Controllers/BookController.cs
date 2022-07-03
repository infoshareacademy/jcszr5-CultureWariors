using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using OnlineLibrary.BLL.Utility;
using OnlineLibraryASP.ViewModels;

namespace OnlineLibraryASP.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class BookController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        Uri baseAdress = new Uri("https://wolnelektury.pl/api");
        HttpClient client;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,IAuthorService authorService, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {

            //_bookService = new BookService();
            _bookService = bookService;
            _authorService = authorService;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            client = new HttpClient();
            client.BaseAddress = baseAdress;
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
                //string wwwRootPath = _webHostEnvironment.WebRootPath;
                //if (file != null)
                //{
                //    string fileName = Guid.NewGuid().ToString();
                //    var uploads = Path.Combine(wwwRootPath, @"Images\Books");
                //    var extension = Path.GetExtension(file.FileName);

                //    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                //    {
                //        file.CopyTo(fileStreams);
                //    }
                //    bookVM.Book.ImageUrl = @"~\Images\Books\" + fileName + extension;
                //}
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
        public ActionResult Edit(int id, BookCreateViewModel model, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Books");
                    var extension = Path.GetExtension(file.FileName);

                    if (model.Book.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, model.Book.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }

                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    model.Book.ImageUrl = @"Images\Books\" + fileName + extension;
                }


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
            List<GenresFromApi> modelList = new List<GenresFromApi>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/genres").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<GenresFromApi>>(data);
            }
            var model = _bookService.GetAll();
            var aboutModel = new BookAboutViewModel()
            {
                books = model,
                genres = new()
            };
            foreach (var genreName in modelList)
            {
                aboutModel.genres.Add(genreName.name);
            }
            return View(aboutModel);
        }

        public ActionResult Refresh()
        {
            var booksDb = _bookService.GetAll();
            List<BookFromApi> modelList = new List<BookFromApi>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/books").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<BookFromApi>>(data);
            }
            var authors = _authorService.GetAll();
            foreach (var book in modelList)
            {
                book.bookAuthor = authors.FirstOrDefault(a => a.Name.Equals(book.author));
            }
            var mappedBooks = _mapper.Map<List<Book>>(modelList);
            foreach (var book in mappedBooks)
            {
                if (book.Author != null)
                {
                    if (!booksDb.Select(a => a.Title).Contains(book.Title))
                    {
                        _bookService.Create(book);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
