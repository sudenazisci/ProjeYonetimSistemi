using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProjeYonetim1.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            // Örnek görev listesi (veritabanı yerine geçici olarak kullanılıyor)
            var tasks = new List<dynamic>
            {
                new { Id = 1, ProjeId = 1, GorevAdi = "Veritabanı Tasarımı", Aciklama = "Veritabanı şeması oluşturulacak", AtananKullanici = "Kullanıcı 1", BaslangicTarihi = "2025-02-02", BitisTarihi = "2025-02-10", Durum = "Tamamlandı" },
                new { Id = 2, ProjeId = 1, GorevAdi = "Ödeme Sistemi Entegrasyonu", Aciklama = "Stripe API ile ödeme sistemi eklenecek", AtananKullanici = "Kullanıcı 2", BaslangicTarihi = "2025-02-15", BitisTarihi = "2025-03-10", Durum = "Devam Ediyor" },
                new { Id = 3, ProjeId = 2, GorevAdi = "Mobil Arayüz Tasarımı", Aciklama = "Figma ile UI/UX tasarımı yapılacak", AtananKullanici = "Kullanıcı 3", BaslangicTarihi = "2025-03-05", BitisTarihi = "2025-03-20", Durum = "Beklemede" },
                new { Id = 4, ProjeId = 3, GorevAdi = "Müşteri Veri Analizi", Aciklama = "SQL raporları hazırlanacak", AtananKullanici = "Kullanıcı 4", BaslangicTarihi = "2025-01-20", BitisTarihi = "2025-02-25", Durum = "Devam Ediyor" }
            };

         
            return View(tasks);
        }

        public IActionResult Create()
        {
            // Eğer kullanıcı admin değilse, ana sayfaya yönlendir
            if (HttpContext.Session.GetString("role") != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(string ProjeAdi, string Aciklama, DateTime BaslangicTarihi, DateTime BitisTarihi, string Durum)
        {
            // Burada veritabanına ekleme işlemi yapılacak.
            TempData["Success"] = "Proje başarıyla eklendi!";
            return RedirectToAction("Index");
        }
    }
}
