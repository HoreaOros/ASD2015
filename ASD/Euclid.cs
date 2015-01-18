using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    static class Euclid
    {
        /// <summary>
        /// Algoitmul lui Euclid extins care determina cmmdc a doua numere a si b si doua numere x si y cu proprietatea ax + by = d
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="d">Cel mai mare divizor comun</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void euclidExtins(int a, int b, out int d, out int x, out int y)
        {
            if (b == 0)
            {
                d = a;
                x = 1;
                y = 0;
            }
            else
            {
                int x0, y0;
                euclidExtins(b, a % b, out d, out x0, out y0);
                x = y0;
                y = x0 - (a / b) * y0;
            }
        }
        /// <summary>
        /// Cel mai mare divizor comun a doua numere pozitive
        /// </summary>
        /// <param name="a">prima valoarea</param>
        /// <param name="b">a doua valoare</param>
        /// <returns>cel mai mare divizor comun</returns>
        public static int cmmdc(int a, int b)
        {
            if (b == 0)
                return a;
            else
                return cmmdc(b, a % b);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(cmmdc(6, 9));

            int a = 8, b = 20, d, x, y;
            euclidExtins(a, b, out d, out x, out y);

            Console.WriteLine("{0}*{1}+{2}*{3}={4}", a, x, b, y, d);
        }
    }
}
