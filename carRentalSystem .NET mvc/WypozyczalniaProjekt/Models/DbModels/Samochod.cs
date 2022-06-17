using FluentValidation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.SqlServer.Management.HadrModel;
using ServiceStack.FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ValidatorAttribute = ServiceStack.FluentValidation.Attributes.ValidatorAttribute;

namespace WypozyczalniaProjekt.Models.DbModels
{
    //[Validator(typeof(NumerRejestracyjnyValidator))]
    /// <summary>
    /// Klasa zawierajacainformacje o autach w wypożyczalni
    /// </summary>
    public class Samochod
    {
        /// <summary>
        /// ID auta wraz z hermetyzacją
        /// </summary>
        [Key]
        public int SamochodID { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Numer rejestracyjny auta wraz z hermetyzacją
        /// </summary>
        public string NumerRejestracyjny { get; set; }
        /// <summary>
        /// Aktualny przebieg auta wraz z hermetyzacją
        /// </summary>
        public int Przebieg { get; set; }
        [Required]
        [StringLength(50)]
        /// <summary>
        /// Numer VIN auta wraz z hermetyzacją
        /// </summary>
        public string Vin { get; set; }
        /// <summary>
        /// Statyczna zmienna ID i przypisana do niej wartość 0
        /// </summary>
        public static int ID = 0;
        /// <summary>
        /// Wywołanie klasy random do gerowania numeru rejestracyjnego
        /// </summary>
        private static Random random = new Random();
        /// <summary>
        /// Metoda RandomString genreująca numer rejestracyjny
        /// </summary>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        /// <summary>
        /// Konstruktor nieparametryczny, przypisujący wartość pola SamochodID
        /// </summary>
        public Samochod()
        {
            SamochodID = 0;
        }
        /// <summary>
        /// Konstruktor parametryczny ; nadaje numer rejestracyjny, przebieg, VIN oraz identyfikator
        /// </summary>
        public Samochod(int przebieg, string vin)
        {
            SamochodID = System.Threading.Interlocked.Increment(ref ID);
            NumerRejestracyjny = RandomString(7);
            Przebieg = przebieg;
            Vin = vin;
        }
        /// <summary>
        /// Identyfikator Klienta wraz z hermetyzacją
        /// </summary>
        public int ModelID { get; set; }
        /// <summary>
        /// virtualny obiekt model wraz z hermetyzacją
        /// </summary>
        public virtual Model Model { get; set; }
        /// <summary>
        /// Nazwa modelu wraz z hermetyzacją
        /// </summary>
        public string NazwaModelu { get; set; }
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
        /// virtualny Interfejs wynajmowane auta wraz z hermetyzacją
        /// </summary>
        public virtual ICollection<WynajmowaneAuto> WynajmowaneAuta { get; set; }
    }

    //    public class NumerRejestracyjnyValidator : AbstractValidator<Samochod>
    //    {
    //        public NumerRejestracyjnyValidator()
    //        {
    //            RuleFor(x => x.NumerRejestracyjny).Must(BeUniqueNumerRejestracyjny).WithMessage("Url already exists");
    //        }

    //        private bool BeUniqueNumerRejestracyjny(string numerRejestracyjny)
    //        {
    //            return new ApplicationDbContext().Samochod.FirstOrDefault(x => x.NumerRejestracyjny == numerRejestracyjny) == null;
    //        }
    //    }
}