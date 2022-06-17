using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca marki aut w wypożyczalni
    /// </summary>
    public class Marka
    {
        /// <summary>
        /// ID marki wraz z hermetyzacją
        /// </summary>
        [Key]
        public int MarkaID { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Nazwa marki wraz z hermetyzacją
        /// </summary>
        public string NazwaMarki { get; set; }
        /// <summary>
        /// Statyczna zmienna ID i przypisana do niej wartość 0
        /// </summary>
        public static int ID = 0;
        /// <summary>
        /// Zmodyfikowane pole models wraz hermetyzacją, które jest listą oraz deklaracja nowej listy
        /// </summary>
        public List<Model> Models { get; set; } = new List<Model>();
        /// <summary>
        /// Konstruktor nieparametryczny
        /// </summary>
        public Marka() { }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje nazwę marki oraz identyfikator
        /// </summary>
        public Marka(string nazwaMarki)
        {
            MarkaID = System.Threading.Interlocked.Increment(ref ID);
            NazwaMarki = nazwaMarki;
        }
    }
}