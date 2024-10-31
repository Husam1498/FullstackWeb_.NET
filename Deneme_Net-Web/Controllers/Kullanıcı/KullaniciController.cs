using Business.Abstract;
using Deneme_Net_Web.Models;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace Deneme_Net_Web.Controllers.Kullanıcı
{
    public class KullaniciController : Controller
    {
        private IKullaniciService servisK;

        public KullaniciController(IKullaniciService servisK)
        {
            this.servisK = servisK;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Kullanicilar user=servisK.GetFindusername(model.Username.ToLower());
                if (user!=null)
                {
                    if (user.Password == model.Password)
                    {
                        //Claims kullanmamızın sebebi cookiede tutmak içindir
                        List<Claim> claims = new List<Claim>();
                       // claims.Add(new Claim("Id", user.K_id.ToString()));Aşagıdaki gibi tanımlanabilir
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.K_id.ToString()));//int olduğu için stringe çeviriyoruz
                        claims.Add(new Claim(ClaimTypes.Name, user.Fullname ?? string.Empty));//String boş ise belirtmen lazım claimler boş değer alamaz
                        claims.Add(new Claim(ClaimTypes.Role, user.Role));
                        claims.Add(new Claim("Username", user.Username)) ;//String boş ise belirtmen lazım claimler boş değer alamaz
                        claims.Add(new Claim("ProfilImage", user.ProfilImageFileName));
                        //claims ve hangi authenticationu(AuthanticationType) kullanacağını söylemelisin, ve bize buna uygun bir clası oluşturacak
                        ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                        //sisteme login yap
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

                        ViewData["Giris"] = "Olumlu";

                        return RedirectToAction("HomeIndex","Home");
                    }
                    else
                    {
                        ViewData["Giris"] = "Olumsuz";
                    }
                }
                else
                {
                    ViewData["Giris"] = "Olumsuz";
                }
            }
            else
            {
                ViewData["Giris"] = "Olumsuz";
            }


            return View(model);
        } 



        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Kullanicilar k1=servisK.GetFindusername(model.Username);
                if (k1 == null) {
                    Kullanicilar k = new Kullanicilar
                    {
                        Fullname = model.Fullname,
                        Username= model.Username,
                        Password = model.Password,
                        Email = model.Email

                    };
                    servisK.Create(k);
                    TempData["Kayit"] = "Basarili";
                    

                    return RedirectToAction(nameof(Login));
                }
                else
                {
                    ViewData["Kayit"] = "Kayitvar";
                    ModelState.AddModelError("Username", "Kaydınız var lutfen giriş yapınız");
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
