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
    /// Kontroler Modelu auta zawierający metody Create, Edit, ViewAll, Details oraz Delete
    /// </summary>
    public class ModelController : Controller
    {
        // GET: Model

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Model
        public ActionResult Index()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var marki = db.Model.Include(b => b.Marka);
                return View(marki.ToList());
            }

        }
        /// <summary>
        /// Metoda Create typu GET żądająca pobrania informacji o modelu
        /// </summary>
        public ActionResult Create()
        {
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "NazwaMarki");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        /// <summary>
        /// Metoda Create typu POST żadająca przyjęcia danych o modelu do serwera
        /// </summary>
        /// /// <param name="Model model"></param>
        public ActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    var ListMarki = db.Marka.ToList().Find(x => x.MarkaID.Equals(model.MarkaID));
                    model.NazwaMarki = ListMarki.NazwaMarki;
                    db.Model.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }
            return View(new Model());
        }
        /// <summary>
        /// Metoda ViewAll wyświetlająca informacje o wszystkich modelach
        /// </summary>
        public ActionResult ViewAll()
        {
            List<Model> modele;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Configuration.LazyLoadingEnabled = false;
                modele = db.Model.ToList();
            }

            return View(modele);
        }
        /// <summary>
        /// Metoda Details wyświetlająca szczegóły danych o modelu
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Details(int id)
        {
            Model model;
            using (ApplicationDbContext db = new ApplicationDbContext())
                model = db.Model.FirstOrDefault(x => x.ModelID == id);

            return View(model);
        }
        /// <summary>
        /// Metoda Edit typu GET pozwalająca na wyświetlenie możliwości edycjy danych modelu
        /// </summary>
        /// <param name="id"></param>
        public ActionResult Edit(int id)
        {
            Model model;
            using (ApplicationDbContext db = new ApplicationDbContext())
                model = db.Model.FirstOrDefault(x => x.ModelID == id);
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "NazwaMarki");
            return View(model);
        }
        [HttpPost]
        /// <summary>
        /// Metoda Edit typu POST pozwalająca na żądająca przyjęcia zedytowanych danych o modelu
        /// </summary>
        /// /// <param name="Model model"></param>
        public ActionResult Edit(Model model)
        {
            if (!ModelState.IsValid)
                return View(model);

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
        /// <summary>
        /// Metoda DELETE wyświetlająca możliwość usunięcia danych o modelu
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult Delete(int? id)
        {
            Model model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Model.FirstOrDefault(x => x.ModelID == id);
            }
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        /// <summary>
        /// Metoda DELETEConfirm usuwająca dane o modelu
        /// </summary>
        /// /// <param name="id"></param>
        public ActionResult DeleteConfirm(int? id)
        {
            Model model;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                model = db.Model.FirstOrDefault(x => x.ModelID == id);
                db.Model.Remove(model);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }
    }
}