using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Un tip abstract de date pentru contorizare
    /// </summary>
    class Counter
    {
        private String id;
        private int count;
        public Counter(string id)
        {
            this.id = id;
            count = 0;
        }
        public void increment()
        {
            count++;
        }
        public int Count
        {
            get 
            {
                return count;
            }
        }
        public override string ToString()
        {
            return count + " " + id;
        }
        public static void Main(string[] args)
        {
            Counter heads = new Counter("heads");
            Counter tails = new Counter("tails");

            heads.increment();
            heads.increment();
            tails.increment();

            Console.WriteLine(heads);
            Console.WriteLine(tails);

            Console.WriteLine("Numar total de contorizari: {0}", heads.Count + tails.Count);
        }
    }
}
