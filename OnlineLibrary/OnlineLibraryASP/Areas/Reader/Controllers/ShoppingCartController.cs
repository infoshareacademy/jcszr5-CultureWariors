using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Repositories;
using System.Security.Claims;

namespace OnlineLibraryASP.Areas.Reader.Controllers
{
    [Area("Reader")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;

        }


        // GET: ShoppingCartController
        public ActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var myCart = claim.Value;
            var userCart = _shoppingCartRepository.GetAll().Where(s=>s.ApplicationUserId==myCart);

            return View(userCart);
        }

        

        
       

        // GET: ShoppingCartController/Edit/5
        public ActionResult Delete(int id)
        {
            _shoppingCartRepository.Delete(id);
            return RedirectToAction(nameof(Index));

           
        }

       

       
    }
}
