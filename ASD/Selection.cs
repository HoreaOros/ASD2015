using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class Selection
    {
        /// <summary>
        /// Gaseste cea de-a k-a valoare mica dintr-un vector in timp liniar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static T select<T>(T[] a, int k) where T: IComparable<T>
        {
            Util.shuffle(a);
            int lo = 0, hi = a.Length - 1;
            while (hi > lo)
            {
                int j = partition(a, lo, hi);
                if (j == k) return a[k];
                else if (j > k) hi = j - 1;
                else if (j < k) lo = j + 1;
            }
            return a[k];
        }
        private static int partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int i = lo, j = hi + 1;
            T v = a[lo]; // elementul dupa care se face partitionarea. la sfarsitul procesului acest element va fi pe locul final in vectorul sortat
            while (true)
            {
                while (less(a[++i], v))
                    if (i == hi)
                        break;
                while (less(v, a[--j]))
                    if (j == lo)
                        break;
                if (i >= j)
                    break;
                exch(a, i, j);
            }
            exch(a, lo, j); // punem pe v in pozitia finala j
            return j;       // a[lo..j-1] <= a[j] <= a[j+1..hi]
        }
        /// <summary>
        /// Metoda privata ajutatoare pentru a determina daca un element este mai mic decat altul
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private static bool less<T>(T p, T q) where T : IComparable<T>
        {
            return p.CompareTo(q) < 0;
        }
        /// <summary>
        /// Metoda privata ajutatoare care interschimba doua valori din vector
        /// </summary>
        /// <param name="a"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        private static void exch<T>(T[] a, int i, int j) where T : IComparable<T>
        {
            T t;
            t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
        public static void Main(string[] args)
        {
            string filename = "words3.txt";
            string[] a = Util.readWords(filename);
            int k = 10;

            Console.WriteLine("A {0}-a valoare mica din vector este: {1}", k, select(a, k));
        }
    }
}
