using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    // se da un vector de numere intregi distincte arr
    // in acest vector trebuie gasit un minim local (cu un algoritm logaritmic)
    // arr[i] este minim local daca arr[i] < arr[i - 1] si arr[i] < arr[i + 1] (este mai mic decat ambii vecini)
    // daca arr[i] este la unul din cele doua capete ale vectorului el este minim local daca e mai mic decat singurul vecin pe care il are.
    class MinimLocal
    {
        public static int MinimLocalV(int[] arr, int lo, int hi)
        {
            if (lo == hi)
            {
                return arr[lo];
            }
            else if(lo == hi - 1)
            {
                return Math.Min(arr[lo], arr[hi]);
            }
            else
            {
                int mid = lo + (hi - lo) / 2;
                if (arr[mid] < arr[mid + 1] && arr[mid] < arr[mid - 1])
                    return arr[mid];
                else if (arr[mid - 1] < arr[mid])
                    return MinimLocalV(arr, lo, mid - 1);
                else
                    return MinimLocalV(arr, mid + 1, hi);
            }
        }
        // se da o matrice patratica de numere intregi distincte arr
        // in acesta matrice trebuie gasit un minim local (cu un algoritm liniar)
        // arr[i, j] este minim local daca este mai mic decat toti vecinii:
        // arr[i, j] < arr[i - 1, j]
        // arr[i, j] < arr[i + 1, j]
        // arr[i, j] < arr[i, j - 1]
        // arr[i, j] < arr[i, j + 1]
        // daca arr[i, j] este pe marginea matricii atunci el va avea doar 2 sau 3 vecini.
        // http://courses.csail.mit.edu/6.006/spring11/lectures/lec02.pdf
        public static int MinimLocalM(int[,] arr, int loRow, int loCol, int hiRow, int hiCol)
        {
            if (loCol == hiCol && loRow == hiRow)
                return arr[loCol, loRow];
            else 
            {
                int midRow = loRow + (hiRow - loRow) / 2;
                int midCol = loCol + (hiCol - loCol) / 2;
                int minim = arr[midRow, midCol];
                int i, j, imin = midRow, jmin = midCol;
                //determin cel mai mic numar de pe chenar + linia din mijloc si coloana din mijloc
                for (i = loRow; i <= hiRow; i++)
                {
                    if (arr[i, loCol] < minim)
                    {
                        minim = arr[i, loCol];
                        imin = i; jmin = loCol;
                    }
                        
                    if (arr[i, midCol] < minim)
                    {
                        minim = arr[i, midCol];
                        imin = i; jmin = midCol;
                    }
                        
                    if (arr[i, hiCol] < minim)
                    {
                        minim = arr[i, hiCol];
                        imin = i; jmin = hiCol;
                    }
                        
                }
                for (j = loCol; j <= hiCol; j++)
                {
                    if (arr[loRow, j] < minim)
                    {
                        minim = arr[loRow, j];
                        imin = loRow; jmin = j;
                    }
                        
                    if (arr[midRow, j] < minim)
                    {
                        minim = arr[midRow, j];
                        imin = midRow; jmin = j;
                    }

                        
                    if (arr[hiRow, j] < minim)
                    {
                        minim = arr[hiRow, j];
                        imin = hiRow; jmin = j;
                    }
                        
                }
                // verific daca arr[imin, jmin] e minim local si daca e il returnez

                // adaug toti vecinii intr-o lista pe care o sortez. Cel mai mic vecin va fi primul vecini[0]
                List<int> vecini = new List<int>();
                if (imin - 1 >= loRow)
                    vecini.Add(arr[imin - 1, jmin]);
                if (imin + 1 <= hiRow)
                    vecini.Add(arr[imin + 1, jmin]);
                if (jmin - 1 >= loCol)
                    vecini.Add(arr[imin, jmin - 1]);
                if (jmin + 1 <= hiCol)
                    vecini.Add(arr[imin, jmin + 1]);

                vecini.Sort();

                if (arr[imin, jmin] < vecini[0])
                    return arr[imin, jmin];


                    // caut un vecin mai mic si intru in cadranul in care e acel vecin inclusiv marginea cadranului in care am cautat 
                if (imin - 1 >= loRow && arr[imin, jmin] > arr[imin - 1, jmin])
                    if (jmin <= midCol)
                        return MinimLocalM(arr, loRow, loCol, midRow, midCol);
                    else
                        return MinimLocalM(arr, loRow, midCol, midRow, hiCol);

                if (imin + 1 <= hiRow && arr[imin, jmin] > arr[imin + 1, jmin])
                    if (jmin <= midCol)
                        return MinimLocalM(arr, midRow, loCol, hiRow, midCol);
                    else
                        return MinimLocalM(arr, midRow, midCol, hiRow, hiCol);

                if (jmin - 1 >= loCol && arr[imin, jmin] > arr[imin, jmin - 1])
                    if (imin <= midRow)
                        return MinimLocalM(arr, loRow, loCol, midRow, midCol);
                    else
                        return MinimLocalM(arr, midRow, loCol, hiRow, midCol);
                 
                if (jmin + 1 <= hiCol && arr[imin, jmin] > arr[imin, jmin + 1])
                    if (imin <= midRow)
                        return MinimLocalM(arr, loRow, midCol, midRow, hiCol);
                    else
                        return MinimLocalM(arr, midRow, midCol, hiRow, hiCol);
                return 0;
             }

        }
        public static void Main()
        {
            // int[] arr = { 15, 13, 12, 18, 19, 20, 7, 6, 5, 4, 3, 2, 1 };
            int[] arr = { 9, 7, 2, 8, 5, 6, 3, 4, 2 };
            Console.WriteLine("Minim local in vector = {0}", MinimLocalV(arr, 0, arr.Length - 1));

            int[,] arr2 = {
                          {10, 10, 10, 10, 10, 10, 10, 10, 10}, 
                          {10, 9, 3, 5, 2, 4, 9, 8, 10}, 
                          {10, 7, 2, 5, 1, 4, 10, 3, 10}, 
                          {10, 9, 8, 9, 3, 2, 4, 8, 10}, 
                          {10, 7, 6, 3, 1, 3, 2, 3, 10}, 
                          {10, 9, 10, 6, 10, 4, 6, 4, 10}, 
                          {10, 8, 9, 8, 10, 5, 3, 10, 10}, 
                          {10, 2, 1, 2, 1, 1, 1, 1, 10}, 
                          {10, 10, 10, 10, 10, 10, 10, 10, 10}
                          };
            Console.WriteLine("Minim local in matrice = {0}", MinimLocalM(arr2, 0, 0, arr2.GetLength(0) - 1, arr2.GetLength(1) - 1));
        }
    }
}
