using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ASD
{
    class Util
    {
        public static int[] readInts(string filename)
        {
            string line;
            string[] tokens;
            int[] arr;
            char[] seps = {' ', '\t', '\n'};
            using(StreamReader sr = new StreamReader(filename))
            {
                line = sr.ReadToEnd();
                tokens = line.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                arr = new int[tokens.Length];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = int.Parse(tokens[i]);
                }
                return arr;
            }
        }
        public static double sqrt(double c)
        {
            if (c == 0) 
                return Double.NaN;
            
            double err = 1e-15;
            double t = c;
            
            while (Math.Abs(t - c / t) > err * t)
                t = (c / t + t) / 2.0;
            
            return t;
        }
        /// <summary>
        /// Permuta aleator elementele unui vector
        /// </summary>
        /// <param name="arr">Vector de numere</param>
        public static void shuffle(int[] arr)
        {
            int temp;
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            { 
                // interschimba a[i] cu un element aleator din arr[i..N-1], N - nr de elemente al vectorlui
                int r = i + rnd.Next(arr.Length - i);
                temp = arr[i];
                arr[i] = arr[r];
                arr[r] = temp;
            }
        }
        static void Main(string[] args)
        {
            double no = 26.0;
            Console.WriteLine("Radical din {0} = {1}", no, sqrt(no));

            int[] arr = { 1, 2, 3, 4, 5, 6 };
            shuffle(arr);
            foreach (int item in arr)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
        }
    }
}
