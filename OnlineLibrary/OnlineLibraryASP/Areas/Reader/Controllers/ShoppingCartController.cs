using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using OnlineLibrary.BLL.Services;
using System.Security.Claims;

namespace OnlineLibraryASP.Areas.Reader.Controllers
{
    [Area("Reader")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IRentedBookService _RentedBookService;
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository, IRentedBookService rentedBookService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _RentedBookService = rentedBookService;
        }

        private string GetUserIdString()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var myCart = claim.Value;
            return myCart;

        }


        public ActionResult Index()
        {

            var userCart = _shoppingCartRepository.GetAll().Where(s => s.ApplicationUserId == GetUserIdString());

            return View(userCart);
        }




        // GET: ShoppingCartController/Edit/5
        public ActionResult Delete(int id)
        {
            _shoppingCartRepository.Delete(id);
            return RedirectToAction(nameof(Index));

           
        }

        // GET: ShoppingCartController
        

        
        public ActionResult Rent()
        {
            var userCart = _shoppingCartRepository.GetAll().Where(s => s.ApplicationUserId == GetUserIdString());
            _RentedBookService.Rent(userCart);
            



            return View();
        }

       
    }
}
