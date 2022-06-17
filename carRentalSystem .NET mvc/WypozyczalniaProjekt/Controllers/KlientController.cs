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
    /// Kontroler klienta zawierający metody Create, Edit, ViewAll, Details oraz Delete
    /// </summary>
    public class KlientController : Controller
    {
        // GET: Klient
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o kliencie
        /// </summary>
        public ActionResult Create()
        {
            return View(new Klient());
        }
        [HttpPost]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o kliencie do serwera
        /// </summary>
        /// /// <param name="Klient klient"></param>
        public ActionResult Create(Klient klient)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Klient.Add(klient);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Klient());
        }
        /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich klientach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Klient> klienci;
            using (ApplicationDbContext db = new ApplicationDbContext())
                klienci = db.Klient.ToList();
            return View(klienci);
        }
        /// <summary>
        /// Metoda Details wyświetlająca szczegóły danych o kliencie
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Details(int id)
        {
            Klient klient;
            using (ApplicationDbContext db = new ApplicationDbContext())
                klient = db.Klient.FirstOrDefault(x => x.KlientID == id);

            return View(klient);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych klienta
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Klient klient;
            using (ApplicationDbContext db = new ApplicationDbContext())
                klient = db.Klient.FirstOrDefault(x => x.KlientID == id);
            return View(klient);
        }
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o kliencie
        /// </summary>
        /// /// <param name="Klient klient"></param>
        [HttpPost]
        public ActionResult Edit(Klient klient)
        {
            if (!ModelState.IsValid)
                return View(klient);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(klient).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o kliencie
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Klient klient;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                klient = db.Klient.FirstOrDefault(x => x.KlientID == id);
            }
            return View(klient);
        }
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o kliencie
        /// </summary>
        /// /// <param name="id"></param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Klient klient;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                klient = db.Klient.FirstOrDefault(x => x.KlientID == id);
                db.Klient.Remove(klient);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}