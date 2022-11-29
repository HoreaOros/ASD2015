using System;
using System.Collections.Generic;


namespace ASD
{
    class BagClient
    {
        public static void Main(string[] args)
        {
            Bag<int> bag = new Bag<int>(100);
            int[] arr = { 3, 5, 2, 7 };
            foreach (int item in arr)
            {
                bag.add(item);
            }

            //int suma = 0;
            //foreach (var item in bag)
            //{
            //    suma += item;
            //}
            //Console.WriteLine("Suma elementelor din bag = {0}", suma);

            IEnumerator<int> enumerator = bag.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
        }
    }
}
