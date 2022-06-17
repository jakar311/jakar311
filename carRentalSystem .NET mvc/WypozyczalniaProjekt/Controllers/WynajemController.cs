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
    /// Kontroler Wynajmu auta zawierający metody Create, Edit, ViewAll, Details oraz Delete
    /// </summary>
    public class WynajemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich wynajmach samochodów
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Wynajem> wynajmy;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                wynajmy = db.Wynajem.ToList();
            }

            return View(wynajmy);
        }
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o wynajmie
        /// </summary>
        public ActionResult Create()
        {
            ViewBag.RezerwacjaID = new SelectList(db.Rezerwacja, "RezerwacjaID", "RezerwacjaID");
            ViewBag.KlientID = new SelectList(db.Klient, "KlientID", "NazwiskoKlienta");
            ViewBag.PracownikID = new SelectList(db.Pracownik, "PracownikID", "NazwiskoPracownika");
            return View(new Wynajem());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o wynajmie do serwera
        /// </summary>
        /// /// <param name="Wynajem wynajem"></param>
        public ActionResult Create(Wynajem wynajem)
        {
            ViewBag.RezerwacjaID = new SelectList(db.Rezerwacja, "RezerwacjaID", "RezerwacjaID");
            ViewBag.KlientID = new SelectList(db.Klient, "KlientID", "NazwiskoKlienta");
            ViewBag.PracownikID = new SelectList(db.Pracownik, "PracownikID", "NazwiskoPracownika");
            if (ModelState.IsValid)
            {
                var ListRezerwacje = db.Rezerwacja.ToList().Find(x => x.RezerwacjaID.Equals(wynajem.RezerwacjaID));
                if (ListRezerwacje != null)
                {
                    wynajem.RezerwacjaID = ListRezerwacje.RezerwacjaID;
                }
                var ListPracownicy = db.Pracownik.ToList().Find(x => x.PracownikID.Equals(wynajem.PracownikID));
                wynajem.NazwiskoPracownika = ListPracownicy.NazwiskoPracownika;
                var ListKlienci = db.Klient.ToList().Find(x => x.KlientID.Equals(wynajem.KlientID));
                wynajem.NazwiskoKlienta = ListKlienci.NazwiskoKlienta;


                db.Wynajem.Add(wynajem);
                db.SaveChanges();
                return RedirectToAction("ViewAll");
            }
            return View(wynajem);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych wynajmu
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Wynajem wynajem;
            using (ApplicationDbContext db = new ApplicationDbContext())
                wynajem = db.Wynajem.FirstOrDefault(x => x.WynajemID == id);
            ViewBag.KlientID = new SelectList(db.Klient, "KlientID", "NazwiskoKlienta");
            ViewBag.PracownikID = new SelectList(db.Pracownik, "PracownikID", "NazwiskoPracownika");
            return View(wynajem);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o wynajmie
        /// </summary>
        /// /// <param name="Wynajem wynajem"></param>
        public ActionResult Edit(Wynajem wynajem)
        {
            if (!ModelState.IsValid)
                return View(wynajem);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(wynajem).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o wynajmie
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Wynajem wynajem;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                wynajem = db.Wynajem.FirstOrDefault(x => x.WynajemID == id);
            }
            return View(wynajem);
        }
        [HttpPost, ActionName("Delete")]
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o wynajmie
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult DeleteConfirm(int? id)
        {
            Wynajem wynajem;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                wynajem = db.Wynajem.FirstOrDefault(x => x.WynajemID == id);
                db.Wynajem.Remove(wynajem);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}