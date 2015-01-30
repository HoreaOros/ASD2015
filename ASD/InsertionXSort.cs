using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class InsertionXSort
    {
        /// <summary>
        /// Constructor private. Nu vrem sa permitem instantierea clasei
        /// </summary>
        private InsertionXSort()
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
            int i, j;
            T v;
            int n = a.Length;
            // punem cel mai mic element pe prima pozitie pentru a avea rol de santinela
            for (i = n - 1; i > 0; i--)
                if (less(a[i], a[i - 1])) 
                    exch(a, i, i - 1);

            // Insertion sort cu un numar injumatatit de interschimbari. Nu apelam functia exch
            for (i = 2; i < n; i++)
            {
                v = a[i];
                j = i;
                while (less(v, a[j - 1]))
                {
                    a[j] = a[j - 1];
                    j--;
                }
                a[j] = v;
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
                Console.WriteLine("{0} ", a[i]);
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
