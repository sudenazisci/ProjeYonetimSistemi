using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ProjeYonetim1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string SifreHash)
        {
            var predefinedUsers = new List<(string Email, string SifreHash, int Id, string AdSoyad, string Role)>
            {
                ("admin@example.com", "123456", 1, "Admin Kullanıcı", "Admin"),
                ("user@example.com", "password", 2, "Standart Kullanıcı", "User")
            };

            var user = predefinedUsers.FirstOrDefault(u => u.Email == Email && u.SifreHash == SifreHash);

            if (user != default)
            {
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetString("fullname", user.AdSoyad);
                HttpContext.Session.SetString("role", user.Role); // Kullanıcı rolünü kaydediyoruz.

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre!";
            return View();
        }
    }
}
