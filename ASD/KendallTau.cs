using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Se dau doua permutari ale numerelor de la 0 la N-1.
    /// Distanta Kendall tau dintre cele doua permutari = numarul de perechi care sunt in ordine diferita in cele doua permutari
    /// Ex. P1 = {0, 3, 1, 6, 2, 5, 4} si P2 = {1, 0, 3, 6, 4, 2, 5} Distanta Kendall tau este 4 pentru ca perechile
    /// care nu sunt in aceeasi ordine sunt (0, 1), (3, 1), (2, 4), (5, 4)
    /// </summary>
    class KendallTau
    {
        public static void Main(string[] args)
        {
            int[] L1 = { 0, 3, 1, 6, 2, 5, 4 };
            int[] L2 = { 1, 0, 3, 6, 4, 2, 5 };

            int[] L2inv = Inverse(L2);

            Console.WriteLine("Kendall tau distance = {0}", KendallTauDistance(L1, L2inv));
        }

        private static int KendallTauDistance(int[] L1, int[] L2inv)
        {
            int count = 0;
            int i, j, aux;

            for(i = 0; i < L1.Length; i++)
                for(j = i + 1; j < L1.Length; j++)
                    if (L2inv[L1[i]] > L2inv[L1[j]])
                    {
                        aux = L1[i];
                        L1[i] = L1[j];
                        L1[j] = aux;
                        count++;
                    }
            return count;
        }

        private static int[] Inverse(int[] L2)
        {
            int[] aux = new int[L2.Length];

            for (int i = 0; i < L2.Length; i++)
                aux[L2[i]] = i;

            return aux;
        }
    }
}
