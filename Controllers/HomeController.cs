using Microsoft.AspNetCore.Mvc;
using cagan_cakmakcilar_sinav.Models;

namespace cagan_cakmakcilar_sinav.Controllers;

public class HomeController : Controller
{
    private readonly KampusContext _db;
    public HomeController(KampusContext db) { _db = db; }

    [HttpGet]
    [Route("")] 
    [Route("Etkinlikler")] // GÖREV 4: Özel Rota
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

    // GÖREV 1: Silme İşlemi (CRUD) Metodu
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