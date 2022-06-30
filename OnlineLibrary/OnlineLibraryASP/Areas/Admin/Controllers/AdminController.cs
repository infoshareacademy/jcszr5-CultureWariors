using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BLL.Enums;
using OnlineLibrary.BLL.Services;
using System.Security.Claims;

namespace OnlineLibraryASP.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class AdminController : Controller
    {


        private readonly IRentedBookService _rentedBookService;



        public AdminController(IRentedBookService rentedBookService)
        {

            _rentedBookService = rentedBookService;
        }





        // GET: AdminController
        public ActionResult ToRent()
        {
            var rentedBooks = _rentedBookService
                .GetAll()
                .Where(r => r.Status == BookStatus.Processing)
                .OrderBy(r => r.ApplicationUser.Surname)
                .ThenBy(r => r.ApplicationUser.Name);
            return View(rentedBooks);
        }

        public ActionResult ToRelase()
        {
            var rentedBooks = _rentedBookService
                .GetAll()
                .Where(r => r.Status == BookStatus.Ready)
                .OrderBy(r => r.ApplicationUser.Surname)
                .ThenBy(r => r.ApplicationUser.Name);
            return View(rentedBooks);
        }


        public ActionResult ToReturn()
        {
            var rentedBooks = _rentedBookService
                .GetAll()
                .Where(r => r.Status == BookStatus.Rented|| r.Status==BookStatus.Delayed)
                .OrderBy(r => r.ApplicationUser.Surname)
                .ThenBy(r => r.ApplicationUser.Name);
            return View(rentedBooks);
        }


        public ActionResult History()
        {
            var rentedBooks = _rentedBookService
                .GetAll()
                .Where(r => r.Status == BookStatus.Returned)
                .OrderBy(r => r.ApplicationUser.Surname)
                .ThenBy(r => r.ApplicationUser.Name);
            return View(rentedBooks);

        }


        // GET: AdminController/
        public ActionResult ReadytoRelase(int id)
        {
            var model = _rentedBookService.GetById(id);
            _rentedBookService.ReadyBooks(model);

            return RedirectToAction(nameof(ToRent));
        }

        public ActionResult Renting(int id)
        {
            var model = _rentedBookService.GetById(id);
            _rentedBookService.RentingBooks(model);

            return RedirectToAction(nameof(ToRent));
        }


        public ActionResult Returning(int id)
        {
            var model = _rentedBookService.GetById(id);
            _rentedBookService.ReturningBooks(model);

            return RedirectToAction(nameof(ToRent));
        }
    }
}




        

       
