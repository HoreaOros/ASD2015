using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class StackFullException : System.Exception
    {
    }

    class StackEmptyException : System.Exception
    {
    }
    class NoSuchElementException : System.Exception
    {
        public NoSuchElementException()
        {

        }
        public NoSuchElementException(string s)
        {

        }
    }

    class NullPointerException : System.Exception
    {
        public NullPointerException()
        {

        }
        public NullPointerException(string s)
        {

        }
    }
}
