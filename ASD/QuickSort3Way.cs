using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    /// <summary>
    /// Quick Sort
    /// </summary>
    class QuickSort3Way
    {




        /// <summary>
        /// Nu permitem instantierea clasei
        /// </summary>
        private QuickSort3Way()
        {

        }
        public static void Main(string[] args)
        {
            string filename = "words3.txt";
            string[] a = Util.readWords(filename);

            sort(a);

            Debug.Assert(isSorted(a), "Vectorul nu este sortat");

            show(a);

        }
        /// <summary>
        /// MergeSort 
        /// </summary>
        /// <param name="a"></param>
        public static void sort<T>(T[] a) where T : IComparable<T>
        {
            Util.shuffle(a); // se elimina dependenta de datele de intrare
            sort(a, 0, a.Length - 1);
        }

        private static void sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)
                return;
            int lt = lo, i = lo + 1, gt = hi;
            T v = a[lo];
            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);
                if (cmp < 0) 
                    exch(a, lt++, i++);
                else if (cmp > 0) 
                    exch(a, i, gt--);
                else 
                    i++;
            }
            // a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi].
            sort(a, lo, lt - 1);
            sort(a, gt + 1, hi);
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
        /// <summary>
        /// Metoda privata ajutatoare care afiseaza elementele vectorului pe o singura linie
        /// </summary>
        /// <param name="a">Vector de elemente</param>
        private static void show<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Metoda care determina daca vectorul este sortat
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool isSorted<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 1; i < a.Length; i++)
                if (less(a[i], a[i - 1]))
                    return false;
            return true;
        }
    }
}
