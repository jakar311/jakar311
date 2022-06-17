using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WypozyczalniaProjekt.Models.DbModels
{
    /// <summary>
    /// Klasa zawierajaca informacje o wynajęciu aut z wypożyczalni
    /// </summary>
    public class Wynajem
    {
        /// <summary>
        /// ID wynajmu wraz z hermetyzacją
        /// </summary>
        [Key]
        public int WynajemID { get; set; }
        /// <summary>
        /// koszt wynajmu wraz z hermetyzacją
        /// </summary>
        public float Koszt { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        /// <summary>
        /// Data startu wynajmu wraz z hermetyzacją
        /// </summary>
        public DateTime WynajemOd { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        /// <summary>
        /// Data zakończenia wynajmu wraz z hermetyzacją
        /// </summary>
        public DateTime? WynajemDo { get; set; }
        /// <summary>
        /// statyczna zmienna ID
        /// </summary>
        public static int ID = 0;
        /// <summary>
        /// ID rezerwacji wraz z hermetyzacją; może przyjąć wartość null
        /// </summary>
        public int? RezerwacjaID { get; set; }
        [Required]
        /// <summary>
        /// virtualny obiekt Rezerwacja wraz z hermetyzacją
        /// </summary>
        public Rezerwacja Rezerwacja { get; set; }
        /// <summary>
        /// Konstruktor nieparametryczny
        /// </summary>
        public Wynajem()
        {
        }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje daty wynajmu, koszt  oraz identyfikator
        /// </summary>
        public Wynajem(float koszt, DateTime wynajemOd, DateTime wynajemDo)
        {
            WynajemID = System.Threading.Interlocked.Increment(ref ID);
            Koszt = koszt;
            WynajemOd = wynajemOd;
            WynajemDo = wynajemDo;
        }
        /// <summary>
        /// ID klienta wraz z hermetyzacją
        /// </summary>
        public int KlientID { get; set; }
        /// <summary>
        /// virtualny obiekt klient wraz z hermetyzacją
        /// </summary>
        public virtual Klient Klient { get; set; }
        /// <summary>
        /// Nazwisko klienta wraz z hermetyzacją
        /// </summary>
        public string NazwiskoKlienta { get; set; }
        /// <summary>
        /// ID pracownika wraz z hermetyzacją
        /// </summary>
        public int PracownikID { get; set; }
        /// <summary>
        /// Nazwisko pracownikawraz z hermetyzacją
        /// </summary>
        public string NazwiskoPracownika { get; set; }
        /// <summary>
        /// virtualny obiekt pracownik wraz z hermetyzacją
        /// </summary>
        public virtual Pracownik Pracownik { get; set; }
        /// <summary>
        /// virtualny Interfejs wynajmowane auta wraz z hermetyzacją
        /// </summary>
        public virtual ICollection<WynajmowaneAuto> WynajmowaneAuta { get; set; }
    }

    //public class RezerwacjaIDValidator : AbstractValidator<Wynajem>
    //{
    //    public RezerwacjaIDValidator()
    //    {
    //        RuleFor(x => x.RezerwacjaID).Must(BeUniqueRezerwacjaID).WithMessage("Url already exists");
    //    }

    //    private bool BeUniqueRezerwacjaID(int rezerwacjaID)
    //    {
    //        return new ApplicationDbContext().Wynajem.FirstOrDefault(x => x.RezerwacjaID == rezerwacjaID) == null;
    //    }
    //}
}