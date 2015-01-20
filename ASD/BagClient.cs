using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class BagClient
    {
        public static void Main(string[] args)
        {
            Bag<int> bag = new Bag<int>();
            int[] arr = { 3, 5, 2, 7 };
            foreach (int item in arr)
            {
                bag.add(item);
            }

            int suma = 0;
            foreach (var item in bag)
            {
                suma += item;
            }
            Console.WriteLine("Suma elementelor din bag = {0}", suma);
        }
    }
}
