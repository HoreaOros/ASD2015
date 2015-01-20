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
        // ce face aceasta functie?
        public static String mystery2(String s)
        {
            int N = s.Length;
            
            if (N <= 1) 
                return s;

            String a = s.Substring(0, N / 2);
            String b = s.Substring(N / 2);
            
            return mystery2(b) + mystery2(a);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(mystery(5, 25));
            Console.WriteLine(mystery2("abcd"));
        }
    }
}
