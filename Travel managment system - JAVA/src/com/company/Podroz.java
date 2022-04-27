package com.company;

import java.io.Serializable;
import java.text.NumberFormat;
import java.util.Objects;


/**
 * Klasa Podroz przechowywująca informację o osobach, kierunku podróży i dodatkowych usługach.
 */
public class Podroz extends Osoba implements Cloneable,Comparable<Podroz>, Serializable {

    /**
     *  Enumeracja o nazwie klasa, zawierająca możliwe do wybrania klasy lotu.
     */
    public enum klasa{ekonomiczna, biznesowa, pierwszaKlasa}

    /**
     *  Enumeracja o nazwie bilet, zawierająca możliwość wybrania biletu w jedną lub dwie strony.
     */
    public enum bilet{jednaStrona, powrot}

    /**
     * Enumeracja o nazwie cele, zawierająca różne miejsca docelowe dla wybranej podróży.
     */
    public enum cel{Krakow_Tunezja, Rzeszow_Helsinki, Krakow_Gdansk, Warszawa_NowyYork, Wroclaw_Japonia}

    /**
     * Deklaracja zmiennych.
     */
    static int numer = 0;
    String sygnatura;
    boolean specjalnePotrzeby;
    boolean ubezpieczenie;
    boolean dodatkowyBagaz;
    boolean przelecianeKilometry;
    int iloscDzieci;
    int iloscDoroslych;
    static double stopaPodatku = 0.15;
    klasa _klasa;
    bilet _bilet;
    cel _cel;

    /**
     * Konstruktor parametryczny dla klasy Podroz nadający wartości zmiennych, wyrzucający wyjątki w przypadku niepoprawnie wpisanych danych.
     * Dodatkowo adaje właściwy format sygnaturze.
     * @param imie nadaje imię.
     * @param nazwisko nadaje nazwisko.
     * @param adres nadaje adres.
     * @param kodPocztowy nadaje kodPocztowy.
     * @param telefon nadaje telefon.
     * @param email nadaje email.
     * @param pesel nadaje pesel.
     * @param specjalnePotrzeby nadaje informacje o specjalnych potrzebach.
     * @param ubezpieczenie nadaje informacje o ubezpieczeniu.
     * @param dodatkowyBagaz nadaje informacje o dodatkowym bagażu.
     * @param przelecianeKilometry nadaje informację o przelecianych kilometrach.
     * @param iloscDzieci nadaje informację i liczbie dzieci.
     * @param iloscDoroslych nadaje informację i liczbie dorosłych.
     * @param _klasa nadaje informację o wybranej klasie.
     * @param _bilet nadaje informację o rodzaju bietu.
     * @param _cel nadaje informację o celu podróży.
     * @throws ZlyKodPocztowyException wyrzuca wyjątek.
     * @throws ZlyTelefonException wyrzuca wyjątek.
     * @throws ZlyPeselException wyrzuca wyjątek.
     */
    public Podroz(String imie, String nazwisko, String adres, String kodPocztowy, String telefon, String email, String pesel, boolean specjalnePotrzeby, boolean ubezpieczenie, boolean dodatkowyBagaz, boolean przelecianeKilometry, int iloscDzieci, int iloscDoroslych, klasa _klasa, bilet _bilet, cel _cel) throws ZlyKodPocztowyException, ZlyTelefonException, ZlyPeselException {
        super(imie, nazwisko, adres, kodPocztowy, telefon, email, pesel);
        sygnatura = "SYG-" + String.format("%05d", ++numer);
        this.specjalnePotrzeby = specjalnePotrzeby;
        this.ubezpieczenie = ubezpieczenie;
        this.dodatkowyBagaz = dodatkowyBagaz;
        this.przelecianeKilometry = przelecianeKilometry;
        this.iloscDzieci = iloscDzieci;
        this.iloscDoroslych = iloscDoroslych;
        this._klasa = _klasa;
        this._bilet = _bilet;
        this._cel = _cel;
    }

    /**
     * Metoda licząca podatek dla podanej kwoty.
     * @param Kwota od której wyliczony jest podatek.
     * @return zwraca obliczony podatek.
     */
    public static double PoliczPodatek(double Kwota) {
        return Kwota * stopaPodatku;
    }

    /**
     * Metoda wyliczająca cenę częściową za podróż (bez podatku).
     * @return zwraca cenę częściową (bez podatku) wybranej podróży.
     */
    public double PoliczSumeCzesciowa() {
        double cenaKoncowa = 0;
        switch (_cel) {
            case Krakow_Gdansk -> cenaKoncowa += Cena.Krakow_Gdansk;
            case Krakow_Tunezja -> cenaKoncowa += Cena.Krakow_Tunezja;
            case Wroclaw_Japonia -> cenaKoncowa += Cena.Wroclaw_Japonia;
            case Rzeszow_Helsinki -> cenaKoncowa += Cena.Rzeszow_Helsinki;
            case Warszawa_NowyYork -> cenaKoncowa += Cena.Warszawa_NowyYork;
        }

        cenaKoncowa += iloscDoroslych * Cena.jedna_osoba + iloscDzieci * Cena.dziecko;

        if (specjalnePotrzeby)
        {
            cenaKoncowa += Cena.specjalnePotrzeby;
        }
        if (ubezpieczenie)
        {
            cenaKoncowa += Cena.ubezpieczenie;
        }
        if (dodatkowyBagaz)
        {
            cenaKoncowa += Cena.dodatkowy_bagaz;
        }
        if (przelecianeKilometry)
        {
            cenaKoncowa += Cena.kilometry;
        }
        switch (_klasa) {
            case biznesowa -> cenaKoncowa += Cena.biznesowa;
            case pierwszaKlasa -> cenaKoncowa += Cena.pierwsza_klasa;
        }
        if (_bilet == bilet.powrot) {
            if (_klasa == klasa.ekonomiczna) {
                cenaKoncowa += Cena.ekonomiczna;
            } else if (_klasa == klasa.biznesowa) {
                cenaKoncowa += Cena.biznesowa;
            } else if (_klasa == klasa.pierwszaKlasa) {
                cenaKoncowa += Cena.pierwsza_klasa;
            }
        }
        return cenaKoncowa;

    }

    /**
     * Metoda wyliczająca cenę końcową podróży.
     * @return sumę częściową plus podatek.
     */
    public double PoliczKoszt() {
        return PoliczSumeCzesciowa() + PoliczPodatek(PoliczSumeCzesciowa());
    }

    /**
     * Metoda porównująca podróże po ich sygnaturach.
     * @param other druga podróż.
     * @return zwraca podróże do porównania.
     */
    public boolean equals(Podroz other){
        if (sygnatura == null || other.sygnatura == null) { return false; }
        return this.sygnatura.equals(other.sygnatura);
    }

    /**
     * Metoda porównująca sygnaturę lub w dalszej kolejności nazwisko
     * @param o podróż.
     * @return porównane podróże.
     */
    @Override
    public int compareTo(Podroz o) {
        if (!Objects.equals(o.sygnatura, this.sygnatura))
        {
            return o.sygnatura.compareTo(this.sygnatura);
        }
        else
        {
            return o.nazwisko.compareTo(this.nazwisko);
        }
    }

    /**
     * Metoda klonująca podróż. Wyrzuca wyjątek, gdy nie można jej skopiować.
     * @return skopiowaną podróż
     */
    @Override
    public Podroz clone() {
        try {
            return (Podroz) super.clone();
        } catch (CloneNotSupportedException e) {
            throw new AssertionError();
        }
    }

    /**
     * Metoda wypisująca informacje o podróży do konsoli.
     * @return tekst z danymi podróży.
     */
    @Override
    public String toString() {
        return super.toString()+
                ", sygnatura: " + sygnatura +
                ", specjalnePotrzeby: " + specjalnePotrzeby +
                ", ubezpieczenie: " + ubezpieczenie +
                ", dodatkowyBagaz: " + dodatkowyBagaz +
                ", przelecianeKilometry: " + przelecianeKilometry +
                ", iloscDzieci: " + iloscDzieci +
                ", iloscDoroslych: " + iloscDoroslych +
                ", klasa: " + _klasa +
                ", bilet: " + _bilet +
                ", cel: " + _cel +
                ", koszt:" + NumberFormat.getCurrencyInstance().format(PoliczKoszt());
    }
}
