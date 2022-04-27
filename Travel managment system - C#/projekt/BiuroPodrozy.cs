using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace projekt
{
    /// <summary>
    /// Klasa BiuroPodróży przechowująca podróże, korzystająca z interfejsów IBiuro oraz ICloneable
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Podroze))]
    
    public class BiuroPodrozy: IBiuro,ICloneable
    {
        /// <summary>
        /// Identyfikator (klucz) o nazwe BiuroID
        /// </summary>
        [Key]
        public int BiuroId { get; set; }

        /// <summary>
        /// Zmodyfikowane pole loty, które jest listą
        /// </summary>
        public virtual List<Podroze> loty { get; set; }
        

        /// <summary>
        /// Nazwa biura podróży
        /// </summary>
        private string nazwa;
        /// <summary>
        /// Hermetyzacja pola nazwa
        /// </summary>
        public string Nazwa { get => nazwa; set => nazwa = value; }
        /// <summary>
        /// Konstruktor nieparametryczny tworzący nową listę 'loty'
        /// </summary>
        public BiuroPodrozy() {
            loty = new List<Podroze>();
        }

        /// <summary>
        /// Konstruktor parametryczny ustawiający pole 'nazwa'
        /// </summary>
        /// <param name="nazwa">Nazwa biura podróży</param>
        public BiuroPodrozy(string nazwa) : this()
        {
            this.Nazwa = nazwa; 
        }

        /// <summary>
        /// Metoda zapisująca do bazy danych
        /// </summary>
        public void ZapiszDoBazy()
        {
            using (Model1 db = new Model1())
            {
                db.BiuroPod.Add(this);
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Metoda odczytująca baze danych
        /// </summary>
        public static BiuroPodrozy OdczytZBazy()
        {
            using (Model1 db = new Model1())
            {
                int maxindex = db.BiuroPod.Max(zz => zz.BiuroId);
                var zbaza = db.BiuroPod.Find(maxindex); // Where(r => r.zespolId == maxindex).First();
                BiuroPodrozy z = new BiuroPodrozy();
                z.Nazwa = zbaza.Nazwa;
                z.loty = zbaza.loty;
                return z;
            }
        }

        /// <summary>
        /// Metoda dodająca wybraną podróż
        /// </summary>
        /// <param name="t">Wybrany lot do dodania</param>
        public void DodajLot(Podroze t)
        {
            loty.Add(t);
        }

        /// <summary>
        /// Metoda usuwająca wybraną podróż
        /// </summary>
        /// <param name="t">Wybrany lot do usunięcia</param>
        //Usuwanie lotu
        public void UsunLot(Podroze t)
        {
            loty.Remove(t);
        }

        /// <summary>
        /// Metoda usuwająca podróż z danym PESELEM
        /// </summary>
        /// <param name="PESEL">Wybrany PESEL</param>
        public void UsunLot(string PESEL)
        {
            foreach (Podroze l in loty)
            {
                if (l.PESEL == PESEL)
                {
                    loty.Remove(l);
                    break;
                }
            }
        }

        /// <summary>
        /// Metoda sprawdzajaca czy dana podróż jest już w biurze podróży
        /// </summary>
        /// <param name="podroz">wybrana podróż</param>
        /// <returns>true jeśli podroz jest już dodana albo false jeśli nie jest </returns>
        public bool CzyPodrozJestWBiurzePodrozy(Podroze podroz)
        {
            foreach (Podroze pod in loty)
                if (pod.Equals(podroz))
                    return true;
            return false;
        }

        /// <summary>
        /// Metoda, która wyszukuje podróż przez podanie nazwy lotniska z którego jest wylot
        /// </summary>
        /// <param name="wylot">Nazwa lotniska</param>
        /// <returns>Zwraca listę podróży</returns>
        public List<Podroze> WyszukajPodroze(string wylot)
        {
            List<Podroze> newList = new List<Podroze>();
            newList = loty.FindAll(c => c.Wylot.ToString().Equals(wylot));

            return newList;
        }

        /// <summary>
        /// Metoda, która sortuje loty (Po sygnaturze)
        /// </summary>
        public void Sortuj()
        {
            loty.Sort();
        }

        /// <summary>
        /// Metoda, która sortuje loty według peselu
        /// </summary>
        public void SortujPoPESEL()
        {
            loty.Sort(new PESELComparator());
        }

        /// <summary>
        /// Metoda zapisująca BiuroPodrozy do pliku xml 
        /// </summary>
        /// <param name="nazwa">Nazwa pliku XML</param>
        /// <param name="z">Biuro podróży do zapisania</param>
        public static void ZapiszXML(string nazwa, BiuroPodrozy z)
        {
            var serializer = new XmlSerializer(typeof(BiuroPodrozy));
            var fs = new StreamWriter(nazwa);
            serializer.Serialize(fs, z);
            fs.Close();
        }

        /// <summary>
        /// Metoda odczytująca BiuroPodrozy z pliku xml
        /// </summary>
        /// <param name="nazwa">Nazwa pliku xml do odczytania</param>
        /// <returns>Zwraca odczytane biuro podróży</returns>
        public static BiuroPodrozy OdczytajXML(string nazwa)
        {
            BiuroPodrozy noweBiuro;
            var xf = new XmlSerializer(typeof(BiuroPodrozy));
            var fs = new StreamReader(nazwa);
            noweBiuro = (BiuroPodrozy)xf.Deserialize(fs);
            fs.Close();
            return noweBiuro;
        }

        /// <summary>
        /// Metoda tworząca płytką kopię obiektu BiuroPodrozy
        /// </summary>
        /// <returns>Płytka kopia obiektu</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        /// <summary>
        /// Metoda tworząca głęboką kopię obiektu BiuroPodrozy
        /// </summary>
        /// <returns>Głęboka kopia obiektu</returns>
        public BiuroPodrozy DeepCopy()
        {
            BiuroPodrozy biuro = new BiuroPodrozy(Nazwa);
            foreach (Podroze l in loty)
            {
                Podroze lot = (Podroze)l.Clone();
                biuro.DodajLot(lot);
            }
            return biuro;
        }

        /// <summary>
        /// Metoda wypisująca nazwę, oraz loty z biura podróży
        /// </summary>
        /// <returns>Wypisana nazwa oraz lista podróży</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nazwa: {Nazwa}");
            foreach(Podroze lot in loty)
            {
                sb.AppendLine(lot.ToString());
            }

            return sb.ToString();
        }
    }
}
