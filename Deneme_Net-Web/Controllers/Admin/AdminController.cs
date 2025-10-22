using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Deneme_Net_Web.Controllers.Admin
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IKullaniciService servisK;

        public AdminController(IKullaniciService servisK)
        {
            this.servisK = servisK;
        }

        public IActionResult AdminIndex()
        {
            ProfileinfoLoader();
            return View();
        }
        public IActionResult AdminIndexPartial()
        {
            ProfileinfoLoader();
            return PartialView("_MemberAdminProfilePartial");
        }
        public IActionResult AdminProfile()
        {
            ProfileinfoLoader();
            return View();
        }

        //Admin Profil işlemleri

        private void ProfileinfoLoader()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Kullanicilar user=servisK.GetById(userid);
            ViewData["Fullname"] = user.Fullname;
            ViewData["Username"] = user.Username;
            ViewData["Profileİmage"] = user.ProfilImageFileName;
            ViewData["Pass"] = user.Password;

        }
        [HttpPost]
        public IActionResult ProfileChangeImage([Required] IFormFile file) {

            if (ModelState.IsValid) {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanicilar user = servisK.GetById(userId);

                string fileName = $"{user.K_id}_{file.FileName.Split('.')[0]}.{file.ContentType.Split('/')[1]}";

                Stream stream = new FileStream($"wwwroot/uploads/Kullanici/{fileName}", FileMode.OpenOrCreate);

                var oldPath = Path.Combine("wwwroot/uploads/Kullanici", user.ProfilImageFileName);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }
                file.CopyTo(stream);
                stream.Close();
                stream.Dispose();          
                user.ProfilImageFileName = fileName;
                servisK.Update(user);
                TempData["Toast"] = "Resim";
                ProfileinfoLoader();

                return RedirectToAction(nameof(AdminProfile));
            }        
            return View();        
        }

        [HttpPost]
        public IActionResult ProfileFullName([Required][MinLength(5,ErrorMessage ="En az 5 karakterden oluşmalı")]  string Fullname)
        {
            if (ModelState.IsValid) {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanicilar user = servisK.GetById(userId);
                user.Fullname = Fullname; 
                servisK.Update(user);
                ViewData["Fullname"]=user.Fullname;
                TempData["Toast"] = "Fullname";
                return RedirectToAction(nameof(AdminProfile));




            }

            return View();
        }
        [HttpPost]
        public IActionResult ProfileChangeUsername( string Username)
        {
            if (ModelState.IsValid) {
                Kullanicilar kontorlUsername=servisK.GetFindusername(Username);
                if (kontorlUsername == null)
                {
                    int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    Kullanicilar user = servisK.GetById(userId);
                    user.Username=Username;
                    servisK.Update(user);
                    ViewData["Username"] = user.Username;
                    TempData["Toast"] = "userName";
                    return RedirectToAction(nameof(AdminProfile));
                }
                else
                {
                    TempData["ToastHata"] = "Vuser";
                    return RedirectToAction(nameof(AdminProfile));

                }
                

            }
            return View();
        } 

        [HttpPost]
        public IActionResult ProfileChangePassword( string Pass , string RPass)
        {

            if (ModelState.IsValid) {
                if (Pass.Equals(RPass,StringComparison.Ordinal))
                {
                    int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    Kullanicilar user = servisK.GetById(userId);
                    user.Password=Pass;
                    servisK.Update(user);
                    TempData["Toast"] = "pass";
                    return RedirectToAction(nameof(AdminProfile));
                }
                else
                {
                    TempData["ToastHata"] = "Apass";
                    return RedirectToAction(nameof(AdminProfile));
                }
            
            
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("HomeIndex", "Home");
        }

    }
}
