#include "Jadlospis.h"
#include "Wartosci_odzywcze.h"

#define WAGA 100 // 100 gram

/* funkcja, która liczy, ile gramow danego produktu musimy dostarczyc w poszczegolnym posilku, 
    na podstawie wczeœniej wyliczonych wartoœci od¿ywyczych*/

int policz_diete_sniadanie(Produkty x, struct Wartosci_odzywcze wo) {
    if (WEGLOWODANY) {
        return (int)((wo.sniadanie_weglo / x.wartosci) * WAGA); //zapotrzebowana wartosc wegl(gram) w danej diecie/wartosc wegl jak¹ dostarcza produkt
    }
    else if (TLUSZCZE) {
        return (int)((wo.sniadanie_tluszcz / x.wartosci) * WAGA);
    }
    else {
        return (int)((wo.sniadanie_bialko / x.wartosci) * WAGA);
    }
}

int policz_diete_obiad(Produkty x, struct Wartosci_odzywcze wo) {
    if (WEGLOWODANY) {
        return (int)((wo.obiad_weglo / x.wartosci) * WAGA);
    }
    else if (TLUSZCZE) {
        return (int)((wo.obiad_tluszcz / x.wartosci) * WAGA);
    }
    else {
        return (int)((wo.obiad_bialko / x.wartosci) * WAGA);
    }
}

int policz_diete_kolacje(Produkty x, struct Wartosci_odzywcze wo) {
    if (WEGLOWODANY) {
        return (int)((wo.kolacja_weglo / x.wartosci) * WAGA);
    }
    else if (TLUSZCZE) {
        return (int)((wo.kolacja_tluszcz / x.wartosci) * WAGA);
    }
    else {
        return (int)((wo.kolacja_bialko / x.wartosci) * WAGA);
    }
}