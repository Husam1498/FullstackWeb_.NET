using Business.Abstract;
using Deneme_Net_Web.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Deneme_Net_Web.Controllers
{
    
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
           
            return View();
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //[Authorize]

        //private void ProfileinfoLoader()
        //{
        //    int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    Kullanicilar user = servisK.GetById(userid);
        //    ViewData["Fullname"] = user.Fullname;
        //    ViewData["Username"] = user.Username;
        //    ViewData["Profileİmage"] = user.ProfilImageFileName;
        //    ViewData["Email"] = user.Email;

        //}
    }
}
