using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;

namespace OnlineLibraryASP.Controllers
{
    public class ShowMeWhatsYouveGotController : Controller
    {
        private IBookService _bookservice;
        private IAuthorService _authorservice;
        public ShowMeWhatsYouveGotController(IBookService bookService, IAuthorService authorservice)
        {
            _bookservice = bookService;
            _authorservice = authorservice;
        }

        // Wyświetlenie zakładki zaskocz mnie! - wybierz rodzaj
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Roll(BookType bookType)
        {
            Random random = new Random();
            var selected =_bookservice.GetAll()
                .Where(b=> b.BookType == bookType)
                .ToList();
            var happynumber = random.Next(selected.Count());
            var blindchoose = selected[happynumber];
            var id = blindchoose.Id;
            var model =_bookservice.GetById(id);
            
            return View(model);
        }

        // GET: ShowMeWhatsYouveGotController/Create
        public ActionResult Create()
        {
            return View();
        }

       

        

        
        
    }
}
