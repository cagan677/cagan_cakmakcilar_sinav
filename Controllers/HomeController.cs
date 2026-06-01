using Microsoft.AspNetCore.Mvc;
using AdSoyad_Sinav.Models;

namespace AdSoyad_Sinav.Controllers;

public class HomeController : Controller
{
    private readonly KampusContext _db;
    public HomeController(KampusContext db) { _db = db; }

    [HttpGet]
    [Route("")] // Varsayılan boş link için (localhost:5000)
    [Route("Etkinlikler")] // GÖREV 4: Özel Rota Tanımlaması (localhost:5000/Etkinlikler)
    public IActionResult Index() {
        return View(_db.Etkinlikler.OrderBy(e => e.Tarih).ToList());
    }

    [HttpPost]
    public IActionResult Ekle(Etkinlik yeniEtkinlik) {
        if (ModelState.IsValid) {
            _db.Etkinlikler.Add(yeniEtkinlik);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("Index", _db.Etkinlikler.ToList());
    }

    // GÖREV 1: Veritabanından Veri Silme (CRUD) Metodu
    [HttpPost]
    public IActionResult Sil(int id) {
        var etkinlik = _db.Etkinlikler.Find(id);
        if (etkinlik != null) {
            _db.Etkinlikler.Remove(etkinlik);
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}