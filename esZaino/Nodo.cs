using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esZaino
{
    public class Nodo<T>
    {
        public T Dati;
        public Nodo<T> Prendo;
        public Nodo<T> NonPrendo;

        public Nodo(T dati)
        {
            Dati = dati;
            Prendo = null;
            NonPrendo = null;
        }
    }
}
