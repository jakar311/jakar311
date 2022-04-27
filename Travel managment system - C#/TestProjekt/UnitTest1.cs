using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using projekt;

namespace TestProjekt
{
    /// <summary>
    /// Klasa z metodami testującymi
    /// </summary>
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Test dla nazwy
        /// </summary>
        [TestMethod]
        public void TestNazwy()
        {
            BiuroPodrozy b = new BiuroPodrozy("Biuro");
            Assert.AreEqual("Biuro", b.Nazwa);
        }

        /// <summary>
        /// test dla numeru
        /// </summary>
        [TestMethod]
        public void TestNumer()
        {
            Podroze p = new Podroze("Błażej", "Kowalski", "01234544469", "Długa 7 Rzeszów", "33-627", "546296577", "Kowalski@wp.pl", Lotniska.BaliceKraków, cele.Tunezja_Tunisie, 2, false, true, false, false, Klasy.ekonomiczna, Bilety.jednaStrona, 1);

            Assert.AreEqual(1, Podroze.Numer);
        }

        /// <summary>
        /// test porównywania dwóch podróży
        /// </summary>
        [TestMethod]
        public void TestPorownanie()
        {
            Podroze p = new Podroze("Adam", "Kowalski", "01234544469", "Długa 7 Rzeszów", "33-627", "546296577", "Kowalski@wp.pl", Lotniska.BaliceKraków, cele.Tunezja_Tunisie, 2, false, true, false, false, Klasy.ekonomiczna, Bilety.jednaStrona, 1);
            Podroze p2 = new Podroze("Jerzy", "Kowalski", "01234544469", "Długa 7 Rzeszów", "33-627", "546296577", "Kowalski@wp.pl", Lotniska.BaliceKraków, cele.Tunezja_Tunisie, 2, false, true, false, false, Klasy.ekonomiczna, Bilety.jednaStrona, 1);
            Assert.AreEqual(1, p.CompareTo(p2));
        }

        /// <summary>
        /// Test działania clasy, która sprawdza czy pesel zostal wpisany poprawnie
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ZlyPESELException))]
        public void TestPESEL()
        {
            Podroze p = new Podroze("Andrzej", "Nowak", "01269", "Długa 7 Rzeszów", "33-627", "565774567", "Kowalski@wp.pl", Lotniska.BaliceKraków, cele.Tunezja_Tunisie, 2, false, true, false, false, Klasy.ekonomiczna, Bilety.jednaStrona, 1);
        }

        /// <summary>
        /// Test metody szukającej podróży
        /// </summary>
        [TestMethod]
        public void TestSzukaniaPodrozy()
        {
            Podroze p = new Podroze("Andrzej", "Nowak", "01272893645", "Długa 7 Rzeszów", "33-627", "565774567", "Kowalski@wp.pl", Lotniska.BaliceKraków, cele.Tunezja_Tunisie, 2, false, true, false, false, Klasy.ekonomiczna, Bilety.jednaStrona, 1);
            BiuroPodrozy b = new BiuroPodrozy("Biuro");
            b.DodajLot(p);

            Assert.AreEqual(p, b.WyszukajPodroze("BaliceKraków")[0]);
        }
    }
}
