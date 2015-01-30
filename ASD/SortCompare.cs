using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class SortCompare
    {
        public static void Main(string[] arg)
        {
            string alg1 = arg[0]; // numele primului algoritm de sortare
            string alg2 = arg[1]; // numele celui de-al doilea algoritm de sortare
            int N = int.Parse(arg[2]); // numarul de elemente ce sunt sortate
            int T = int.Parse(arg[3]); // numarul de iteratii ale algoritmului de sortare 
                        //(facem mai multe sortari pentru a obtine o valoarea medie care aproximeaa mai bine timpul de executie

            double t1 = timeRandomInput(alg1, N, T);
            double t2 = timeRandomInput(alg2, N, T);
            Console.WriteLine("Pentru {0} valori aleatoare de tip double {1}Sort este de {2:F3} ori mai rapid decat {3}Sort", N, alg1, t2 / t1, alg2);
        }

        private static double timeRandomInput(string alg, int N, int T)
        {
            double total = 0.0;
            double[] a = new double[N];
            Random rnd = new Random();
            for (int i = 0; i < T; i++)
            {
                for (int j = 0; j < N; j++)
                    a[j] = rnd.NextDouble();
                total += time(alg, a);
            }

            return total;
        }

        private static double time(string alg, Double[] a)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            switch (alg)
            {
                case "Insertion":
                    InsertionSort.sort(a);
                    break;
                case "InsertionX":
                    InsertionXSort.sort(a);
                    break;
                case "Selection":
                    SelectionSort.sort(a);
                    break;
                case "Shell":
                    //ShellSort.sort(a);
                    break;
                case "Merge":
                    //MergeSort.sort(a);
                    break;
                case "Quick":
                    //QuickSort.sort(a);
                    break;
                case "Heap":
                    //HeapSort.sort(a);
                    break;
                default:
                    break;
            }
            return sw.ElapsedMilliseconds;
        }
    }
}
