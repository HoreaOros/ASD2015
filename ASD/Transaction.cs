using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ASD
{
    class Transaction: IComparable<Transaction>
    {
        private string nume;
        private Date data;
        private double suma;

        public static SumaOrder SUMA_ORDER = new SumaOrder();

        public Transaction(string nume, Date data, double suma)
        {
            this.nume = nume;
            this.data = data;
            this.suma = suma;
        }
        public Transaction(string transaction)
        {
            string[] tokens = transaction.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            nume = tokens[0];
            data = new Date(tokens[1]);
            suma = double.Parse(tokens[2], CultureInfo.InvariantCulture);
        }
        public string Nume
        {
            get
            {
                return nume;
            }
            
        }
        public Date Data
        {
            get
            {
                return data;
            }
        }
        public double Suma
        {
            get
            {
                return suma;
            }
        }
        public override string ToString()
        {
            return string.Format("{0,-20} {1,10} {2,10:F2}", nume, data, suma);
        }


       

        public int CompareTo(Transaction other)
        {
            if (this.suma < other.suma)
                return -1;
            else if (this.suma > other.suma)
                return 1;
            else
                return 0;
        }
        public override bool Equals(object x)
        {
            if (x == this) 
                return true;

            if (x == null) 
                return false;

            if (x.GetType() != this.GetType()) 
                return false;

            Transaction that = (Transaction)x;

            return (this.suma == that.suma) && (this.nume.Equals(that.nume)) && (this.data.Equals(that.data));
        }
        public override int GetHashCode()
        {
            int hash = 17;
            hash = 31 * hash + nume.GetHashCode();
            hash = 31 * hash + data.GetHashCode();
            hash = 31 * hash + ((Double)suma).GetHashCode(); ;
            return hash;
        }
        public class NumeOrder: IComparer<Transaction>
        {
            public int Compare(Transaction x, Transaction y)
            {
                return x.nume.CompareTo(y.nume);
            }
        }
        public class DataOrder: IComparer<Transaction>
        {
            public int Compare(Transaction x, Transaction y)
            {
                return x.data.CompareTo(y.data);
            }
        }
        public class SumaOrder: IComparer<Transaction>
        {
            public int Compare(Transaction x, Transaction y)
            {
                return x.suma.CompareTo(y.suma);
            }
        }
        public static void Main(string[] args)
        {
            Transaction[] a = new Transaction[4];
            a[0] = new Transaction("Turing   6/17/1990  644.08");
            a[1] = new Transaction("Tarjan   3/26/2002 4121.85");
            a[2] = new Transaction("Knuth    6/14/1999  288.34");
            a[3] = new Transaction("Dijkstra 8/22/2007 2678.40");

            Console.WriteLine("Nesortat");
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sortat dupa data");
            Array.Sort(a, new Transaction.DataOrder());
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sortat dupa nume");
            Array.Sort(a, new Transaction.NumeOrder());
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Sortat dupa suma");
            Array.Sort(a, Transaction.SUMA_ORDER);
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }

        }
    }
}
