using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Osoba o1 = new Osoba("Jakub", "Krawczak", "Łamana 12 Kraków", "30-689", "531295527", "kuba10a_lo@wp.pl");
            Console.WriteLine(o1);*/
            

            Podroze l1 = new Podroze("Jakub", "Nowak","01274543459", "Łamana 34 Gdańsk", "30-697", "531290527", "Nowak@wp.pl", Lotniska.BaliceKraków,cele.Grecja_Zakynthos,2,false,true,true,false,Klasy.biznesowa,Bilety.powrot,1);
            Podroze l2 = new Podroze("Miłosz", "Gołdyn", "01273343459", "Łużycka 12 Poznań", "30-689", "531495527", "Mil.o2.pl", Lotniska.BaliceKraków, cele.Tajlandia_Bangkoku, 1, true, true, false, false, Klasy.ekonomiczna, Bilety.jednaStrona, 2);
            

            BiuroPodrozy biuroPodrozy = new BiuroPodrozy("System biura podrozy");
            biuroPodrozy.DodajLot(l1);
            biuroPodrozy.DodajLot(l2);
            Console.WriteLine(biuroPodrozy);

            biuroPodrozy.ZapiszDoBazy();
            Console.WriteLine("Zapisano do bazy danych");

            BiuroPodrozy noweBiuro = BiuroPodrozy.OdczytZBazy();
            Console.WriteLine(noweBiuro);
            //Sortowanie
            /*biuroPodrozy.Sortuj();
            Console.WriteLine(biuroPodrozy);*/

            //Sortowanie po peselu
            /*biuroPodrozy.SortujPoPESEL();
            Console.WriteLine(biuroPodrozy);*/

            //BiuroPodrozy.ZapiszXML("Biuro.xml", biuroPodrozy);

            //Czy podroz jest dodana do biura podrozy
            //Console.WriteLine(biuroPodrozy.CzyPodrozJestWBiurzePodrozy(l2));

            //Compare
            /*Console.WriteLine( l1.CompareTo(l2));*/

            //klonowanie
            /*BiuroPodrozy b2 = biuroPodrozy.DeepCopy();
            Console.WriteLine(b2);*/

            //Odczytywanie XML
            /*BiuroPodrozy b2 = BiuroPodrozy.OdczytajXML("Biuro.xml");
            Console.WriteLine(b2);*/


            Console.ReadKey();
        }
    }
}
