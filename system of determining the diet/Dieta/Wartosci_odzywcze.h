#pragma once
struct Wartosci_odzywcze {
    float weglo;
    float tluszcz;
    float bialko;
    float sniadanie_weglo;
    float sniadanie_tluszcz;
    float sniadanie_bialko;
    float obiad_weglo;
    float obiad_tluszcz;
    float obiad_bialko;
    float kolacja_weglo;
    float kolacja_tluszcz;
    float kolacja_bialko;
};
void policz_wartosci_odzywcze(struct Kalorie k, struct Wartosci_odzywcze* wo);
