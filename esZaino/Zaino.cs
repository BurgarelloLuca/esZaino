using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esZaino
{
    public class Zaino
    {
        public int IndiceUltimoOggetto;
        public int PesoAccumulato;
        public List<int> OggettiPresi;

        public Zaino(int indice, int peso, List<int> presi)
        {
            IndiceUltimoOggetto = indice;
            PesoAccumulato = peso;
            OggettiPresi = new List<int>(presi);
        }
    }
}
