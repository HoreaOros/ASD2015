using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class MaxMinPQClient
    {
        public static void Main(string[] arg)
        {
            string filename = "words3.txt";
            string[] a = Util.readWords(filename);

            MaxPQ<string> pqMax = new MaxPQ<string>();

            foreach (var item in a)
            {
                pqMax.insert(item);
            }
            // se vor afisa cuvintele in ordine descrescatoare
            Console.WriteLine("MaxPQ");
            while (!pqMax.isEmpty())
            {
                Console.WriteLine(pqMax.delMax());
            }

            
            MinPQ<string> pqMin = new MinPQ<string>();
            foreach (var item in a)
            {
                pqMin.insert(item);
            }
            // se vor afisa cuvintele in ordine crescatoare
            Console.WriteLine("\nMinPQ");
            while (!pqMin.isEmpty())
            {
                Console.WriteLine(pqMin.delMin());
            }

        }
    }
}
