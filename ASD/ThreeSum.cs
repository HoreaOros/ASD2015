using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ASD
{
    class ThreeSum
    {
        public static int count(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            for(int i = 0; i < n; i++)
                for(int j = i + 1; j < n; j++)
                    for(int k = j + 1; k < n; k++)
                        if (arr[i] + arr[j] + arr[k] == 0)
                        {
                            contor++;
                        }
            return contor;
        }
        public static int countFast(int []arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            Array.Sort(arr);

            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (BinarySearch.rank(-arr[i] - arr[j], arr) > j)
                        contor++;
            return contor;
        }
        public static int countFaster(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            Array.Sort(arr);

            // trebuie scrisa o secventa liniara care determina cate triplete de numere din vectorul arr au suma 0
            // TODO

            return contor;
        }
        public static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();

            sw.Start();
            int[] arr = Util.readInts("1Kints.txt");
            Console.WriteLine(count(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            arr = Util.readInts("2Kints.txt");
            Console.WriteLine(count(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            arr = Util.readInts("4Kints.txt");
            Console.WriteLine(count(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            arr = Util.readInts("8Kints.txt");
            Console.WriteLine(count(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
