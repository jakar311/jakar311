#include <stdio.h>
#include<stdlib.h>
#include "Liczenie_kalorii.h"
#include "Wczytywanie_Danych.h"

#define KOBIETA 1
#define SIEDZACY 1
#define NISKA 2
#define SREDNIA 3
#define WYSOKA 4
#define KG_KCAL 7000 //1 kg masy cia³a to 7000 kalorii

/*funkcja liczaca PPM - czyli podstawow¹ przemianê materii cz³owieka,
CPM-ca³kowit¹ przemianê materii,
a tak¿e dzienn¹ liczbê kalorii w trakcie diety - dieta_kalorie 
*/

void policz_kalorie(struct Osoba x, struct Kalorie* k) {
    if (x.plec == KOBIETA) 
    {
        k->PPM = (float)(665.09 + (9.56 * x.waga) + (1.85 * x.wzrost) - (4.67 * x.wiek)); //PPM dla kobiety
    }
    else
    {
        k->PPM = (float)(66.47 + (13.7 * x.waga) + (5.0 * x.wzrost) - (6.76 * x.wiek)); //PPM dla mezczyzny
    }

    //CPM liczona w zale¿noœci od trybu zycia 
    switch (x.tryb_zycia)
    {
    case SIEDZACY:
        k->CPM = (float)(k->PPM * 1.15);
        break;
    case NISKA:
        k->CPM = (float)(k->PPM * 1.35);
        break;
    case SREDNIA:
        k->CPM = (float)(k->PPM * 1.6);
        break;
    case WYSOKA:
        k->CPM = (float)(k->PPM * 1.85);
        break;
    default:
        break;
    }

    //dzienna liczba kalorii w trakcie diety
    k->dieta_kalorie = k->CPM - (x.kg_do_stracenia * KG_KCAL / x.okres);

    //warunek gdy dzienna liczba kalorii w trakcie diety jest mniejsza, rowna 0
    if (k->dieta_kalorie <= 0)
    {
        printf("Twoje dzienne zapotrzebowanie kaloryczne wynosi %1.f kalorie,\nco oznacza ze nie powinienes nic jesc, a ponadto musisz spalac %d kalorie dziennie.", k->dieta_kalorie, abs((int)k->dieta_kalorie));
        printf("\n****************************************************************************************");
        printf("\nTO NIEBEZPIECZNE DLA TWOJEGO ZDROWIA.\nSTOSOWANIE TAKIEJ DIETY ZAGRAZA TWOJEMU ZYCIU LUB ZDROWIU.\nPILNIE SKONTKATUJ SIE Z LEKARZEM LUB DIETETYKIEM!");
        printf("\n****************************************************************************************");
        exit(1);
    }
    printf("Liczba dziennych kalorii w jadlospisie: %f\n", k->dieta_kalorie);
}