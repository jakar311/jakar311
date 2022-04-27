using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace projekt
{
    /// <summary>
    /// Klasa ZlyTelefonException dziedzicząca po klasie Exception, która sprawdza czy telefon został podany prawidłowo
    /// </summary>
    public class ZlyTelefonException:Exception
    {
        /// <summary>
        /// Konstruktor nieparametryczny wyjątku
        /// </summary>
        public ZlyTelefonException() : base() { }
        /// <summary>
        /// Konstruktor parametryczny wyjątku
        /// </summary>
        /// <param name="msg">Wiadomość tekstowa przy wywołaniu wyjątku</param>
        public ZlyTelefonException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Klasa ZlyKodPocztowyException dziedzicząca po klasie Exception, która sprawdza czy kod pocztowy został podany prawidłowo
    /// </summary>
    public class ZlyKodPocztowyException : Exception
    {
        /// <summary>
        /// Konstruktor nieparametryczny wyjątku
        /// </summary>
        public ZlyKodPocztowyException() : base() { }
        /// <summary>
        /// Konstruktor parametryczny wyjątku
        /// </summary>
        /// <param name="msg">Wiadomość tekstowa przy wywołaniu wyjątku</param>
        public ZlyKodPocztowyException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Klasa ZlyPESELException dziedzicząca po klasie Exception, która sprawdza czy pesel został podany prawidłowo
    /// </summary>
    public class ZlyPESELException : Exception
    {
        /// <summary>
        /// Konstruktor nieparametryczny wyjątku
        /// </summary>
        public ZlyPESELException() : base() { }
        /// <summary>
        /// Konstruktor parametryczny wyjątku
        /// </summary>
        /// <param name="msg">Wiadomość tekstowa przy wywołaniu wyjątku</param>
        public ZlyPESELException(string msg) : base(msg) { }
    }

    /// <summary>
    /// Klasa zawierajaca dane dotyczące osoby
    /// </summary>
    public class Osoba
    {
        /// <summary>
        /// Imie osoby
        /// </summary>
        private string imie;
        /// <summary>
        /// Nazwisko osoby
        /// </summary>
        private string nazwisko;
        /// <summary>
        /// adres 
        /// </summary>
        private string adres;
        /// <summary>
        /// Kod pocztowy
        /// </summary>
        private string kodPocztowy;
        /// <summary>
        /// telefon 
        /// </summary>
        private string telefon;
        /// <summary>
        /// email 
        /// </summary>
        private string email;
        /// <summary>
        /// PESEL 
        /// </summary>
        private string pESEL;

        /// <summary>
        /// Hermetyzacja pola telefon i sprawdzenie czy numer telefonu został wpisany poprawnie
        /// </summary>
        public string Telefon { get => telefon; set
            {
                Regex r = new Regex(@"^\d{9}$"); //Telefon musi się składać z 9 cyfr
                if (!r.IsMatch(value))
                {
                    throw new ZlyTelefonException("Niepoprawny numer telefonu");
                }
                telefon = value;
            }
        }

        /// <summary>
        /// Hermetyzacja pola kodPocztowy i sprawdzenie czy kod pocztowy został wpisany poprawnie
        /// </summary>
        public string KodPocztowy { get => kodPocztowy; set
            {
                Regex r = new Regex(@"^(\d{2})-(\d{3})$"); //Kod pocztowy musi być w postaci XX-XXX
                if (!r.IsMatch(value))
                {
                    throw new ZlyKodPocztowyException("Niepoprawny kod pocztowy");
                }
                kodPocztowy = value;
            }
        }

        /// <summary>
        /// Hermetyzacja pola PESEL i sprawdzenie czy pesel został wpisany poprawnie
        /// </summary>
        public string PESEL { get => pESEL; set
            {
                Regex r = new Regex(@"^\d{11}$"); //PESEL musi mieć 11 cyfr
                if (!r.IsMatch(value))
                {
                    throw new ZlyPESELException("Niepoprawny PESEL");
                }
                pESEL = value;
            }
        }
        /// <summary>
        /// Hermetyzacja pola email
        /// </summary>
        public string Email { get => email; set => email = value; }
        /// <summary>
        /// Hermetyzacja pola imie
        /// </summary>
        public string Imie { get => imie; set => imie = value; }
        /// <summary>
        /// Hermetyzacja pola nazwisko
        /// </summary>
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        /// <summary>
        /// Hermetyzacja pola adres
        /// </summary>
        public string Adres { get => adres; set => adres = value; }

        /// <summary>
        /// Konstruktor podstawowy
        /// </summary>
        public Osoba() { }

        /// <summary>
        /// Konstruktor parametryczny ; nadaje imie, nazwisko, pesel, adres, kod pocztowy, telefon oraz email danej osoby
        /// </summary>
        public Osoba(string imie, string nazwisko, string PESEL, string adres, string kodPocztowy, string telefon, string email) : this()
        {
            this.PESEL=PESEL;
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Adres = adres;
            this.KodPocztowy = kodPocztowy;
            this.Telefon = telefon;
            this.Email = email;
        }
        /// <summary>
        /// Metoda wypisująca Osobę w konsoli
        /// </summary>
        /// <returns>Zwraca tekst z danymi o osobie</returns>
        public override string ToString()
        {
            return $"\nImię:   {Imie}" +
                $"\nNazwisko:   {Nazwisko}" +
                $"\nPESEL:   {pESEL}" +
                $"\nAdres:   {Adres}" +
                $"\nKod pocztowy:   {KodPocztowy}" +
                $"\nTelefon:   {Telefon}" +
                $"\nEmail:   {Email}";
        }
    }
}
