using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ASD
{
    class TopM
    {
        public static void Main(string[] args)
        {
            int M = 5;
            MinPQ<int> pq = new MinPQ<int>(M + 1);

            //StreamReader fs = new StreamReader("tinyW.txt");
            //StreamReader fs = new StreamReader("tinyT.txt");
            //StreamReader fs = new StreamReader("largeW.txt");
            StreamReader fs = new StreamReader("largeT.txt");
            string line;
            while (!fs.EndOfStream)
            {
                line = fs.ReadLine();
                pq.insert(int.Parse(line));

                // eliminam valoarea minima din coada cu prioritate daca sunt M+1 elemente in coada
                if (pq.size() > M)
                    pq.delMin();
            } // cele mai mari M elemente sunt in coada



            // afisam elementele din coada cu prioritate in ordine inversa
            Stack<int> stack = new Stack<int>();
            foreach (var item in pq)
                stack.push(item);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
