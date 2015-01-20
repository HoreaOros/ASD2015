using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vector = { -1, 2, -3, 5, 6,  -3, 7};

            Console.WriteLine("Maximum Subarray Brut: {0}", MaximumSubarray.MaximumSubarrayBrut(vector));
            Console.WriteLine("Maximum Subarray Liniar: {0}", MaximumSubarray.MaximumSubArrayLiniar(vector));
        }
    }
}
