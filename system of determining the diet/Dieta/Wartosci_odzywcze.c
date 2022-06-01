#include "Liczenie_kalorii.h"
#include "Wartosci_odzywcze.h"


void policz_wartosci_odzywcze(struct Kalorie k, struct Wartosci_odzywcze* wo) {
    /* Wyliczenie jak¹ czêœæ diety stanowi¹ poszczególne wartoœci od¿ywcze
    Zamiana kalorii na gramy - np. mamy dietê 1000kcal, 
    to weglowodany stanowi¹ 500kcal/4 = 125 gramów produktu reprezentuj¹cego wêglowodany powinnyœmy zjeœæ
    */
    wo->weglo = (float)((0.5 * k.dieta_kalorie) / 4);
    wo->tluszcz = (float)((0.3 * k.dieta_kalorie) / 9);
    wo->bialko = (float)((0.2 * k.dieta_kalorie) / 4);

    //Podzia³ na poszczególne posi³ki w ci¹gu dnia (œniadanie, obiad, kolacja)  
    wo->sniadanie_weglo = (float)(wo->weglo * 0.3); // czyli na sniadanie mamy dostarczyc 125*0,3=37,5g weglowodanow
    wo->sniadanie_tluszcz = (float)(wo->tluszcz * 0.3);
    wo->sniadanie_bialko = (float)(wo->bialko * 0.3);
    wo->obiad_weglo = (float)(wo->weglo * 0.5);
    wo->obiad_tluszcz = (float)(wo->tluszcz * 0.5);
    wo->obiad_bialko = (float)(wo->bialko * 0.5);
    wo->kolacja_weglo = (float)(wo->weglo * 0.2);
    wo->kolacja_tluszcz = (float)(wo->tluszcz * 0.2);
    wo->kolacja_bialko = (float)(wo->bialko * 0.2);
}