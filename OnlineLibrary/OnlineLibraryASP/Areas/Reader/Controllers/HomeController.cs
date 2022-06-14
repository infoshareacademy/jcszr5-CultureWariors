using Microsoft.AspNetCore.Mvc;
using OnlineLibrary.BLL.Models;
using OnlineLibrary.BLL.Services;
using System.Diagnostics;

namespace OnlineLibraryASP.Controllers
{
    [Area("Reader")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowMeWhatsYouveGot()
        {
            return View();
        }
    }
}
