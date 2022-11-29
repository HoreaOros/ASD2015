using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class TwoSum
    {
        public static int count(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] + arr[j] == 0)
                    {
                        contor++;
                    }
            return contor;
        }
        public static int countFast(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            Array.Sort(arr);

            for (int i = 0; i < n; i++)
                if (BinarySearch.rank(-arr[i], arr) > i)
                    contor++;
            return contor;
        }
        public static int countFaster(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            Array.Sort(arr);

            // trebuie scrisa o secventa liniara care determina cate perechi de numere din vectorul arr au suma 0
            // TODO
            int i = 0;
            int j = arr.Length - 1;
            while (i < j)
            {
                if (arr[i] + arr[j] == 0)
                {
                    contor++;
                }
                else if (arr[i] + arr[j] < 0)
                    i++;
                else
                    j--;

            }
            return contor;
        }
        public static void Main(string[] args)
        {
            int p;
            int[] arr;
            
            Stopwatch sw = new Stopwatch();
            
            arr = Util.readInts("1Kints.txt");
            sw.Start();
            p = count(arr);
            sw.Stop();
            
            Console.WriteLine(p + " perechi cu suma 0");
            Console.WriteLine(sw.Elapsed);
            
            arr = Util.readInts("2Kints.txt");
            sw.Restart();
            p = count(arr);
            sw.Stop();

            Console.WriteLine(p + " perechi cu suma 0");
            Console.WriteLine(sw.Elapsed);

            arr = Util.readInts("4Kints.txt");
            sw.Restart();
            p = count(arr);
            sw.Stop();

            Console.WriteLine(p + " perechi cu suma 0");
            Console.WriteLine(sw.Elapsed);
            
            
            arr = Util.readInts("8Kints.txt");
            sw.Restart();
            p = count(arr);
            sw.Stop();

            Console.WriteLine(p + " perechi cu suma 0");
            Console.WriteLine(sw.Elapsed);
        }
    }
}
