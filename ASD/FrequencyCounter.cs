using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class FrequencyCounter
    {
        /// <summary>
        /// Citeste un parametru din linia de comanda si o lista de cuvinte
        /// din intrarea standard si afiseaza cuvantul care apare cel mai 
        /// frecvent (al carui lungime depaseste valoarea data in linia de 
        /// comanda. De asemenea afiseaza numarul de cuvinte ale caror lungime
        /// depaseste valoarea din linia de comanda si numarul de astfel de cuvinte
        /// distincate
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) 
        {
            int distinct = 0, words = 0;
            int minlen = int.Parse(args[0]);

            ST<String, int?> st = new ST<String, int?>();

            // Calculeaza frecventa de aparitie a fiecarui cuvant

            String key = Console.ReadLine();
            while (key != null) 
            {
                if (key.Length < minlen) 
                    continue;
                words++;
                if (st.contains(key)) {
                    st.put(key, st.get(key) + 1);
                }
                else {
                    st.put(key, 1);
                    distinct++;
                }
            }

            // gaseste cheia care apare cel mai frecvent
            String max = "";
            st.put(max, 0);
            foreach (string word in st.keys()) {
                if (st.get(word) > st.get(max))
                    max = word;
            }

            Console.WriteLine("{0} {1}", max, st.get(max)); 
            Console.WriteLine("Cuvinte distincte: {0}", distinct);
            Console.WriteLine("Cuvinte: {0}", words);
            
        }   
    }
}
