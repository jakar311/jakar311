using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    /// <summary>
    /// Interfejs IBiuro przechowujący metody dodawania, usuwania, wyszukiwania oraz sprawdzania czy dany lot jest już w biurze
    /// </summary>
    interface IBiuro
    {
        void DodajLot(Podroze t);
        void UsunLot(Podroze t);
        void UsunLot(string PESEL);
        bool CzyPodrozJestWBiurzePodrozy(Podroze podroz);
        List<Podroze> WyszukajPodroze(string wylot);
    }
}
