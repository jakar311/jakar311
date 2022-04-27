using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    /// <summary>
    /// Klasa Ceny, przechowująca ceny podróży, biletów oraz dodatkowych usług
    /// </summary>
    public class Ceny
    {     
        /// <summary>
        /// Pole przechowujące cenę dla lotu na Kretę
        /// </summary>
        public double Włochy_Kreta;

        /// <summary>
        /// Pole przechowujące cenę dla lotu na Zakynthos
        /// </summary>
        public double Grecja_Zakynthos;

        /// <summary>
        /// Pole przechowujące cenę dla lotu do Tunezji
        /// </summary>
        public double Tunezja_Tunisie;

        /// <summary>
        /// Pole przechowujące cenę dla lotu do Praii
        /// </summary>
        public double Wyspy_Zielonego_Przylądka_Praia;

        /// <summary>
        /// Pole przechowujące cenę dla lotu na Madere
        /// </summary>
        public double Portugalia_Maderze;

        /// <summary>
        /// Pole przechowujące cenę dla lotu do Kairu
        /// </summary>
        public double Egipt_Kairze;

        /// <summary>
        /// Pole przechowujące cenę dla lotu do Tibilisi
        /// </summary>
        public double Gruzja_Tbilisi;

        /// <summary>
        /// Pole przechowujące cenę dla lotu do Bangkoku
        /// </summary>
        public double Tajlandia_Bangkoku;

        /// <summary>
        /// Pole przechowujące cenę dla lotu do Sofii
        /// </summary>
        public double Bułgaria_Sofia;

        //ilosc osob
        /// <summary>
        /// Pole przechowujące cenę lotu dla dorosłej osoby
        /// </summary>
        public double jedna_osoba;

        /// <summary>
        /// Pole przechowujące cenę lotu dla dziecka
        /// </summary>
        public double dziecko;

        //klasa
        /// <summary>
        /// Pole przechowujące cenę w klasie ekonomicznej
        /// </summary>
        public double ekonomiczna;

        /// <summary>
        /// Pole przechowujące cenę w klasie biznesowe
        /// </summary>
        public double biznesowa;

        /// <summary>
        /// Pole przechowujące cenę w pierwszej klasie
        /// </summary>
        public double pierwsza_klasa;

        //dodatkowe uslugi
        /// <summary>
        /// Pole przechowujące cenę za specjalne potrzeby
        /// </summary>
        public double specjalnePotrzeby;

        /// <summary>
        /// Pole przechowujące zniżkę za kilometry
        /// </summary>
        public double kilometry;

        /// <summary>
        /// Pole przechowujące cenę za ubezpieczenie
        /// </summary>
        public double ubezpieczenie;

        /// <summary>
        /// Pole przechowujące cenę za dodatkowy bagaż
        /// </summary>
        public double dodatkowy_bagaż ;
       

        /// <summary>
        /// Konstruktor nieparametryczny przypisujący ceny poszczególnych usług
        /// </summary>
        public Ceny()
        {
            Włochy_Kreta = 2500;
            Grecja_Zakynthos = 3000;
            Tunezja_Tunisie = 2800;
            Wyspy_Zielonego_Przylądka_Praia = 3500;
            Portugalia_Maderze = 2100;
            Egipt_Kairze = 2000;
            Gruzja_Tbilisi = 2000;
            Tajlandia_Bangkoku = 4000;
            Bułgaria_Sofia = 2300;

            jedna_osoba = 150;
            dziecko = 50;

            ekonomiczna = 100;
            biznesowa = 200;
            pierwsza_klasa = 400;

            kilometry = -250;
            ubezpieczenie = 62.4;
            dodatkowy_bagaż = 25.9;
            specjalnePotrzeby = 50;
        }

    }
}
