package com.company;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

public class OsobaTest {
    public OsobaTest() throws ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException {
    }

    Osoba osoba = new Osoba("Janusz", "Tracz", "Kraków", "34-700", "123456789",
            "janusztracz@gmail.com", "11111111111");

    @Test
    public void testSetKodPocztowyException(){
        assertThrows(ZlyKodPocztowyException.class, () -> osoba.setKodPocztowy("34-70a"));
    }

    @Test
    @DisplayName("Sprawdzanie czy próba ustawienia numeru telefonu o mniejszej liczbie cyfr wyrzuca wysatek ZlyTelefonException")
    public void testSetTelefonException(){
        assertThrows(ZlyTelefonException.class, () -> osoba.setTelefon("12345678"));
    }

    @Test
    @DisplayName("Sprawdzanie czy próba ustawienia peselu o wiekszej liczbie cyfr wyrzuca wyjątek ZlyPeselException")
    public void testSetPeselException(){
        assertThrows(ZlyPeselException.class, () -> osoba.setPesel("213432114321421"));
    }

    @Test
    @DisplayName("Sprawdzanie czy próba ustawienia numeru telefonu zawierającego literę wyrzuca wyjątek ZlyTelefonException")
    public void testSetTelefonException1(){
        assertThrows(ZlyTelefonException.class, () -> osoba.setTelefon("234565ab1"));
    }
}