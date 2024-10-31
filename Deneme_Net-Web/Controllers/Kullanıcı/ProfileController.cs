using Business.Abstract;
using Deneme_Net_Web.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Deneme_Net_Web.Controllers.Kullanıcı
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IKullaniciService servisK;

        public ProfileController(IKullaniciService servisK)
        {
            this.servisK = servisK;
        }

        public IActionResult ProfileIndex()
        {
            ProfileinfoLoader();
            return View();
        }
        private void ProfileinfoLoader()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            Kullanicilar user = servisK.GetById(userid);
            ViewData["Fullname"] = user.Fullname;
            ViewData["Username"] = user.Username;
            ViewData["Profileİmage"] = user.ProfilImageFileName;
            ViewData["Email"] = user.Email;

        }

       
        [HttpPost]
        public IActionResult ProfileChangeImage([Required] IFormFile file)
        {

            if (ModelState.IsValid)
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanicilar user = servisK.GetById(userId);

                string folderpath = Path.Combine($"wwwroot/Uploads/", user.ProfilImageFileName);
                if (System.IO.File.Exists(folderpath))
                {
                    System.IO.File.Delete(folderpath);
                }

                string fileName = $"p_{userId}.{file.ContentType.Split('/')[1]}";

                Stream stream = new FileStream($"wwwroot/uploads/{fileName}", FileMode.OpenOrCreate);
                file.CopyTo(stream);
                stream.Close();

                user.ProfilImageFileName = fileName;

                servisK.Update(user);


                ViewData["Profileİmage"] = user.ProfilImageFileName;
                TempData["Toast"] = "Basarili";
               

                return RedirectToAction(nameof(ProfileIndex));
            }



            return RedirectToAction(nameof(ProfileIndex));

        }


        [HttpPost]
        public IActionResult ProfileChangeFullname([Required][MinLength(5, ErrorMessage = "En az 5 Karakterden oluşmalı")] string Fullname) {

            if (ModelState.IsValid) {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanicilar user = servisK.GetById(userId);
                user.Fullname = Fullname;
                servisK.Update(user);

                ViewData["Fullname"] = user.Fullname;
                TempData["Toast"] = "Fullname";

                return RedirectToAction(nameof(ProfileIndex));

            }
            TempData["ToastHata"] = "Basarisiz";

            return RedirectToAction(nameof(ProfileIndex));


        }


        [HttpPost]
        public IActionResult ProfileChangeUsername([Required][MinLength(5, ErrorMessage = "En az 5 Karakterden oluşmalı")] string Username) {

            if (ModelState.IsValid) {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanicilar user = servisK.GetById(userId);
                user.Username = Username;
                servisK.Update(user);

                ViewData["Username"] = user.Username;
                TempData["Toast"] = "Username";

                return RedirectToAction(nameof(ProfileIndex));

            }
            TempData["ToastHata"] = "Basarisiz";

            return RedirectToAction(nameof(ProfileIndex));


        }


        [HttpPost]
        public IActionResult ProfileChangeEmail([Required][DataType(DataType.EmailAddress)] string email)
        {

            if (ModelState.IsValid)
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Kullanicilar user = servisK.GetById(userId);
                user.Email = email;
                servisK.Update(user);

                ViewData["Email"] = user.Email;
                TempData["Toast"] = "email";

                return RedirectToAction(nameof(ProfileIndex));

            }
            TempData["ToastHata"] = "Basarisiz";

            return RedirectToAction(nameof(ProfileIndex));


        }

        [HttpPost]
        public IActionResult ProfileChangePassword([Required][MinLength(4, ErrorMessage = "En az 4 Karakterden oluşmalı")] string pass,string rpass)
        {

            if (ModelState.IsValid)
            {
                if(pass.Equals(rpass, StringComparison.Ordinal))
                {
                    int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    Kullanicilar user = servisK.GetById(userId);
                    user.Password = pass;
                    servisK.Update(user);
                    TempData["Toast"] = "pass";
                }
                else
                {
                    TempData["ToastHata"] = "Basarisiz";
                }

                return RedirectToAction(nameof(ProfileIndex));

            }
            TempData["ToastHata"] = "Basarisiz";

            return RedirectToAction(nameof(ProfileIndex));


        }




    }
}
