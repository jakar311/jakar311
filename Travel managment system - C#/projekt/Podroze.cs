using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    /// <summary>
    /// Enumeracja o nazwie lotniska, zawierająca różne lotniska
    /// </summary>
    [Serializable]

    public enum Lotniska {
        /// <summary>
        /// OkęcieWarszawa
        /// </summary>
        OkęcieWarszawa,
        /// <summary>
        /// BaliceKraków
        /// </summary>
        BaliceKraków,
        /// <summary>
        /// RębiechowoGdańsk
        /// </summary>
        RębiechowoGdańsk,
        /// <summary>
        /// PyrzowiceKatowice
        /// </summary>
        PyrzowiceKatowice,
        /// <summary>
        /// StrachowiceWrocław
        /// </summary>
        StrachowiceWrocław,
        /// <summary>
        /// ModlinWarszawa
        /// </summary>
        ModlinWarszawa,
        /// <summary>
        /// ŁawicaPoznań
        /// </summary>
        ŁawicaPoznań,
        /// <summary>
        /// JasionkaRzeszów
        /// </summary>
        JasionkaRzeszów,
        /// <summary>
        /// GoleniówSzczecin
        /// </summary>
        GoleniówSzczecin,
        /// <summary>
        /// ŚwidnikLublin
        /// </summary>
        ŚwidnikLublin,
        /// <summary>
        /// SzwederowoBydgoszcz
        /// </summary>
        SzwederowoBydgoszcz,
        /// <summary>
        /// LublinekŁódź
        /// </summary>
        LublinekŁódź,
        /// <summary>
        /// SzymanyOlsztyn
        /// </summary>
        SzymanyOlsztyn,
        /// <summary>
        /// BabimostZielonaGóra
        /// </summary>
        BabimostZielonaGóra,
        /// <summary>
        /// SadkówRadom
        /// </summary>
        SadkówRadom
    }

    /// <summary>
    /// Enumeracja o nazwie klasy, zawierająca możliwe do wybrania klasy lotu
    /// </summary>
    public enum Klasy {
        /// <summary>
        /// klasa ekonomiczna
        /// </summary>
        ekonomiczna,
        /// <summary>
        /// klasa biznesowa
        /// </summary>
        biznesowa,
        /// <summary>
        /// pierwsza klasa
        /// </summary>
        pierwszaKlasa
    }

    /// <summary>
    /// Enumeracja o nazwie bilety, zawierająca dwie możliwości biletu ; w jedną stronę lub w dwie strony
    /// </summary>
    public enum Bilety {
        /// <summary>
        /// bilet w jedną strone
        /// </summary>
        jednaStrona,
        /// <summary>
        /// bilet w obie strony
        /// </summary>
        powrot
    }

    /// <summary>
    /// Enumeracja o nazwie cele, zawierająca różne miejsca docelowe dla wybranej podróży
    /// </summary>
    public enum cele {
        /// <summary>
        /// Włochy_Kreta
        /// </summary>
        Włochy_Kreta,
        /// <summary>
        /// Grecja_Zakynthos
        /// </summary>
        Grecja_Zakynthos,
        /// <summary>
        /// Tunezja_Tunisie
        /// </summary>
        Tunezja_Tunisie,
        /// <summary>
        /// Wyspy_Zielonego_Przylądka_Praia
        /// </summary>
        Wyspy_Zielonego_Przylądka_Praia,
        /// <summary>
        /// Portugalia_Maderze
        /// </summary>
        Portugalia_Maderze,
        /// <summary>
        /// Egipt_Kairze
        /// </summary>
        Egipt_Kairze,
        /// <summary>
        /// Gruzja_Tbilisi
        /// </summary>
        Gruzja_Tbilisi,
        /// <summary>
        /// Tajlandia_Bangkoku
        /// </summary>
        Tajlandia_Bangkoku,
        /// <summary>
        /// Bułgaria_Sofia
        /// </summary>
        Bułgaria_Sofia
    }

    /// <summary>
    /// Klasa PESELComparator implementująca interfejs Comparer
    /// </summary>
    class PESELComparator : Comparer<Podroze>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x">pierwsza podróż do porównania</param>
        /// <param name="y">druga podróż do porównania</param>
        /// <returns>0 lub 1</returns>
        public override int Compare(Podroze x, Podroze y)
        {
            return x.PESEL.CompareTo(y.PESEL);
        }
    }

    /// <summary>
    /// Klasa Podroze przechowywująca informację o osobach, kierunku podróży i dodatkowych usługach.
    /// </summary>
    public class Podroze:Osoba,ICloneable,IComparable<Podroze>,IEquatable<Podroze>
    {
        /// <summary>
        /// Identyfikator (klucz) o nazwe BiuroID
        /// </summary>
        [Key]
        public int PodrozeId { get; set; }

        /// <summary>
        /// Identyfikator o nazwe BiuroID z klasy BiuroPodrozy
        /// </summary>
        public int BiuroId { get; set; }

        /// <summary>
        /// Zmodyfikowane pole BiuroPod
        /// </summary>
        public virtual BiuroPodrozy BiuroPod { get; set; }
        


        /// <summary>
        /// Numer
        /// </summary>
        private static int numer;

        /// <summary>
        /// Sugnatura
        /// </summary>
        private string sygnatura;

        /// <summary>
        /// Specjalne potrzeby
        /// </summary>
        private bool specjalnePotrzeby;

        /// <summary>
        /// Ubezpieczenie
        /// </summary>
        private bool ubezpieczenie;

        /// <summary>
        /// Dodatkowy bagaż
        /// </summary>
        private bool dodatkowyBagaz;

        /// <summary>
        /// Przeleciane kilometry
        /// </summary>
        private bool przelecianeKilometry;

        /// <summary>
        /// Wylot
        /// </summary>
        private Lotniska wylot;

        /// <summary>
        /// Klasa
        /// </summary>
        private Klasy klasa;

        /// <summary>
        /// Bilet
        /// </summary>
        private Bilety bilet;

        /// <summary>
        /// Ilosc dzieci
        /// </summary>
        private int iloscDzieci;

        /// <summary>
        /// Cel podróży
        /// </summary>
        private cele celPodrozy;

        /// <summary>
        /// Ilosc
        /// </summary>
        private int ilosc;

        /// <summary>
        /// Stopa podatku
        /// </summary>
        static double stopa_podatku;


        /// <summary>
        /// Hermetyzacja pola numer
        /// </summary>
        public static int Numer { get => numer; set => numer = value; }
        /// <summary>
        /// Hermetyzacja pola sygnatura
        /// </summary>
        public string Sygnatura { get => sygnatura; set => sygnatura = value; }
        /// <summary>
        /// Hermetyzacja pola specjalnePotrzeby
        /// </summary>
        public bool SpecjalnePotrzeby { get => specjalnePotrzeby; set => specjalnePotrzeby = value; }
        /// <summary>
        /// Hermetyzacja pola ubezpieczenie
        /// </summary>
        public bool Ubezpieczenie { get => ubezpieczenie; set => ubezpieczenie = value; }
        /// <summary>
        /// Hermetyzacja pola dodatkowyBagaz
        /// </summary>
        public bool DodatkowyBagaz { get => dodatkowyBagaz; set => dodatkowyBagaz = value; }
        /// <summary>
        /// Hermetyzacja pola przelecianeKilometry
        /// </summary>
        public bool PrzelecianeKilometry { get => przelecianeKilometry; set => przelecianeKilometry = value; }
        /// <summary>
        /// Hermetyzacja pola wylot
        /// </summary>
        public Lotniska Wylot { get => wylot; set => wylot = value; }
        /// <summary>
        /// Hermetyzacja pola klasa
        /// </summary>
        public Klasy Klasa { get => klasa; set => klasa = value; }
        /// <summary>
        /// Hermetyzacja pola bilet
        /// </summary>
        public Bilety Bilet { get => bilet; set => bilet = value; }
        /// <summary>
        /// Hermetyzacja pola iloscDzieci
        /// </summary>
        public int IloscDzieci { get => iloscDzieci; set => iloscDzieci = value; }
        /// <summary>
        /// Hermetyzacja pola celPodrozy
        /// </summary>
        public cele CelPodrozy { get => celPodrozy; set => celPodrozy = value; }
        /// <summary>
        /// Hermetyzacja pola ilosc
        /// </summary>
        public int Ilosc { get => ilosc; set => ilosc = value; }

        /// <summary>
        /// Konstruktor satatyczny ustawiający wartosci pol ; stopa_podatku oraz numer
        /// </summary>
        static Podroze() { 
            stopa_podatku = 0.15;
            Numer = 0;
        }

        /// <summary>
        /// Kontstruktor nieparametryczny ustawiający pole sygnatura
        /// </summary>
        public Podroze() {
            Sygnatura = $"SYG-{++Numer:00000}";
        }

        /// <summary>
        /// Konstruktor parametryczny ustawiajacy poszczególne pola
        /// </summary>
        /// <param name="imie"></param>
        /// <param name="nazwisko"></param>
        /// <param name="PESEL"></param>
        /// <param name="adres"></param>
        /// <param name="kodPocztowy"></param>
        /// <param name="telefon"></param>
        /// <param name="email"></param>
        /// <param name="wylot"></param>
        /// <param name="celPodrozy"></param>
        /// <param name="ilosc"></param>
        /// <param name="specjalnePotrzeby"></param>
        /// <param name="ubezpieczenie"></param>
        /// <param name="dodatkowyBagaz"></param>
        /// <param name="przelecianeKilometry"></param>
        /// <param name="klasa"></param>
        /// <param name="bilet"></param>
        /// <param name="iloscDzieci"></param>
        public Podroze(string imie, string nazwisko,string PESEL, string adres, string kodPocztowy, string telefon, string email, Lotniska wylot, cele celPodrozy, int ilosc,bool specjalnePotrzeby, bool ubezpieczenie, bool dodatkowyBagaz, bool przelecianeKilometry, Klasy klasa,Bilety bilet,int iloscDzieci) :base(imie,nazwisko,PESEL,adres,kodPocztowy,telefon,email)
        {
            Sygnatura = $"SYG-{++Numer:00000}";
            this.Wylot = wylot; 
            this.CelPodrozy = celPodrozy;
            this.Ilosc = ilosc;
            this.SpecjalnePotrzeby = specjalnePotrzeby;
            this.Ubezpieczenie = ubezpieczenie;
            this.DodatkowyBagaz = dodatkowyBagaz;
            this.PrzelecianeKilometry = przelecianeKilometry;
            this.Klasa = klasa;
            this.Bilet = bilet;
            this.IloscDzieci = iloscDzieci;
        }
        
        //Podatek
        /// <summary>
        /// Metoda obliczająca podatek na podstawie podanej kwoty
        /// </summary>
        /// <param name="Kwota"></param>
        /// <returns>Podatek</returns>
        public double PoliczPodatek(double Kwota)
        {
            double podatek = Kwota * stopa_podatku;
            return podatek;
        }
        
        //Suma czesciowa (bez podatku)
        /// <summary>
        /// Metoda licząca sumę częściową
        /// </summary>
        /// <returns>suma częściowa</returns>
        public double PoliczSumeCzesciowa()
        {
            Ceny c = new Ceny();
            double cenaKoncowa = 0;
            switch (CelPodrozy)
            {
                case cele.Włochy_Kreta:
                    cenaKoncowa += c.Włochy_Kreta;
                    break;
                case cele.Grecja_Zakynthos:
                    cenaKoncowa += c.Grecja_Zakynthos;
                    break;
                case cele.Tunezja_Tunisie:
                    cenaKoncowa += c.Tunezja_Tunisie;
                    break;
                case cele.Wyspy_Zielonego_Przylądka_Praia:
                    cenaKoncowa += c.Wyspy_Zielonego_Przylądka_Praia;
                    break;
                case cele.Portugalia_Maderze:
                    cenaKoncowa += c.Portugalia_Maderze;
                    break;
                case cele.Egipt_Kairze:
                    cenaKoncowa += c.Egipt_Kairze;
                    break;
                case cele.Gruzja_Tbilisi:
                    cenaKoncowa += c.Gruzja_Tbilisi;
                    break;
                case cele.Tajlandia_Bangkoku:
                    cenaKoncowa += c.Tajlandia_Bangkoku;
                    break;
                case cele.Bułgaria_Sofia:
                    cenaKoncowa += c.Bułgaria_Sofia;
                    break;
            }

            cenaKoncowa += Ilosc * c.jedna_osoba + IloscDzieci * c.dziecko;

            if (SpecjalnePotrzeby == true)
            {
                cenaKoncowa += c.specjalnePotrzeby;
            }
            if (Ubezpieczenie == true)
            {
                cenaKoncowa += c.ubezpieczenie;
            }
            if (DodatkowyBagaz == true)
            {
                cenaKoncowa += c.dodatkowy_bagaż;
            }
            if (PrzelecianeKilometry == true)
            {
                cenaKoncowa += c.kilometry;
            }
            switch (Klasa)
            {
                case Klasy.biznesowa:
                    cenaKoncowa += c.biznesowa;
                    break;
                case Klasy.pierwszaKlasa:
                    cenaKoncowa += c.pierwsza_klasa;
                    break;
            }
            switch (Bilet)
            {
                case Bilety.powrot:
                    if (Klasa == Klasy.ekonomiczna)
                    {
                        cenaKoncowa += c.ekonomiczna;
                    }
                    else if (Klasa == Klasy.biznesowa)
                    {
                        cenaKoncowa += c.biznesowa;
                    }
                    else if (Klasa == Klasy.biznesowa)
                    {
                        cenaKoncowa += c.pierwsza_klasa;
                    }
                    break;
            }
            return cenaKoncowa;

        }
       
        /// <summary>
        /// Metoda dodająca całkowity koszt ; sumę częściową + podatek od tej sumy częściowej
        /// </summary>
        /// <returns></returns>
        public double PoliczKoszt()
        {
            return PoliczSumeCzesciowa() + PoliczPodatek(PoliczSumeCzesciowa());
        }
        
        /// <summary>
        /// Metoda tworząca płytką kopię 
        /// </summary>
        /// <returns>Płytka kopia</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
        /// <summary>
        /// Metoda porównująca sygnaturę lub w dalszej kolejności nazwisko
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>int</returns>
        public int CompareTo(Podroze obj)
        {
            Podroze c = (Podroze)obj;
            if (c.Sygnatura != this.Sygnatura)
            {
                return c.Sygnatura.CompareTo(this.Sygnatura);
            }
            else
            {
                return c.Nazwisko.CompareTo(this.Nazwisko);
            }
        }
        

        /// <summary>
        /// Motoda powrównująca podróże po ich sygnaturach
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Podroze other)
        {
            if (string.IsNullOrEmpty(Sygnatura) || string.IsNullOrEmpty(other.Sygnatura)) { return false; }
            return this.Sygnatura.Equals(other.Sygnatura);
        }
        
        /// <summary>
        /// Metoda wypisująca numer, miejsce wylotu, cel docelowy i inne informacje o locie
        /// </summary>
        /// <returns>Tekst z informacjami o podróży</returns>
        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"\nNumer:   {Sygnatura}" +
                $"\nWylot z:   {Wylot}" +
                $"\nCel podrozy:   {CelPodrozy}" +
                $"\nIlosc osob doroslych:   {Ilosc}, Ilosc dzieci: {IloscDzieci}, Specjalne potrzeby: {SpecjalnePotrzeby}, Ubezpieczenie: {Ubezpieczenie}, Dodatkowy bagaz: {DodatkowyBagaz}" + 
                $"\nZnizka za przeleciane kilometry: {PrzelecianeKilometry}, Klasa: {Klasa}, Rodzaj biletu: {Bilet}, Cena: {PoliczKoszt():C2}";
        }
    }
}
