using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Deneme_Net_Web.Controllers.Kullanıcı
{
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult ProfileIndex()
        {
            return View();
        }
    }
}
