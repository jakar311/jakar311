using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca informacje o wynajętym aucie
    /// </summary>
    public class WynajmowaneAuto
    {
        /// <summary>
        /// ID wynajętego auta wraz z hermetyzacją
        /// </summary>
        [Key]
        [Column(Order = 1)]
        /// <summary>
        /// ID auta wraz z hermetyzacją
        /// </summary>
        public int SamochodID { get; set; }
        [Key]
        [Column(Order = 2)]
        /// <summary>
        /// ID wynajmu wraz z hermetyzacją
        /// </summary>
        public int WynajemID { get; set; }
        /// <summary>
        /// virtualny obiekt samochódt wraz z hermetyzacją
        /// </summary>
        public virtual Samochod Samochod { get; set; }
        /// <summary>
        /// virtualny obiekt wynajem wraz z hermetyzacją
        /// </summary>
        public virtual Wynajem Wynajem { get; set; }
    }
}