package com.company;

import java.io.*;
import java.sql.*;
import java.text.NumberFormat;
import java.util.ArrayList;
import java.util.Objects;

/**
 * Klasa BiuroPodróży przechowująca podróże, korzystająca z interfejsu IBiuro oraz ICloneable.
 */
public class BiuroPodrozy implements IBiuro,Cloneable, Serializable {
    /**
     * Zmienna nazywająca biuro podróży.
     */
    private String nazwa;
    /**
     * Zmodyfikowane pole loty, które jest listą.
     */
    private ArrayList<Podroz> loty;

    /**
     * Konstruktor nieparametryczny tworzący nową listę 'loty' i ustawiający pole 'nazwa'.
     * @param nazwa  nadająca nazwę biura.
     */
    public BiuroPodrozy(String nazwa) {
        this.nazwa = nazwa;
        loty = new ArrayList<>();
    }

    public String getNazwa() {
        return nazwa;
    }

    public ArrayList<Podroz> getLoty() {
        return loty;
    }

  /**
     * Metoda dodająca wybraną podróż.
     * @param t wybrany lot do dodania.
     */
    @Override
    public void DodajLot(Podroz t) {
        loty.add(t);
    }

    /**
     * Metoda usuwająca wybraną podróż.
     * @param t wybrany lot do usunięcia.
     */
    @Override
    public void UsunLot(Podroz t) {
        loty.remove(t);
    }

    /**
     * Metoda usuwająca podróże z wybranym peselem.
     * @param PESEL wybrany pesel.
     */
    @Override
    public void UsunLot(String PESEL) {
        for (Podroz l:loty) {
            if (Objects.equals(l.pesel, PESEL))
            {
                loty.remove(l);
                break;
            }
        }
    }

    /**
     * Metoda sprawdzająca czy wybrana podróż znajduje się w biuerze podróży.
     * @param podroz wybrana podróż.
     * @return prawda lub fałsz.
     */
    @Override
    public boolean CzyPodrozJestWBiurzePodrozy(Podroz podroz) {
        for (Podroz l:loty) {
            if (l.equals(podroz))
                return true;
        }
        return false;
    }

    /**
     * Metoda, która wyszukuje podróż przez podanie nazwy lotniska z którego jest wylot.
     * @param wylot wybrane lotnisko.
     * @return lista podróży z wybranego lotniska.
     */
    @Override
    public ArrayList<Podroz> WyszukajPodroze(String wylot) {
        ArrayList<Podroz> newList = new ArrayList<>();
        for (Podroz l:loty) {
            if (l._cel.toString().contains(wylot))
            {
                newList.add(l);
            }
        }
        return newList;
    }

    /**
     * Metoda, która sortuje loty (po sygnaturze).
     */
    public void Sortuj() {
        loty.sort(Podroz::compareTo);
    }

    /**
     * Metoda, która sortuje loty (po peselu).
     */
    public void SortujPoPESEL() {
        loty.sort(new PESELComparator());
    }

    /**
     * Metoda klonująca biuro podróży. W razie niepowodzenia wyrzuca wyjątek.
     * @return klon podróży.
     */
    @Override
    public BiuroPodrozy clone() {
        try {
            return (BiuroPodrozy) super.clone();
        } catch (CloneNotSupportedException e) {
            throw new AssertionError();
        }
    }

    public void a(BiuroPodrozy b)
    {
        this.nazwa = b.nazwa;
        this.loty = b.loty;
    }

    /**
     * Metoda zapisująca biuro podróży do pliku.
     * @param nazwa nazwa biura podróży.
     */
    public void zapisz(String nazwa){
        try {
            FileOutputStream fileOutputStream = new FileOutputStream(nazwa);
            ObjectOutputStream objOutputStream = new ObjectOutputStream(fileOutputStream);

            objOutputStream.writeObject(this);
            fileOutputStream.close();
            objOutputStream.close();

        } catch ( IOException e ) {
            e.printStackTrace();
        }
    }

    /**
     * Metoda odczytująca biuro podróży z pliku.
     * @param nazwa nazwa biura.
     * @return biuro podrózy.
     */
    public static BiuroPodrozy odczytaj(String nazwa){
        BiuroPodrozy biuro = null;

        try {
            FileInputStream fileInputStream = new FileInputStream(nazwa);
            var objectInputStream = new ObjectInputStream(fileInputStream);

            biuro = (BiuroPodrozy) objectInputStream.readObject();

            objectInputStream.close();
            fileInputStream.close();

        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }
        return biuro;
    }

    /**
     * Medota zapisująca wybrane biuro podróży do bazy danych.
     * @param biuro wybrane biuro podróży.
     * @throws SQLException w razie niepowodzenia wyrzuca SQLEException.
     */
    public void ZapiszDoBazy(BiuroPodrozy biuro) throws SQLException {
        Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/biuro-podrozy","root","mypass");
        Statement statement = connection.createStatement();
        biuro.Sortuj();
        for(Podroz l:loty){
            String sqlPodroz = "INSERT INTO podroz (Sygnatura,PESEL, SpecjalnePotrzeby, Ubezpieczenie, DodatkowyBagaz, PrzelecianeKilometry, IloscDzieci, IloscDoroslych, Klasa, Bilet, Cel, Koszt) VALUES  ('"+l.sygnatura+"', '"+l.pesel+"', '"+l.specjalnePotrzeby+"', '"+l.ubezpieczenie+"', '"+l.dodatkowyBagaz+"', '"+l.przelecianeKilometry+"', '"+l.iloscDzieci+"', '"+l.iloscDoroslych+"', '"+l._klasa+"', '"+l._bilet+"', '"+l._cel+"', '"+ NumberFormat.getCurrencyInstance().format(l.PoliczKoszt())+"')";
            String sqlOsoba = "INSERT INTO osoba (Imie, Nazwisko, Adres, KodPocztowy, Telefon, Email, PESEL) VALUES  ('"+l.imie+"', '"+l.nazwisko+"', '"+l.adres+"', '"+l.kodPocztowy+"', '"+l.telefon+"', '"+l.email+"', '"+l.pesel+"')";
            statement.executeUpdate(sqlOsoba);
            statement.executeUpdate(sqlPodroz);
        }
        System.out.println("Zapisano do bazy :)");
    }

    /**
     * Medota odczytująca biuro podróży z bazy danych. W razie niepowodzenia lub niepoprawnych danych wyrzuca wyjątki.
     * @return biuro.
     * @throws SQLException wyjątek.
     * @throws ZlyTelefonException wyjątek.
     * @throws ZlyKodPocztowyException wyjątek.
     * @throws ZlyPeselException wyjątek..
     */
    public static com.company.BiuroPodrozy OdczytajZBazy() throws SQLException, ZlyTelefonException, ZlyKodPocztowyException, ZlyPeselException {
        Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/biuro-podrozy","root","mypass");
        Statement statement = connection.createStatement();
        ResultSet resultSet = statement.executeQuery(("SELECT osoba.Imie, osoba.Nazwisko, osoba.Adres, osoba.KodPocztowy, osoba.Telefon, osoba.Email, osoba.PESEL, podroz.SpecjalnePotrzeby, podroz.Ubezpieczenie, podroz.DodatkowyBagaz, podroz.PrzelecianeKilometry, podroz.IloscDzieci, podroz.IloscDoroslych, podroz.Klasa, podroz.Bilet, podroz.Cel FROM podroz INNER JOIN osoba ON podroz.PESEL=osoba.PESEL;"));

        com.company.BiuroPodrozy noweBiuro=new com.company.BiuroPodrozy("OdczytaneBiuro");
        while(resultSet.next()){
            Podroz p1 = new Podroz(resultSet.getString("Imie"),
                    resultSet.getString("Nazwisko"),
                    resultSet.getString("Adres"),
                    resultSet.getString("KodPocztowy"),
                    resultSet.getString("Telefon"),
                    resultSet.getString("Email"),
                    resultSet.getString("PESEL"),
                    Boolean.parseBoolean(resultSet.getString("SpecjalnePotrzeby")),
                    Boolean.parseBoolean(resultSet.getString("Ubezpieczenie")),
                    Boolean.parseBoolean(resultSet.getString("DodatkowyBagaz")),
                    Boolean.parseBoolean(resultSet.getString("PrzelecianeKilometry")),
                    Integer.parseInt(resultSet.getString("IloscDzieci")),
                    Integer.parseInt(resultSet.getString("IloscDoroslych")),
                    Podroz.klasa.valueOf(resultSet.getString("Klasa")) ,
                    Podroz.bilet.valueOf(resultSet.getString("Bilet")),
                    Podroz.cel.valueOf(resultSet.getString("Cel")));
            noweBiuro.DodajLot(p1);
        }
        return noweBiuro;
    }

    /**
     * Metoda wypisująca nazwę, oraz loty z biura podróży.
     * @return nazwa biura oraz loty.
     */
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Nazwa: ").append(nazwa).append("\n");
        for(Podroz lot: loty)
        {
            sb.append(lot.toString()).append("\n");
        }
        return sb.toString();
    }
}
