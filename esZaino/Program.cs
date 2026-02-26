namespace esZaino
{
    internal class Program
    {
        const int capacitaMassima = 50;
        static void Main(string[] args)
        {
            int pesoOttimo = 0;
            List<int> soluzioneOttima = new List<int>();
            int[] pesi = { 11, 13, 7, 21, 40 };
            int[] 
            if (pesi.Length < 0)
                throw new Exception("non ci sono valori");
            if (capacitaMassima <= 0)
                throw new Exception("Capacità non valida!");
            Zaino zaino = new Zaino(0, 0, new List<int>());
            Nodo<Zaino> radice = new Nodo<Zaino>(zaino);
            Naviga(radice, pesi, ref pesoOttimo, ref soluzioneOttima);
            Console.WriteLine($"Risultato ottimo: {pesoOttimo}");
            Console.Write("Oggetti Inclusi : ");
            foreach (int indice in soluzioneOttima)
                Console.Write($"{pesi[indice]} ");
        }

        static void Naviga(Nodo<Zaino> nodo, int[] valori, ref int pesoOttimo, ref List<int> soluzioneOttima)
        {
            Zaino s = nodo.Dati;
            if (s.IndiceUltimoOggetto >= valori.Length)     //finisco i valori
            {
                if (s.PesoAccumulato > pesoOttimo || (s.PesoAccumulato == pesoOttimo && s.OggettiPresi.Count < soluzioneOttima.Count))
                {
                    pesoOttimo = s.PesoAccumulato;
                    soluzioneOttima = new List<int>(s.OggettiPresi);
                }
                return;
            }
            //Prendo l'oggetto
            int pesoConNuovoOggetto = s.PesoAccumulato + valori[s.IndiceUltimoOggetto];
            if (pesoConNuovoOggetto <= capacitaMassima)
            {
                List<int> nuovaLista = new List<int>(s.OggettiPresi);
                nuovaLista.Add(s.IndiceUltimoOggetto);

                nodo.Prendo = new Nodo<Zaino>(new Zaino(s.IndiceUltimoOggetto + 1, pesoConNuovoOggetto, nuovaLista));
                Naviga(nodo.Prendo, valori, ref pesoOttimo, ref soluzioneOttima);
            }
            //Non prendo l'oggetto
            nodo.NonPrendo = new Nodo<Zaino>(new Zaino(s.IndiceUltimoOggetto + 1, s.PesoAccumulato, new List<int>(s.OggettiPresi)));
            Naviga(nodo.NonPrendo, valori, ref pesoOttimo, ref soluzioneOttima);
        }
    }
}
