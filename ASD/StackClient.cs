﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class StackClient
    {
        public static void Main(string[] args)
        {
            Stack<int> st = new Stack<int>(3);

            for (int i = 0; i < 10; i++)
                st.push(i);

            while (!st.isEmpty())
            {
                Console.WriteLine(st.pop());
            }


            IStack<int> intStack = new Stack<int>(10);

            intStack = new StackLL<int>();
        }
    }
}
