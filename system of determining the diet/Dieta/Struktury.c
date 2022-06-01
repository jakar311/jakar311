struct Osoba {
    int plec;
    int wiek;
    int wzrost;
    float waga;
    int tryb_zycia;
    int kg_do_stracenia;
    int okres;
};

struct Kalorie {
    float dieta_kalorie;
    float CPM;
    float PPM;
};

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

struct Skladnik {
    int typ; //1 - weglo, 2 - tlusz, 3 - bialko
    float waga;
    float wartosc;
};