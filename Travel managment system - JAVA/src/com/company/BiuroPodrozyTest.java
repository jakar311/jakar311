package com.company;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

public class BiuroPodrozyTest {

    Podroz p1 = new Podroz("Jakub", "Nowak", "Łamana 34 Gdańsk", "30-697", "531290527", "Nowak@wp.pl", "01274543459", true, true, false, true, 2, 2, Podroz.klasa.biznesowa, Podroz.bilet.jednaStrona, Podroz.cel.Rzeszow_Helsinki);

    BiuroPodrozy biuroPodrozy = new BiuroPodrozy("System biura podrozy");

    public BiuroPodrozyTest() throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException {
    }

    @Test
    @DisplayName("Sprawdzenie nazwy biura podrozy")
    public void testNazwaBiuroPodrozy(){
        assertEquals("System biura podrozy", biuroPodrozy.getNazwa());
    }

    @Test
    @DisplayName("Sprawdzanie poprawnosci dodawania podrozy do biura podrozy oraz metody 'CzyPodrozJestWBiurzePodrozy'")
    public void testCzyPodrozJestWBiurzePodrozy(){
        biuroPodrozy.DodajLot(p1);

        assertTrue(biuroPodrozy.CzyPodrozJestWBiurzePodrozy(p1));
    }
}