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
    /// Kontroler rezerwacji zawierający metody Create, Edit, ViewAll oraz Delete
    /// </summary>
    public class RezerwacjaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Rezerwacja
        public ActionResult Index()
        {
            return View();
        }

        /// /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich rezerwacjach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Rezerwacja> rezerwacje;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                rezerwacje = db.Rezerwacja.ToList();
            }

            return View(rezerwacje);
        }
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o rezerwacji
        /// </summary>
        public ActionResult Create()
        {
            ViewBag.WynajemID = new SelectList(db.Wynajem, "WynajemID", "WynajemID");
            ViewBag.LokalizacjaID = new SelectList(db.Lokalizacja, "LokalizacjaID", "Miasto");
            ViewBag.KlientID = new SelectList(db.Klient, "KlientID", "NazwiskoKlienta");
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "NazwaModelu");
            return View(new Rezerwacja());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o rezerwacji do serwera
        /// </summary>
        /// /// <param name="Rezerwacja rezerwacja"></param>
        public ActionResult Create(Rezerwacja rezerwacja)
        {
            if (ModelState.IsValid)
            {
                var ListWynajmy = db.Wynajem.ToList().Find(x => x.WynajemID.Equals(rezerwacja.WynajemID));
                if (ListWynajmy != null)
                {
                    rezerwacja.WynajemID = ListWynajmy.WynajemID;
                }
                var ListModele = db.Model.ToList().Find(x => x.ModelID.Equals(rezerwacja.ModelID));
                rezerwacja.NazwaModelu = ListModele.NazwaModelu;
                var ListLokalizacje = db.Lokalizacja.ToList().Find(x => x.LokalizacjaID.Equals(rezerwacja.LokalizacjaID));
                rezerwacja.Miasto = ListLokalizacje.Miasto;
                var ListKlienci = db.Klient.ToList().Find(x => x.KlientID.Equals(rezerwacja.KlientID));
                rezerwacja.NazwiskoKlienta = ListKlienci.NazwiskoKlienta;


                db.Rezerwacja.Add(rezerwacja);
                db.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            return View(rezerwacja);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych rezerwacji
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Rezerwacja rezerwacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
                rezerwacja = db.Rezerwacja.FirstOrDefault(x => x.RezerwacjaID == id);
            ViewBag.LokalizacjaID = new SelectList(db.Lokalizacja, "LokalizacjaID", "Miasto");
            ViewBag.KlientID = new SelectList(db.Klient, "KlientID", "NazwiskoKlienta");
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "NazwaModelu");
            return View(rezerwacja);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o rezerwacji
        /// </summary>
        /// /// <param name="Rezerwacja rezerwacja"></param>
        public ActionResult Edit(Rezerwacja rezerwacja)
        {
            if (!ModelState.IsValid)
                return View(rezerwacja);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(rezerwacja).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o rezerwacji
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Rezerwacja rezerwacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                rezerwacja = db.Rezerwacja.FirstOrDefault(x => x.RezerwacjaID == id);
            }
            return View(rezerwacja);
        }
        [HttpPost, ActionName("Delete")]
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o rezerwacji
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult DeleteConfirm(int? id)
        {
            Rezerwacja rezerwacja;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                rezerwacja = db.Rezerwacja.FirstOrDefault(x => x.RezerwacjaID == id);
                db.Rezerwacja.Remove(rezerwacja);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}