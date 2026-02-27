namespace esZaino
{
    internal class Program
    {
        const int capacitaMassima = 50;
        static void Main(string[] args)
        {
            int valoreOttimo = 0;
            int pesoOttimo = 0;
            List<int> soluzioneOttima = new List<int>();
            int[] pesi = { 11, 13, 7, 21, 40 };
            int[] valori = { 10, 15, 8, 25, 50 };
            if (pesi.Length < 0)
                throw new Exception("non ci sono valori");
            if (capacitaMassima <= 0)
                throw new Exception("Capacità non valida!");
            Zaino zaino = new Zaino(0, 0, 0, new List<int>());
            Nodo<Zaino> radice = new Nodo<Zaino>(zaino);
            Naviga(radice, valori, pesi, ref valoreOttimo, ref pesoOttimo, ref soluzioneOttima);
            Console.WriteLine($"Risultato ottimo: {valoreOttimo} con peso {pesoOttimo}");
            Console.WriteLine("Oggetti Inclusi : ");
            foreach (int indice in soluzioneOttima)
                Console.WriteLine($"{valori[indice]} con peso {pesi[indice]}");
        }

        static void Naviga(Nodo<Zaino> nodo, int[] valori, int[] pesi, ref int valoreOttimo, ref int pesoOttimo, ref List<int> soluzioneOttima)
        {
            Zaino s = nodo.Dati;
            if (s.IndiceUltimoOggetto >= valori.Length)     //finisco i valori
            {
                if (s.ValoreAccumulato > valoreOttimo)
                {
                    valoreOttimo = s.ValoreAccumulato;
                    pesoOttimo = s.PesoAccumulato;
                        soluzioneOttima = new List<int>(s.OggettiPresi);
                }
                return;
            }
            //Prendo l'oggetto
            int pesoConNuovoOggetto = s.PesoAccumulato + pesi[s.IndiceUltimoOggetto];
            int valoreConNuovoOggetto = s.ValoreAccumulato + valori[s.IndiceUltimoOggetto];
            if (pesoConNuovoOggetto <= capacitaMassima)
            {
                List<int> nuovaLista = new List<int>(s.OggettiPresi);
                nuovaLista.Add(s.IndiceUltimoOggetto);
                nodo.Prendo = new Nodo<Zaino>(new Zaino(s.IndiceUltimoOggetto + 1, valoreConNuovoOggetto, pesoConNuovoOggetto, nuovaLista));
                Naviga(nodo.Prendo, valori, pesi, ref valoreOttimo, ref pesoOttimo, ref soluzioneOttima);
            }
            //Non prendo l'oggetto
            nodo.NonPrendo = new Nodo<Zaino>(new Zaino(s.IndiceUltimoOggetto + 1, s.ValoreAccumulato, s.PesoAccumulato, new List<int>(s.OggettiPresi)));
            Naviga(nodo.NonPrendo, valori, pesi, ref valoreOttimo, ref pesoOttimo, ref soluzioneOttima);
        }
    }
}
