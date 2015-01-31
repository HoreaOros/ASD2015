using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    /// <summary>
    /// Implementare eficienta a MergeSort
    /// </summary>
    class MergeXSort
    {
        private static readonly int CUTOFF = 7;  // stabilim o dimensiune a vectorului pentru care soratarea se face cu InsertionSort
        /// <summary>
        /// Nu permitem instantierea clasei
        /// </summary>
        private MergeXSort()
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
            T[] aux = new T[a.Length]; // vectorul auxiliar il cream o singura data pentru un spor de eficienta
            for (int i = 0; i < a.Length; i++)
                aux[i] = a[i];

            sort(aux, 0, a.Length - 1, a);
        }

        private static void sort<T>(T[] src, int lo, int hi, T[] dst) where T : IComparable<T>
        {
            if (hi <= lo + CUTOFF) // daca vectorul are o lungime mica il sortam cu insertionSort
            {
                insertionSort(dst, lo, hi);
                return;
            }

            int mid = lo + (hi - lo) / 2;
            sort(dst, lo, mid, src);
            sort(dst, mid + 1, hi, src);

            if (!less(src[mid + 1], src[mid]))
            {
                for (int i = lo; i <= hi; i++) 
                    dst[i] = src[i];
                return;
            }

            merge(src, lo, mid, hi, dst);
        }

        // sortam de la a[lo] pana la  a[hi] folosind InsertionSort
        private static void insertionSort<T>(T[] a, int lo, int hi) where T: IComparable<T>
        {
            for (int i = lo; i <= hi; i++)
                for (int j = i; j > lo && less(a[j], a[j - 1]); j--)
                    exch(a, j, j - 1);
        }

        private static void merge<T>(T[] src, int lo, int mid, int hi, T[] dst) where T : IComparable<T>
        {
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) 
                    dst[k] = src[j++];
                else if (j > hi) 
                    dst[k] = src[i++];
                else if (less(src[j], src[i])) 
                    dst[k] = src[j++];   // pentru a asigura stabilitate
                else 
                    dst[k] = src[i++];
            }
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
