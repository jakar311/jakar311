package com.company;

import java.io.Serializable;
import java.util.regex.Pattern;


/**
 * Klasa zawierająca informację o osobie.
 */
public class Osoba implements Serializable {
    String imie;
    String nazwisko;
    String adres;
    String kodPocztowy;
    String telefon;
    String email;
    String pesel;


    /**
     * Hermetyzacja pola kodPocztowy oraz sprawdzenie czy został wpisany poprawnie.
     * w przeciwnym razie wyrzucany jest błąd.
     * @param kodPocztowy wartość zmiennej kodPocztowy.
     * @throws ZlyKodPocztowyException wyrzucony zostaje wyjątek.
     */
    public void setKodPocztowy(String kodPocztowy) throws ZlyKodPocztowyException {
        String regex = "^[0-9]{2}-[0-9]{3}$";
        Pattern pattern = Pattern.compile(regex);
        if (!pattern.matcher(kodPocztowy).matches()) {
            throw new ZlyKodPocztowyException();
        }
        this.kodPocztowy = kodPocztowy;
    }

    /**
     * Hermetyzacja pola telefon oraz sprawdzenie czy numer został wpisany poprawnie,
     * w przeciwnym razie wyrzucany jest błąd.
     * @param telefon wartość zmiennej telefon.
     * @throws ZlyTelefonException wyrzucony zostaje wyjątek.
     */
    public void setTelefon(String telefon) throws ZlyTelefonException {
        String regex = "^[0-9]{9}$";
        Pattern pattern = Pattern.compile(regex);
        if (!pattern.matcher(telefon).matches()) {
            throw new ZlyTelefonException();
        }
        this.telefon = telefon;
    }

    /**
     * Hermetyzacja pola pesel oraz sprawdzenie czy został wpisany poprawnie,
     * w przeciwnym razie wyrzucany jest wyjątek.
     * @param pesel wartość zmiennej pesel.
     * @throws ZlyPeselException zostaje wyrzucony wyjątek.
     */
    public void setPesel(String pesel) throws ZlyPeselException {
        String regex = "^[0-9]{11}$";
        Pattern pattern = Pattern.compile(regex);
        if (!pattern.matcher(pesel).matches()) {
            throw new ZlyPeselException();
        }
        this.pesel = pesel;
    }

    /**
     * Konstruktor parametryczny dla klasy Osoba, wyrzucający wyjątki w przypadku niepoprawnie wpisanych danych.
     * @param imie nadaje imię.
     * @param nazwisko nadaje nazwisko.
     * @param adres nadaje adres.
     * @param kodPocztowy nadaje kod.
     * @param telefon nadaje telefon.
     * @param email nadaje email.
     * @param pesel nadaje pesel.
     * @throws ZlyKodPocztowyException wyrzuca wyjątek.
     * @throws ZlyTelefonException wyrzuca wyjątek.
     * @throws ZlyPeselException wyrzuca wyjątek.
     */
    public Osoba(String imie, String nazwisko, String adres, String kodPocztowy, String telefon, String email, String pesel) throws ZlyKodPocztowyException, ZlyTelefonException, ZlyPeselException {
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.adres = adres;
        setKodPocztowy(kodPocztowy);
        setTelefon(telefon);
        this.email = email;
        setPesel(pesel);
    }
    /**
     * Metoda wypisująca dane osoby do konsoli.
     * @return zwraca imię, nazwisko, adres, kodPocztowy, telefon, email oraz pesel.
     */
    @Override
    public String toString() {
        return "Imie: " + imie +
                ", Nazwisko: " + nazwisko +
                ", Adres: " + adres +
                ", KodPocztowy: " + kodPocztowy +
                ", Telefon: " + telefon +
                ", Email: " + email +
                ", Pesel: " + pesel;
    }
}
