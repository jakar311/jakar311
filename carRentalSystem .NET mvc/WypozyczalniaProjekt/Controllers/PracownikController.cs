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
    /// Kontroler pracownika zawierający metody Create, Edit, ViewAll, Details oraz Delete
    /// </summary>
    public class PracownikController : Controller
    {
        // GET: Pracownik
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o pracowniku
        /// </summary>
        public ActionResult Create()
        {
            return View(new Pracownik());
        }
        [HttpPost]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o pracowniku do serwera
        /// </summary>
        /// /// <param name="Pracownik pracownik"></param>
        public ActionResult Create(Pracownik pracownik)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Pracownik.Add(pracownik);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Pracownik());
        }
        /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich pracownikach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Pracownik> pracownicy;
            using (ApplicationDbContext db = new ApplicationDbContext())
                pracownicy = db.Pracownik.ToList();
            return View(pracownicy);
        }
        /// <summary>
        /// Metoda Details wyświetlająca szczegóły danych o kliencie
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Details(int id)
        {
            Pracownik pracownik;
            using (ApplicationDbContext db = new ApplicationDbContext())
                pracownik = db.Pracownik.FirstOrDefault(x => x.PracownikID == id);

            return View(pracownik);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych pracownika
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Pracownik pracownik;
            using (ApplicationDbContext db = new ApplicationDbContext())
                pracownik = db.Pracownik.FirstOrDefault(x => x.PracownikID == id);
            return View(pracownik);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o pracowniku
        /// </summary>
        /// /// <param name="Pracownik pracownik"></param>
        public ActionResult Edit(Pracownik pracownik)
        {
            if (!ModelState.IsValid)
                return View(pracownik);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(pracownik).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o pracowniku
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Pracownik pracownik;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pracownik = db.Pracownik.FirstOrDefault(x => x.PracownikID == id);
            }
            return View(pracownik);
        }
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o pracowniku
        /// </summary>
        /// /// <param name="id"></param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Pracownik pracownik;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                pracownik = db.Pracownik.FirstOrDefault(x => x.PracownikID == id);
                db.Pracownik.Remove(pracownik);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}