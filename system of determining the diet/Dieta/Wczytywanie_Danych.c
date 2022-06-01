#include <stdio.h>
#include<stdlib.h>
#include "Wczytywanie_Danych.h"

/*funkcja sluzaca do wczytawania danych od uzytkownika(p³ec, wiek, wzrost, wage, tryb zycia, kg do zrzucenia,
okres diety, okres jadlospisu) program jest zabezpieczony przed wpisaniem niepoprawnych danych*/
void dane(struct Osoba* x)
{
    printf("Podaj plec: 1-kobieta, 2-mezczyzna: ");

    while (scanf_s("%d", &x->plec) == 0 || (x->plec != 1 && x->plec != 2) || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }
    printf("Podaj wiek: ");
    while (scanf_s("%d", &x->wiek) == 0 || (x->wiek >= 150 || x->wiek < 1) || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }

    printf("Podaj wzrost [cm]: ");
    while (scanf_s("%d", &x->wzrost) == 0 || x->wzrost >= 250 || x->wzrost < 1 || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }

    printf("Podaj wage [kg]: ");
    while (scanf_s("%f", &x->waga) == 0 || x->waga >= 300 || x->waga < 10 || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }

    printf("Podaj tryb zycia: 1-siedzacy(brak cwiczen), 2-niska aktywonosc, 3-srednia aktwnosc, 4-wysoka aktywnosc:");
    while (scanf_s("%d", &x->tryb_zycia) == 0 || (x->tryb_zycia != 1 && x->tryb_zycia != 2 && x->tryb_zycia != 3 && x->tryb_zycia != 4) || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }

    printf("Podaj ile kg chcesz schudnac: ");
    while (scanf_s("%d", &x->kg_do_stracenia) == 0 || x->kg_do_stracenia >= 50 || x->kg_do_stracenia < 0 || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }

    printf("Podaj okres diety w dniach: ");
    while (scanf_s("%d", &x->okres) == 0 || x->okres < 0 || ferror(stdin))
    {
        printf("Niepoprawne dane, Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }
    printf("Podaj ilosc dni na, ktore chcesz wygenerowac jadlospis: \n");
    while (scanf_s("%d", &x->dni_jadlospis) == 0 || x->dni_jadlospis < 0 || (x->dni_jadlospis > x->okres)|| ferror(stdin)) //jadlospis nie moze byc dluzszy niz okres diety
    {
        printf("Twoj jadlospis nie moze byc na dluzszy okres niz twoja dieta. Podaj jeszcze raz:\n");
        fseek(stdin, 0, SEEK_END);
    }
}