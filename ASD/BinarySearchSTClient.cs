using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class BinarySearchSTClient
    {
        public static void Main(string[] args)
        {
            BinarySearchST<string, int?> bsst = new BinarySearchST<string, int?>();

            // Adaug in colectie 3 perechi (cheie, valoare)
            bsst.put("Marin", 34);
            bsst.put("Ionel", 22);
            bsst.put("Cornel", 45);

            // Afisez elementele colectiei
            foreach (var item in bsst.Keys())
            {
                Console.WriteLine(item);
            }

            // Determin numarul de elemente din colectie
            Console.WriteLine("Dimensiunea tabelei simbolice este {0}", bsst.size());


            string nume = "Marin";
            if (bsst.contains(nume))
            {
                Console.WriteLine("{0} are {1} ani", nume, bsst.get(nume));
            }
            else
            {
                Console.WriteLine("{0} nu se afla in colectie", nume);
            }

            bsst.put(nume, 35);
            Console.WriteLine("{0} are {1} ani", nume, bsst.get(nume));

            // Elimin din colectie o pereche (cheie, valoare)
            bsst.put(nume, null);
            foreach (var item in bsst.Keys())
            {
                Console.WriteLine(item);
            }
        }
    }
}
