using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    static class Stuff
    {
        // ce face aceasta functie?
        public static int mystery(int a, int b)
        {
            if (b == 0) 
                return 0;
            if (b % 2 == 0) 
                return mystery(a + a, b / 2);
            else
                return mystery(a + a, b / 2) + a;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(mystery(5, 25));
        }
    }
}
