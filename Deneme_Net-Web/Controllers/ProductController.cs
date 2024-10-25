
using Microsoft.AspNetCore.Mvc;

namespace Deneme_Net_Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult ProductIndex()
        {
            return View();
        }

        public IActionResult ProductDetails() { 
        
            return View();
        }
    }
}
