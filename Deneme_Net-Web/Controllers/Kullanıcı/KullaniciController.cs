using Microsoft.AspNetCore.Mvc;

namespace Deneme_Net_Web.Controllers.Kullanıcı
{
    public class KullaniciController : Controller
    {
        public IActionResult Login()
        {
            return View();
        } 
        public IActionResult Register()
        {
            return View();
        }
    }
}
