using Business.Abstract;
using Deneme_Net_Web.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Deneme_Net_Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private IKullaniciService servisK;

        public HomeController(IKullaniciService servisK)
        {
            this.servisK = servisK;
        }

        public IActionResult HomeIndex()
        {
            ProfileinfoLoader();
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        private void ProfileinfoLoader()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Kullanicilar user = servisK.GetById(userid);
            ViewData["Fullname"] = user.Fullname;
            ViewData["Username"] = user.Username;
            ViewData["Profile›mage"] = user.ProfilImageFileName;
            ViewData["Email"] = user.Email;

        }
    }
}
