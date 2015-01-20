using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class StackLLClient
    {
        static void Main(string[] args)
        {
            StackLL<string> sll = new StackLL<string>();
            string line = "to be or not to be";
            string[] tokens = line.Split(' ');

            foreach (var item in tokens)
	        {
                sll.push(item);
	        }

            //while (!sll.isEmpty())
            //{
            //    Console.WriteLine(sll.pop());
            //}

            foreach (var item in sll)
            {
                Console.WriteLine(item);
            }
        }
        
    }
}
