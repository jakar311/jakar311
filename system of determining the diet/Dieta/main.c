#include <stdio.h>
#include<stdlib.h>
#include "Wczytywanie_Danych.h"
#include "Liczenie_kalorii.h"
#include "Jadlospis.h"
#include "Wartosci_odzywcze.h"
#include "tablica.h"

//CPM-ca³kowita przemiana materii
//PPM - Podstawowa przemiana materii-¿ycie
//dieta_kalorie - dzienna liczba kalorii w trakcie diety

int main()
{
    struct Osoba x;
    struct Kalorie k;
    struct Wartosci_odzywcze wo;

    time_t t;
    srand((unsigned)time(&t));

        dane(&x);
        policz_kalorie(x, &k);
        policz_wartosci_odzywcze(k, &wo);

        
        /*petla przechodzaca przez kolejne dni jadlospisu wypisujaca dla kazdego dnia sniadanie, obiad i kolacje
        wraz z podzialem na wylosowane produkty i ich wartosci w gramach odpowiadajace na zapotrzebowanie dzienne danego mikrosk³adnika w diecie.*/

        for (int i = 1; i<=x.dni_jadlospis; ++i)
        {
        printf("\n****************************************\n");
        printf("DZIEN %d\n",i);
        printf("****************************************\n");

        Produkty wegl = los_wegl();
        Produkty tluszcz = los_tluszcz();
        Produkty bialko = los_bialko();

        printf("\nSNIADANIE\n");
        printf("- %s: %d [gramow]\n", wegl.nazwa, policz_diete_sniadanie(wegl, wo));
        printf("- %s : %d [gramow]\n", tluszcz.nazwa, policz_diete_sniadanie(tluszcz, wo));
        printf("- %s: %d [gramow]\n", bialko.nazwa, policz_diete_sniadanie(bialko, wo));

        wegl = los_wegl();
        tluszcz = los_tluszcz();
        bialko = los_bialko();

        printf("\nOBIAD\n");
        printf("- %s: %d [gramow]\n", wegl.nazwa, policz_diete_obiad(wegl, wo));
        printf("- %s: %d [gramow]\n", tluszcz.nazwa, policz_diete_obiad(tluszcz, wo));
        printf("- %s: %d [gramow]\n", bialko.nazwa, policz_diete_obiad(bialko, wo));

        wegl = los_wegl();
        tluszcz = los_tluszcz();
        bialko = los_bialko();

        printf("\nKOLACJA\n");
        printf("- %s: %d [gramow]\n", wegl.nazwa, policz_diete_kolacje(wegl, wo));
        printf("- %s: %d [gramow]\n", tluszcz.nazwa, policz_diete_kolacje(tluszcz, wo));
        printf("- %s: %d [gramow]\n", bialko.nazwa, policz_diete_kolacje(bialko, wo));
    }
  
    return 0;
}

