using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WypozyczalniaProjekt.Models;
using WypozyczalniaProjekt.Models.DbModels;

namespace WypozyczalniaProjekt.Controllers
{
    /// <summary>
    /// Kontroler lokalizacji zawierający metody Create, Edit, ViewAll, Details oraz Delete
    /// </summary>
    public class LokalizacjaController : Controller
    {
        // GET: Lokalizacja
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o lokalizacji
        /// </summary>
        public ActionResult Create()
        {
            return View(new Lokalizacja());
        }
        [HttpPost]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o lokalizacji do serwera
        /// </summary>
        /// /// <param name="Lokalizacja lokalizacja"></param>
        public ActionResult Create(Lokalizacja lokalizacja)
        {
            if (!ModelState.IsValid)
            {
                return View(new Lokalizacja());
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Lokalizacja.Add(lokalizacja);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda ViewaLl wyświetlająca informacje o wszystkich lokalizacjach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Lokalizacja> lokalizacje;
            using (ApplicationDbContext db = new ApplicationDbContext())
                lokalizacje = db.Lokalizacja.ToList();
            return View(lokalizacje);
        }
        /// <summary>
        /// Metoda Details wyświetlająca szczegóły danych o lokalizacji
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Details(int id)
        {
            Lokalizacja lokalizacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
                lokalizacja = db.Lokalizacja.FirstOrDefault(x => x.LokalizacjaID == id);

            return View(lokalizacja);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych lokalizacji
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Lokalizacja lokalizacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
                lokalizacja = db.Lokalizacja.FirstOrDefault(x => x.LokalizacjaID == id);
            return View(lokalizacja);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o lokalizacji
        /// </summary>
        /// /// <param name="Lokalizacja lokalizacja"></param>
        public ActionResult Edit(Lokalizacja lokalizacja)
        {
            if (!ModelState.IsValid)
                return View(lokalizacja);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(lokalizacja).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o lokalizacji
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Lokalizacja lokalizacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                lokalizacja = db.Lokalizacja.FirstOrDefault(x => x.LokalizacjaID == id);
            }
            return View(lokalizacja);
        }
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o lokalizacji
        /// </summary>
        /// /// <param name="id"></param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Lokalizacja lokalizacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                lokalizacja = db.Lokalizacja.FirstOrDefault(x => x.LokalizacjaID == id);
                db.Lokalizacja.Remove(lokalizacja);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}