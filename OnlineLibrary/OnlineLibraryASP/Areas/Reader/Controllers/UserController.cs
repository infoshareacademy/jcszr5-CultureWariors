using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using OnlineLibrary.BLL.Services;
using OnlineLibraryASP.ViewModels;
using System.Security.Claims;

namespace OnlineLibraryASP.Controllers
{
    [Area("Reader")]
    public class UserController : Controller
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private IUserService _userService;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private IShoppingCartRepository _shoppingCartRepository;
        public UserController(IBookService bookService, IAuthorService authorService, IWebHostEnvironment webHostEnvironment,IUserService userService, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IShoppingCartRepository shoppingCartRepository)
        {
            //_bookService = new BookService();
            _bookService = bookService;
            _authorService = authorService;
            _webHostEnvironment = webHostEnvironment;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _shoppingCartRepository = shoppingCartRepository;
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
        
        public ActionResult Details(int bookId)
        {
            ShoppingCart cartObj = new()
            {
                BookId = bookId,
                Book = _bookService.GetById(bookId)
            };
            
            return View(cartObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingCart.ApplicationUserId = claim.Value;
            shoppingCart.Book = null;
            _shoppingCartRepository.Create(shoppingCart);
            
            return RedirectToAction(nameof(Index));
        }

        [Route("rent/{id:int}")]
        public ActionResult Rent(int id)
        {
            var model = _bookService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("rent/{id:int}")]
        public ActionResult Rent(int id,Book book)
        {
            var rentedBook = _bookService.GetById(id);
            var userId = _userManager.GetUserId(User);
            var appUser = _userService.GetById(userId);
            _userService.RentBook(rentedBook,appUser);
            return RedirectToAction(nameof(ShowMyBooks));
        }
        public ActionResult ShowMyBooks()
        {
            var userId = _userManager.GetUserId(User);
            var model = _userService.GetUserRentedBooks(userId);
            return View(model);
        }
        [Route("return/{id:int}")]
        public ActionResult ReturnRent(int id)
        {
            var model = _bookService.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("return/{id:int}")]
        public ActionResult ReturnRent(int id, Book book)
        {

            var rentedBook = _bookService.GetById(id);
            var userId = _userManager.GetUserId(User);
            var appUser = _userService.GetById(userId);
            _userService.ReturnBook(rentedBook, appUser);
            return RedirectToAction(nameof(ShowMyBooks));
        }
    }
}
