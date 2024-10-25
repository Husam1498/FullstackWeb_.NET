using Deneme_Net_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Deneme_Net_Web.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult HomeIndex()
        {
            return View();
        }
    }
}
