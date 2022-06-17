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
    /// Kontroler Marki auta zawierający metody Create, Edit, ViewAll, Details oraz Delete
    /// </summary>
    public class MarkaController : Controller
    {
        // GET: Marka
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o marce
        /// </summary>
        public ActionResult Create()
        {
            return View(new Marka());
        }
        [HttpPost]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o marce do serwera
        /// </summary>
        /// /// <param name="Marka marka"></param>
        public ActionResult Create(Marka marka)
        {
            if (!ModelState.IsValid)
            {
                return View(new Marka());
            }
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Marka.Add(marka);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich markach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Marka> marki;
            using (ApplicationDbContext db = new ApplicationDbContext())
                marki = db.Marka.ToList();
            return View(marki);
        }
        /// <summary>
        /// Metoda Details wyświetlająca szczegóły danych o marce
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Details(int id)
        {
            Marka marka;
            using (ApplicationDbContext db = new ApplicationDbContext())
                marka = db.Marka.FirstOrDefault(x => x.MarkaID == id);

            return View(marka);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych marki
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Marka marka;
            using (ApplicationDbContext db = new ApplicationDbContext())
                marka = db.Marka.FirstOrDefault(x => x.MarkaID == id);
            return View(marka);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o marce
        /// </summary>
        /// /// <param name="Marka marka"></param>
        public ActionResult Edit(Marka marka)
        {
            if (!ModelState.IsValid)
                return View(marka);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(marka).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o marce
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Marka marka;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                marka = db.Marka.FirstOrDefault(x => x.MarkaID == id);
            }
            return View(marka);
        }
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o marce
        /// </summary>
        /// /// <param name="id"></param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Marka marka;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                marka = db.Marka.FirstOrDefault(x => x.MarkaID == id);
                db.Marka.Remove(marka);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}