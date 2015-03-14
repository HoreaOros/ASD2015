using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Stiva LIFO de dimensiune variabila
    /// Datele se pastreaza intr-un tablou pe care il redimensionam cand e plin sau cand e "destul de gol"
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    public class ResizingStack<Item> : IEnumerable<Item>
    {
        private Item[] data;
        private int count = 0;
        private int capacity = 32;
        /// <summary>
        /// Crearea unei stive fara nici un element
        /// </summary>
        public ResizingStack()
        {
            data = new Item[capacity];
        }
        public ResizingStack(int capacity)
        {
            this.capacity = capacity;
            data = new Item[capacity];
        }
        private void resize(int max)
        {
            Item[] temp = new Item[max];
            for(int i = 0; i < count; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
            //this.capacity = max;
        }
        /// <summary>
        /// Adaugarea unui element in stiva
        /// </summary>
        /// <param name="item"></param>
        public void push(Item item)
        {
            if (count == capacity)
            {
                resize(2 * capacity);
                capacity = 2 * capacity; // capacity <<= 1;
            }
            data[count++] = item;
        }
        /// <summary>
        /// Eliminarea ultimului elementului adaugat
        /// </summary>
        /// <returns></returns>
        public Item pop()
        {
            Item item;
            if (!isEmpty())
            {
                item =  data[--count];
                data[count] = default(Item); // valoarea va fi facuta null pentru ca garbage collectorul sa poate recupera memoria
                if (count == capacity / 4)
                {
                    resize(capacity / 2);
                    capacity /= 2;
                }
                    
                return item;
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
            for (int i = count - 1; i >= 0; i++)
            {
                yield return data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //class StackFullException : System.Exception
    //{
    //}

    
}
