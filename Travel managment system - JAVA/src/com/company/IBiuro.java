package com.company;

import java.util.ArrayList;

/**
 * Interfejs IBiuro przechowujący metody dodawania, usuwania, wyszukiwania oraz sprawdzania czy dany lot jest już w biurze.
 */
public interface IBiuro {
    void DodajLot(Podroz t);
    void UsunLot(Podroz t);
    void UsunLot(String PESEL);
    boolean CzyPodrozJestWBiurzePodrozy(Podroz podroz);
    ArrayList<Podroz> WyszukajPodroze(String wylot);
}
