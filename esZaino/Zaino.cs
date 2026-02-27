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
        public int ValoreAccumulato;
        public List<int> OggettiPresi;

        public Zaino(int indice, int valore, int peso, List<int> presi)
        {
            IndiceUltimoOggetto = indice;
            ValoreAccumulato = valore;
            PesoAccumulato = peso;
            OggettiPresi = new List<int>(presi);
        }
    }
}
