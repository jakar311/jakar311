using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca modele aut w wypożyczalni
    /// </summary>
    public class Model
    {
        /// <summary>
        /// ID modelu wraz z hermetyzacją
        /// </summary>
        [Key]
        public int ModelID { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Nazwa modelu wraz z hermetyzacją
        /// </summary>
        public string NazwaModelu { get; set; }
        /// <summary>
        /// Statyczna zmienna ID i przypisana do niej wartość 0
        /// </summary>
        public static int ID = 0;
        //public List<Marka> Marki { get; set; } = new List<Marka>();
        /// <summary>
        /// Konstruktor nieparametryczny
        /// </summary>
        public Model() { }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje nazwę modelu oraz identyfikator
        /// </summary>
        public Model(string nazwaModelu/*, List<Marka> marki*/)
        {
            ModelID = System.Threading.Interlocked.Increment(ref ID);
            NazwaModelu = nazwaModelu;
            //Marki = marki;
        }
        /// <summary>
        /// ID marki wraz z hermetyzacją
        /// </summary>
        public int MarkaID { get; set; }
        /// <summary>
        /// Nazwa marki wraz z hermetyzacją
        /// </summary>
        public string NazwaMarki { get; set; }
        /// <summary>
        /// virtualny obiekt Marka wraz z hermetyzacją
        /// </summary>
        public virtual Marka Marka { get; set; }

    }
}