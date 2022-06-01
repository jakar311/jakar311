#include <stdio.h>
#include<stdlib.h>
#include "Jadlospis.h"
#include "tablica.h"


//deklarowanie tablicy zawieraj¹cej 21 produktów podzielone na 3 rodzaje mikroskladnikow
Produkty tab[21] = {
    {.typ = WEGLOWODANY, .nazwa = "banan", .wartosci = 23}, // 23 gram weglowodanow na 100 gram
    {.typ = TLUSZCZE, .nazwa = "maslo", .wartosci = 57},
    {.typ = BIALKA, .nazwa = "omlet", .wartosci = 15},

    {.typ = WEGLOWODANY, .nazwa = "ziemniaki", .wartosci = 30},
    {.typ = TLUSZCZE, .nazwa = "kotlet", .wartosci = 40},
    {.typ = BIALKA, .nazwa = "salata", .wartosci = 35},

    {.typ = WEGLOWODANY, .nazwa = "platki", .wartosci = 67},
    {.typ = TLUSZCZE, .nazwa = "migdaly", .wartosci = 50},
    {.typ = BIALKA, .nazwa = "mleko", .wartosci = 17},

    {.typ = WEGLOWODANY, .nazwa = "makaron pelnoziarnisty", .wartosci = 68},
    {.typ = TLUSZCZE, .nazwa = "awokado", .wartosci = 15},
    {.typ = BIALKA, .nazwa = "losos wedzony", .wartosci = 18},

    {.typ = WEGLOWODANY, .nazwa = "ryz bialy", .wartosci = 28},
    {.typ = TLUSZCZE, .nazwa = "nasiona chia", .wartosci = 31},
    {.typ = BIALKA, .nazwa = "twarog", .wartosci = 11},

    {.typ = WEGLOWODANY, .nazwa = "sliwki suszone", .wartosci = 64},
    {.typ = TLUSZCZE, .nazwa = "pestki dyni", .wartosci = 19},
    {.typ = BIALKA, .nazwa = "mozarella", .wartosci = 28},

    {.typ = WEGLOWODANY, .nazwa = "soczewica", .wartosci = 20},
    {.typ = TLUSZCZE, .nazwa = "orzechy laskowe", .wartosci = 61},
    {.typ = BIALKA, .nazwa = "dorsz wedzony", .wartosci = 19},
};

//losowanie mikroskladnika (weglowodany, tluszcze, bialko) z tablicy  
Produkty los_wegl()
{
    int wegl = rand() % 21;
    while (tab[wegl].typ != WEGLOWODANY) 
    {
        wegl = rand() % 21;
    }
    return tab[wegl]; 
}
Produkty los_tluszcz()
{
    int tluszcz = rand() % 21;
    while (tab[tluszcz].typ != TLUSZCZE)
    {
        tluszcz = rand() % 21;
    }
    return tab[tluszcz];
}
Produkty los_bialko()
{
    int bialko = rand() % 21;
    while (tab[bialko].typ != BIALKA)
    {
        bialko = rand() % 21;
    }
    return tab[bialko];
}