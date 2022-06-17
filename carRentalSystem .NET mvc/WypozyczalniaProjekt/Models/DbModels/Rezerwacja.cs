using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca rezerwacje aut w wypożyczalni
    /// </summary>
    public class Rezerwacja
    {
        /// <summary>
        /// ID rezerwacji wraz z hermetyzacją
        /// </summary>
        [Key]
        public int RezerwacjaID { get; set; }
        /// <summary>
        /// numer rezerwacji wraz z hermetyzacją
        /// </summary>
        public string NumerRezerwacji { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        /// <summary>
        /// Data startu rezerwacji wraz z hermetyzacją
        /// </summary>
        public DateTime RezerwacjaOd { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        /// <summary>
        /// Data zakończenia rezerwacji wraz z hermetyzacją
        /// </summary>
        public DateTime RezerwacjaDo { get; set; }
        /// <summary>
        /// statyczna zmienna ID
        /// </summary>
        public static int ID = 0;
        /// <summary>
        /// Konstruktor nieparametryczny, przypisujący wartość pola RezerwacjaID oraz przypisujący numer rezerwacji
        /// </summary>
        public Rezerwacja()
        {
            NumerRezerwacji = $"NUM-{System.Threading.Interlocked.Increment(ref ID)}";
            RezerwacjaID = 0;
        }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje daty rezerwacji oraz identyfikator
        /// </summary>
        public Rezerwacja(DateTime rezerwacjaOd, DateTime rezerwacjaDo)
        {
            RezerwacjaID = System.Threading.Interlocked.Increment(ref ID);
            RezerwacjaOd = Convert.ToDateTime(rezerwacjaOd);
            RezerwacjaDo = Convert.ToDateTime(rezerwacjaDo);
        }

        public int? WynajemID { get; set; }
        /// <summary>
        /// virtualny obiekt wynajem wraz z hermetyzacją
        /// </summary>
        public Wynajem Wynajem { get; set; }
        /// <summary>
        /// Identyfikator lokalizacji wraz z hermetyzacją
        /// </summary>
        public int LokalizacjaID { get; set; }
        /// <summary>
        /// Miasto wraz z hermetyzacją
        /// </summary>
        public string Miasto { get; set; }
        /// <summary>
        /// virtualny obiekt lokalizacja wraz z hermetyzacją
        /// </summary>
        public virtual Lokalizacja Lokalizacja { get; set; }
        /// <summary>
        /// ID klienta wraz z hermetyzacją
        /// </summary>
        public int KlientID { get; set; }
        /// <summary>
        /// Nazwisko klienta wraz z hermetyzacją
        /// </summary>
        public string NazwiskoKlienta { get; set; }
        /// <summary>
        /// Imie klienta wraz z hermetyzacją
        /// </summary>
        public string ImieKlienta { get; set; }
        /// <summary>
        /// virtualny obiekt klient wraz z hermetyzacją
        /// </summary>
        public virtual Klient Klient { get; set; }
        /// <summary>
        /// Identyfikator Klienta wraz z hermetyzacją
        /// </summary>
        public int ModelID { get; set; }
        /// <summary>
        /// Nazwa modelu wraz z hermetyzacją
        /// </summary>
        public string NazwaModelu { get; set; }
        /// <summary>
        /// virtualny obiekt model wraz z hermetyzacją
        /// </summary>
        public virtual Model Model { get; set; }
    }
}