using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    /// <summary>
    /// Stiva LIFO de dimensiune fixa
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    public class Stack<Item>: IEnumerable<Item>
    {
        private Item[] data;
        private int count = 0;
        private int capacity = 32;
        /// <summary>
        /// Crearea unei stive fara nici un element
        /// </summary>
        public Stack()
        {
            data = new Item[capacity];
        }
        public Stack(int capacity)
        {
            this.capacity = capacity;
            data = new Item[capacity];
        }

        /// <summary>
        /// Adaugarea unui element in stiva
        /// </summary>
        /// <param name="item"></param>
        public void push(Item item) 
        {
            if (count < capacity)
            {
                data[count++] = item;
                Debug.WriteLine(item);
            }
            else
                throw new StackFullException();
            
        }
        /// <summary>
        /// Eliminarea ultimului elementului adaugat
        /// </summary>
        /// <returns></returns>
        public Item pop() 
        {
            if (!isEmpty())
            {
                return data[--count];
            }
            else
                throw new StackEmptyException();
        }
        /// <summary>
        /// Intoarce elementul din varful stivei fara a-l elimina
        /// </summary>
        /// <returns></returns>
        public Item peek()
        {
            if (!isEmpty())
            {
                return data[count - 1];
            }
            else
                throw new StackEmptyException();
        }
        /// <summary>
        /// Este goala stiva?
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return count == 0;
        }
        /// <summary>
        /// Numarul de elemente din stiva
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return count;
        }
        public static void Main(string[] args)
        {
            Stack<String> stack = new Stack<String>();
            stack.push("Test");

            String next = stack.pop();
        }


        public IEnumerator<Item> GetEnumerator()
        {
            for (int i = count - 1; i >= 0; i--)
            {
                yield return data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

   
}
