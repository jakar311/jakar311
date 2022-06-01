#pragma once

struct Osoba {
    int plec;
    int wiek;
    int wzrost;
    float waga;
    int tryb_zycia;
    int kg_do_stracenia;
    int okres;
    int dni_jadlospis;
};
void dane(struct Osoba* x);