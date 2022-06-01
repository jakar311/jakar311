#pragma once
#define WEGLOWODANY 1
#define TLUSZCZE 2
#define BIALKA 3

typedef struct Produkty {
    int typ;
    char* nazwa;
    int wartosci;
} Produkty;


int policz_diete_sniadanie(Produkty x, struct Wartosci_odzywcze wo);
int policz_diete_obiad(Produkty x, struct Wartosci_odzywcze wo);
int policz_diete_kolacje(Produkty x, struct Wartosci_odzywcze wo);
