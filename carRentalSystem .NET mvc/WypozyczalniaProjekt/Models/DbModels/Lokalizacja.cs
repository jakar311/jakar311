using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca dane dotyczące lokalizacji wypożyczalni
    /// </summary>
    public class Lokalizacja
    {
        /// <summary>
        /// ID lokalizacji wraz z hermetyzacją
        /// </summary>
        [Key]
        public int LokalizacjaID { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Adres zwypożyczalni wraz z hermetyzacją
        /// </summary>
        public string Adres { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Miasto wraz z hermetyzacją
        /// </summary>
        public string Miasto { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Województwo wraz z hermetyzacją
        /// </summary>
        public string Wojewodztwo { get; set; }
        public static int ID = 0;
        /// <summary>
        /// Zmodyfikowane pole rezerwacje, które jest listą oraz deklaracja nowej listy
        /// </summary>
        public List<Rezerwacja> Rezerwacje { get; set; } = new List<Rezerwacja>();
        /// <summary>
        /// Konstruktor nieparametryczny
        /// </summary>
        public Lokalizacja()
        {
        }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje adres, miasto, województwo oraz identyfikator
        /// </summary>
        public Lokalizacja(string adres, string miasto, string wojewodztwo)
        {
            LokalizacjaID = System.Threading.Interlocked.Increment(ref ID);
            Adres = adres;
            Miasto = miasto;
            Wojewodztwo = wojewodztwo;
        }
    }
}