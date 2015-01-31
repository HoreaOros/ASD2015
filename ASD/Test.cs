using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{

    class Test
    {
        public static void f(IComparable p)
        {
            Console.WriteLine(p);
        }
        public static void Main(string[] args)
        {
            string s = "abc";
            double d = 3.14;

            f(s);
            f(d);

            string[] sa = { "abd", "def" };
            double[] da = { 1, 2, 3 };

            fa(sa);
            fa(da);
        }

        private static void fa(IComparable[] da)
        {
            foreach (var item in da)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
