package com.company;

import java.util.Comparator;

/**
 * Klasa PESELComparator implementująca interfejs Comparator<Podroz>.
 */
public class PESELComparator implements Comparator<Podroz> {
    /**
     * Metoda porównująca podróże po peselu.
     * @param x pierwsza podróż do porównania.
     * @param y druga podróż do porównania
     * @return porównana podróż.
     */
    @Override
    public int compare(Podroz x, Podroz y)
    {
        return x.pesel.compareTo(y.pesel);
    }
}
