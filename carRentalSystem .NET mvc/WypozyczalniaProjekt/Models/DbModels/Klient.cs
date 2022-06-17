using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca dane dotyczące klienta
    /// </summary>
    public class Klient
    {
        /// <summary>
        /// ID klienta wraz z hermetyzacją
        /// </summary>
        [Key]
        public int KlientID { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Imie klienta wraz z hermetyzacją
        /// </summary>
        public string ImieKlienta { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Nazwisko klienta wraz z hermetyzacją
        /// </summary>
        public string NazwiskoKlienta { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Adres zamieszkania klienta wraz z hermetyzacją
        /// </summary>
        public string AdresZamieszkaniaKlienta { get; set; }
        [Required]
        [StringLength(9)]
        /// <summary>
        /// Numer telefonu klienta wraz z hermetyzacją
        /// </summary>
        public string NrTelefonuKlienta { get; set; }
        /// <summary>
        /// statyczna zmienna ID
        /// </summary>
        public static int ID = 0;

        /// <summary>
        /// Konstruktor nieparametryczny, przypisujący wartość pola KlientID
        /// </summary>
        public Klient()
        {
            KlientID = 0;
        }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje imie, nazwisko, adres,telefon oraz identyfikator
        /// </summary>
        public Klient(string imie_Klienta, string nazwisko_Klienta, string adres_Zamieszkania_Klienta, string nr_Telefonu_Klienta)
        {
            KlientID = System.Threading.Interlocked.Increment(ref ID);
            ImieKlienta = imie_Klienta;
            NazwiskoKlienta = nazwisko_Klienta;
            AdresZamieszkaniaKlienta = adres_Zamieszkania_Klienta;
            NrTelefonuKlienta = nr_Telefonu_Klienta;
        }
    }
}