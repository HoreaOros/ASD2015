using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASD
{
    public class Date: IComparable<Date>
    {
        private int zi, luna, an;
        public Date(int zi, int luna, int an)
        {
            this.zi = zi;
            this.luna = luna;
            this.an = an;
        }
        public int Zi
        {
            get
            {
                return zi;
            }
        }
        public int Luna
        {
            get
            {
                return luna;
            }
        }
        public int An
        {
            get
            {
                return an;
            }
        }
        public override string ToString()
        {
            return zi + "/" + luna + "/" + an;
        }
        public static void Main(string[] args)
        {

        }

        public int CompareTo(Date other)
        {
            if (other == null)
                return 1;
            if (this.an < other.an)
                return -1;
            else if (this.an > other.an)
                return 1;
            else if (this.luna < other.luna)
                return -1;
            else if (this.luna > other.luna)
                return 1;
            else if (this.zi < other.zi)
                return -1;
            else if (this.zi > other.zi)
                return 1;
            else
                return 0;
        }
    }
}
