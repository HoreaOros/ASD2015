using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class ShellSort
    {
        /// <summary>
        /// Constructor private. Nu vrem sa permitem instantierea clasei
        /// </summary>
        private ShellSort()
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
        /// InsertionX sort. Mai eficient decat InsetionSort pentru ca folosim un singur apel la exch pentru fiecare element.
        /// Toate elementele din stanga pozitiei i sunt ordonate. 
        /// Elementul de pe pozitia i il inseram la locul lui prin mutarea elementelor inspre dreapta daca e cazul
        /// </summary>
        /// <param name="a"></param>
        public static void sort<T>(T[] a) where T : IComparable<T>
        {
            int n = a.Length;

            // 3x+1 secventa de incrementuri:  1, 4, 13, 40, 121, 364, 1093, ... 
            int h = 1;
            while (h < n / 3) 
                h = 3 * h + 1; 

            while (h >= 1) {
                // h-sortare a vectorului 
                for (int i = h; i < n; i++) {
                    for (int j = i; j >= h && less(a[j], a[j-h]); j -= h) {
                        exch(a, j, j-h);
                    }
                }
                
                h /= 3;
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
