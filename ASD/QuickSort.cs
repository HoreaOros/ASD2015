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
    class QuickSort
    {

      


        /// <summary>
        /// Nu permitem instantierea clasei
        /// </summary>
        private QuickSort()
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
            sort(a, 0, a.Length);
        }

        private static void sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo)
                return;
            int j = partition(a, lo, hi);
            sort(a, lo, j - 1);
            sort(a, j + 1, hi);
        }

        private static int partition<T>(T[] a, int lo, int hi) where T: IComparable<T>
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
