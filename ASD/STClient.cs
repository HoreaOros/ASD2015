using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class STClient
    {
        public static void Main(string[] args)
        {
            ST<string, int?> st = new ST<string, int?>();

            // Adaug in colectie 3 perechi (cheie, valoare)
            st.put("Marin", 34);
            st.put("Ionel", 22);
            st.put("Cornel", 45);

            // Afisez elementele colectiei
            foreach (var item in st.keys())
            {
                Console.WriteLine(item);
            }

            // Determin numarul de elemente din colectie
            Console.WriteLine("Dimensiunea tabelei simbolice este {0}", st.size());


            string nume = "Marin";
            if (st.contains(nume))
            {
                Console.WriteLine("{0} are {1} ani", nume, st.get(nume));
            }
            else
            {
                Console.WriteLine("{0} nu se afla in colectie", nume);
            }

            st.put(nume, 35);
            Console.WriteLine("{0} are {1} ani", nume, st.get(nume));

            // Elimin din colectie o pereche (cheie, valoare)
            st.put(nume, null);
            foreach (var item in st.keys())
            {
                Console.WriteLine(item);
            }
        }
    }
}
