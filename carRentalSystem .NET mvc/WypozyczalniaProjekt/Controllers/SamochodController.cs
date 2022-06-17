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
    /// Kontroler Samochodu zawierający metody Create, Edit, ViewAll oraz Delete
    /// </summary>
    public class SamochodController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich samochodach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Samochod> samochody;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                samochody = db.Samochod.ToList();
            }

            return View(samochody);
        }
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o samochodzie
        /// </summary>
        public ActionResult Create()
        {
            ViewBag.LokalizacjaID = new SelectList(db.Lokalizacja, "LokalizacjaID", "Miasto");
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "NazwaModelu");
            return View(new Samochod());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o samochodzie do serwera
        /// </summary>
        /// /// <param name="Samochod samochod"></param>
        public ActionResult Create(Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    var ListModele = db.Model.ToList().Find(x => x.ModelID.Equals(samochod.ModelID));
                    samochod.NazwaModelu = ListModele.NazwaModelu;
                    var ListLokalizacje = db.Lokalizacja.ToList().Find(x => x.LokalizacjaID.Equals(samochod.LokalizacjaID));
                    samochod.Miasto = ListLokalizacje.Miasto;


                    db.Samochod.Add(samochod);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Samochod());
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych samochodu
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Samochod samochod;
            using (ApplicationDbContext db = new ApplicationDbContext())
                samochod = db.Samochod.FirstOrDefault(x => x.SamochodID == id);
            ViewBag.LokalizacjaID = new SelectList(db.Lokalizacja, "LokalizacjaID", "Miasto");
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "NazwaModelu");
            return View(samochod);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o samochodzie
        /// </summary>
        /// /// <param name="Samochod samochod"></param>
        public ActionResult Edit(Samochod samochod)
        {
            if (!ModelState.IsValid)
                return View(samochod);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(samochod).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o samochodzie
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Samochod samochod;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                samochod = db.Samochod.FirstOrDefault(x => x.SamochodID == id);
            }
            return View(samochod);
        }
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o samochodzie
        /// </summary>
        /// /// <param name="id"></param>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Samochod samochod;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                samochod = db.Samochod.FirstOrDefault(x => x.SamochodID == id);
                db.Samochod.Remove(samochod);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}