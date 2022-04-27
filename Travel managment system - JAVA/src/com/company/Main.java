package com.company;

import java.sql.*;

public class Main {
            
    public static void main(String[] args) throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException, SQLException {
            Podroz l1 = new Podroz("Jakub", "Nowak", "Lamana 34 Gdansk", "30-697", "531290527", "Nowak@wp.pl", "01274543459", true, true, false, true, 2, 2, Podroz.klasa.biznesowa, Podroz.bilet.jednaStrona, Podroz.cel.Rzeszow_Helsinki);
            Podroz l2 = new Podroz("Milosz", "Kowalski", "Dluga 12 Poznan", "20-619", "531298727", "Kowalski@wp.pl", "01274673451", false, false, true, false, 0, 1, Podroz.klasa.pierwszaKlasa, Podroz.bilet.jednaStrona, Podroz.cel.Krakow_Gdansk);
            Podroz l3 = new Podroz("Oskar", "Nowaczynski", "Szeroka 1 Wachock", "30-627", "131290527", "Nowaczynski@wp.pl", "01274543452", true, true, false, true, 5, 2, Podroz.klasa.biznesowa, Podroz.bilet.powrot, Podroz.cel.Krakow_Tunezja);
            Podroz l4 = new Podroz("Mateusz", "Korta", "Osmiokatna 67 Kolobrzeg", "20-693", "231298727", "Korta@wp.pl", "01274673453", false, true, false, true, 4, 5, Podroz.klasa.pierwszaKlasa, Podroz.bilet.jednaStrona, Podroz.cel.Rzeszow_Helsinki);
            Podroz l5 = new Podroz("Kamil", "Knap", "Prostokatna 55 Bydgoszcz", "30-694", "331290527", "Knap@wp.pl", "01274543454", true, false, false, false, 3, 2, Podroz.klasa.biznesowa, Podroz.bilet.powrot, Podroz.cel.Warszawa_NowyYork);

            BiuroPodrozy biuroPodrozy = new BiuroPodrozy("System biura podrozy");
            biuroPodrozy.DodajLot(l1);
            biuroPodrozy.DodajLot(l2);
            biuroPodrozy.DodajLot(l3);
            biuroPodrozy.DodajLot(l4);
            biuroPodrozy.DodajLot(l5);

            //Usuwanie lotu i dodawanie z powrotem
            biuroPodrozy.UsunLot(l5);
            System.out.println(biuroPodrozy);
            biuroPodrozy.DodajLot(l5);

            biuroPodrozy.UsunLot("01274543459");
            System.out.println(biuroPodrozy);
            biuroPodrozy.DodajLot(l1);

            //Wyszukiwanie podróży po lotnisku
            System.out.println(biuroPodrozy.WyszukajPodroze("Krakow"));

            //Sortowanie
            biuroPodrozy.Sortuj();
            System.out.println(biuroPodrozy);

            //Sortuj po PESELU
            biuroPodrozy.SortujPoPESEL();
            System.out.println(biuroPodrozy);

            //Zapisywanie i odczytywanie pliku BIN
            biuroPodrozy.zapisz("biuroPodrozy.bin");
            BiuroPodrozy b2 = BiuroPodrozy.odczytaj("biuroPodrozy.bin");
            System.out.println(b2);

            //Czy podroz jest dodana do biura podrozy
            System.out.println(biuroPodrozy.CzyPodrozJestWBiurzePodrozy(l2));

            //Compare
            System.out.println(l1.compareTo(l2));

            //Klonowanie
            BiuroPodrozy b3 = biuroPodrozy.clone();
            System.out.println(b3);

            biuroPodrozy.ZapiszDoBazy(biuroPodrozy);
            BiuroPodrozy biurko = BiuroPodrozy.OdczytajZBazy();
            System.out.println(biurko);
        }
}
