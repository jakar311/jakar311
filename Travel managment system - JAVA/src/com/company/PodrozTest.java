package com.company;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class PodrozTest {

    Podroz podroz = new Podroz("Jakub", "Nowak", "Łamana 34 Gdańsk", "30-697", "531290527", "Nowak@wp.pl", "01274543459", true, true, false, true, 2, 2, Podroz.klasa.biznesowa, Podroz.bilet.jednaStrona, Podroz.cel.Rzeszow_Helsinki);

    public PodrozTest() throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException {
    }

    @Test
    @DisplayName("Sprawdzanie czy poprawnie przypisano imię")
    public void testSygnatura() throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException {
        Podroz p1 = new Podroz("Miłosz", "Kowalski", "Długa 12 Poznań", "20-619", "531298727", "Kowalski@wp.pl", "01274673451", false, false, true, false, 0, 1, Podroz.klasa.pierwszaKlasa, Podroz.bilet.jednaStrona, Podroz.cel.Krakow_Gdansk);
        assertEquals("Miłosz", p1.imie);
    }

    @Test
    @DisplayName("Sprawdzenie czy metoda PoliczPodatek działa poprawnie na przykladzie kwoty - 500zl")
    public void testPoliczPodatek() {

        double kwota = 500.00;
        double result = Podroz.PoliczPodatek(kwota);

        assertEquals(75.00, result);
    }

    @Test
    @DisplayName("Sprawdzanie czy metoda PoliczSumeCzesciowa dziala poprawnie na przykladzie danych z podrozy podroz")
    public void testPoliczSumeCzesciowa(){
        assertEquals(3662.4, podroz.PoliczSumeCzesciowa());
    }

    @Test
    @DisplayName("Sprawdzanie czy metoda PoliczKoszt dziala poprawnie na przykladzie danych z podrozy podroz")
    public void testPoliczKoszt(){
        assertEquals(4211.76, podroz.PoliczKoszt());
    }
}