using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class BinarySearch
    {
        /// <summary>
        /// Cautare binara implementare recursiva
        /// </summary>
        /// <param name="key">Cheia care se cauta</param>
        /// <param name="a">Vectorul in care se cauta</param>
        /// <returns>Pozitia pe care apare cheia in vector sau -1 daca cheia nu e in vector</returns>
        public static int rankRec(int key, int[] a)
        {
            return rankRec(key, a, 0, a.Length - 1);
        }

        private static int rankRec(int key, int[] a, int lo, int hi)
        { 
            if (lo > hi) 
                return -1;
            int mid = lo + (hi - lo) / 2;
            
            if (key < a[mid]) 
                return rankRec(key, a, lo, mid - 1);
            else if (key > a[mid]) 
                return rankRec(key, a, mid + 1, hi);
            else 
                return mid;
        }
        /// <summary>
        /// Cautare binara implementare nerecursiva
        /// </summary>
        /// <param name="key">Cheia care se cauta</param>
        /// <param name="a">Vectorul in care se cauta</param>
        /// <returns>Pozitia pe care apare cheia in vector sau -1 daca cheia nu e in vector</returns>
        public static int rank(int key, int[] a)
        {
            int lo, hi, mid;
            lo = 0;
            hi = a.Length - 1;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else
                    return mid;
            }
            return -1;
        }
        /// <summary>
        /// Determina numarul de elemente din vector care sunt mai mici decat cheia
        /// Vectorul sortat poate avea elemente care se repeta
        /// </summary>
        /// <param name="key">Cheia care se cauta</param>
        /// <param name="arr">Vector</param>
        /// <returns>Daca cheia nu se afla in vector se intoarce valoarea -1</returns>
        public static int lessThanKey(int key, int[] arr)
        {
            int lo, hi, mid;
            lo = 0;
            hi = arr.Length - 1;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (arr[mid] < key)
                    lo = mid + 1;
                else if (arr[mid] >= key)
                    hi = mid - 1;
            }
            if (hi >= 0 && hi < arr.Length && arr[hi] == key)
                return hi;
            else if (lo >= 0 && lo < arr.Length && arr[lo] == key)
                return lo;
            else
                return -1;
        }
        /// <summary>
        /// Determina numarul de elemente din vector care sunt mai mari decat cheia
        /// Vectorul sortat poate avea elemente care se repeta
        /// </summary>
        /// <param name="key">Cheia care se cauta</param>
        /// <param name="arr">Vector</param>
        /// <returns>Daca cheia nu se afla in vector se intoarce valoarea -1</returns>
        public static int greaterThanKey(int key, int[] arr)
        {
            int lo, hi, mid;
            lo = 0;
            hi = arr.Length - 1;
            while (lo <= hi)
            {
                mid = lo + (hi - lo) / 2;
                if (arr[mid] <= key)
                    lo = mid + 1;
                else if (arr[mid] > key)
                    hi = mid - 1;
            }
            if (hi >= 0 && hi < arr.Length && arr[hi] == key)
                return arr.Length - hi - 1;
            else if (lo >= 0 && lo < arr.Length && arr[lo] == key)
                return arr.Length - lo - 1;
            else
                return -1;
        }

        /// <summary>
        /// Un vector cu n elemente DISTINCTE se numeste bitonic daca exista un index k pentru care elementele de la 0 la k sunt in ordine crescatoare
        /// si elementele de la k + 1 la n - 1 sunt in ordine descrescatoare
        /// Se cere sa se determine daca o valoarea key se afla intr-un vector bitonic
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arr"></param>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns>Pozitia pe care se afla key sau -1 daca nu e in vector</returns>
        public static int bitonic_search(int key, int[] arr)
        {
            int maxPoz = searchMax(arr, 0, arr.Length - 1);

            int pozLeft = rankRec(key, arr, 0, maxPoz);
            int pozRight = rankRec(key, arr, maxPoz + 1, arr.Length - 1);

            if (pozLeft == -1 && pozRight == -1)
                return -1;
            else
                return Math.Max(pozLeft, pozRight);
            
        }

        /// <summary>
        /// Determina pozitia celui mai mare element intr-un vector bitonic (are elemente DISTINCTE)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns>Pozitia pe care se afla elementul maxim</returns>
        private static int searchMax(int[] arr, int lo, int hi)
        {
            if (lo == hi)
                return lo;
            else
            {
                int mid = lo + (hi - lo) / 2;
                if (arr[mid] < arr[mid + 1])
                    return searchMax(arr, mid + 1, hi);
                else
                    return searchMax(arr, lo, mid - 1);
            }
        }

        static void Main(string[] args)
        {
            int[] arr = { -3, 2, 5, 4 };
            Array.Sort(arr);

            int key = 7;
            
            //Console.WriteLine("Valoarea {0} se afla in tabloul sortat pe pozitia: {1}", key, rank(key, arr));

            //Console.WriteLine("Valoarea {0} se afla in tabloul sortat pe pozitia: {1}", key, rankRec(key, arr));

            int[] arr2 = {  3, 3, 3, 3, 4, 5, 6};
            Array.Sort(arr2);
            Console.WriteLine("Numarul de numere mai mici decat {0} = {1}", key, lessThanKey(key, arr2));
            Console.WriteLine("Numarul de numere mai mari decat {0} = {1}", key, greaterThanKey(key, arr2));


            int[] arrBitonic = { 1, 2, 3, 4, 5, 6, 4, 2, 0, -2, -4, -6 };
            key = 0;
            int poz = 0;
            if ((poz = bitonic_search(key, arrBitonic)) == -1)
            {
                Console.WriteLine("{0} nu se afla in vectorul bitonic", key);
            }
            else
            {
                Console.WriteLine("{0} se afla in vectorul bitonic pe pozitia {1}", key, poz);
            }
        }
    }
}
