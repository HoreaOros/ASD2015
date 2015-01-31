using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class MergeSort
    {
        /// <summary>
        /// Nu permitem instantierea clasei
        /// </summary>
        private MergeSort()
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
        /// Insertion sort. Toate elementele din stanga pozitiei i sunt ordonate. 
        /// Elementul de pe pozitia i il inseram la locul lui prin mutarea elementelor inspre dreapta daca e cazul
        /// </summary>
        /// <param name="a"></param>
        public static void sort<T>(T[] a) where T : IComparable<T>
        {
            T[] aux = new T[a.Length]; // vectorul auxiliar il cream o singura data pentru un spor de eficienta
            sort(a, 0, a.Length - 1, aux);
        }

        private static void sort<T>(T[] a, int lo, int hi, T[] aux) where T: IComparable<T>
        {
            if (hi <= lo)
                return;

            int mid = lo + (hi - lo) / 2;
            sort(a, lo, mid, aux);
            sort(a, mid + 1, hi, aux);
            merge(a, lo, mid, hi, aux);
        }

        private static void merge<T>(T[] a, int lo, int mid, int hi, T[] aux) where T: IComparable<T>
        {
            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++) // copiem portiunea din a in aux
                aux[k] = a[k];

            for (int k = lo; k <= hi; k++)
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (less(aux[j], aux[i]))
                    a[k] = aux[j++];
                else
                    a[k] = aux[i++];
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
