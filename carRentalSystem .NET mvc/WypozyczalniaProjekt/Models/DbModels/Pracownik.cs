using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca dane dotyczące pracownika
    /// </summary>
    public class Pracownik
    {
        /// <summary>
        /// ID pracownika wraz z hermetyzacją
        /// </summary>
        [Key]
        public int PracownikID { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Imie pracownika wraz z hermetyzacją
        /// </summary>
        public string ImiePracownika { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Nazwisko pracownika wraz z hermetyzacją
        /// </summary>
        public string NazwiskoPracownika { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Adres zamieszkania pracownika wraz z hermetyzacją
        /// </summary>
        public string AdresZamieszkaniaPracownika { get; set; }
        // <summary>
        /// Pensja pracownika wraz z hermetyzacją
        /// </summary>
        public int Pensja { get; set; }
        [Required]
        [StringLength(9)]
        /// <summary>
        /// Numer telefonu pracownika wraz z hermetyzacją
        /// </summary>
        public string NrTelefonuPracownika { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Stanowisko pracownika wraz z hermetyzacją
        /// </summary>
        public string Stanowisko { get; set; }
        /// <summary>
        /// statyczna zmienna ID z przypisaną wartością 0
        /// </summary>
        public static int ID = 0;
        /// <summary>
        /// Konstruktor nieparametryczny, przypisujący wartość pola PracownikID
        /// </summary>
        public Pracownik()
        {
            PracownikID = 0;
        }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje imie, nazwisko, adres,telefon, pensje, stanowisko oraz identyfikator pracownika
        /// </summary>
        public Pracownik(string imie_Pracownika, string nazwisko_Pracownika, string adres_Zamieszkania_Pracownika, int pensja, string nr_Telefonu_Pracownika, string stanowisko)
        {
            PracownikID = System.Threading.Interlocked.Increment(ref ID); ;
            ImiePracownika = imie_Pracownika;
            NazwiskoPracownika = nazwisko_Pracownika;
            AdresZamieszkaniaPracownika = adres_Zamieszkania_Pracownika;
            Pensja = pensja;
            NrTelefonuPracownika = nr_Telefonu_Pracownika;
            Stanowisko = stanowisko;
        }
    }
}