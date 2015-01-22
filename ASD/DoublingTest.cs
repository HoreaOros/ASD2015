using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class DoublingTest
    {
        public static void Main(string[] args)
        {
            for(int N = 250; true; N += N )
            {
                long time = timeTrial(N);
                Console.WriteLine("{0}\t{1}", N, time / 1000.0);
            }
        }

        private static long timeTrial(int N)
        {
            Stopwatch sw = new Stopwatch();
            int MAX = 1000000;
            Random rnd = new Random();
            int[] arr = new int[N];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-MAX, MAX + 1);
            sw.Start();
            ThreeSum.count(arr);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }
    }
}
