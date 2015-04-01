using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class STTestClient
    {
        static void Main(string[] args)
        {
            BinarySearchST<String, int?> st = new BinarySearchST<String, int?>();
            String key = Console.ReadLine();
            for (int i = 0; key != null; i++)
            {
                st.put(key, i);
                key = Console.ReadLine();
            }
            foreach (var item in st.Keys())
            {
                Console.WriteLine("{0} {1}", item, st.get(item));
            }
        }
    }
}
