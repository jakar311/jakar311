# Projekt JAVA biuro podróży

Członkowie grupy:
Kamil Husak
Jakub Krawczak
Jakub Luboński
Mateusz Filas

Temat: biuro podróży

Projekt będzie polegał na stworzeniu systemu biura podróży. Przechowywał on będzie dodane, przez np. pracownika biura, podróże. Każda z nich będzie zawierała informacje na temat danych klienta oraz ilości osób współpodróżujących, miejsca wylotu, celu podróży, klasie, rodzaju biletu oraz dodatkowych opcjach (Specjalne potrzeby, ubezpieczenie, dodatkowy bagaż oraz bonus za przeleciane kilometry). Po wprowadzaniu wszystkich danych zostają wyświetlone informacje o koszcie częściowym, podatku, koszcie całkowitym oraz zostaje wydrukowany rachunek zawierający podsumowanie.
W głównym spisie jest możliwość sortowania sortowania rekordów po PESELU albo po przypisanej do podróży sygnaturze. Istnieje również opcja wyszukiwania listy podróży z wylotem z podanego lotniska. Można zapisywać oraz odczytywać stworzone biuro podróży do pliku BIN.
Dostępna jest też funkcja zapisu biura podróży do bazy danych (MySQL)

Szablonowy projekt do użycia w środowisku IntelliJ.

Projekt korzysta z:
* IntelliJ
* Java
* Java Swing
* JDBC
* Junit 5
* JavaDoc
* PlantUML
* [TestFX](https://github.com/TestFX/TestFX) do użycia komponentów JavaFX w testach

Podział obowiązków:
- Kamil Husak - utworzenie GUI przy użyciu Java Swing
- Mateusz Filas - stworzenie testów jednostkowych w JUnit 5 i stworzenie prezentacji
- Jakub Luboński - utworzenie dokumentacji przy użyciu JavaDoc oraz diagramu klas przy użyciu PlantUML
- Jakub Krawczak - stworzenie struktury klas oraz połączenia z bazą danych JDBC (MySQL)
