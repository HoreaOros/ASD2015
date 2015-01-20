using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class QueueClient
    {
        public static void Main(string[] args)
        {
            Queue<int> q = new Queue<int>();
            // Adaugam in coada cateva numere
            for (int i = 0; i < 10; i++)
            {
                q.enqueue(i);
            }

            // Afisam toate elementele din coada
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            // Efectuam cateva operatii asupra cozii
            q.dequeue();
            q.dequeue();
            q.enqueue(11);

            // Afisam din nou toate elementele din coada
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
        }
    }
}
