using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    // TODO - implementare coada cu vectori a.i. sa folosim vectorul in mod circular.
    /// <summary>
    /// Coada FIFO de dimensiune fixa
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class Queue<Item>: IEnumerable<Item>
    {
        private Item[] data;
        private int capacity = 42;
        private int left = 0, right = 0;
        /// <summary>
        /// Crearea unei cozi fara nici un element
        /// </summary>
        public Queue()
        {
            data = new Item[capacity];
        }
        public Queue(int capacity)
        {
            this.capacity = capacity;
            data = new Item[capacity];
        }
        /// <summary>
        /// Adaugarea unui element in coada
        /// </summary>
        /// <param name="item">Elementul ce se adauga</param>
        public void enqueue(Item item)
        {
            if (right < capacity - 1)
                data[right++] = item;
            else
                throw new QueueFullException();
        }
        /// <summary>
        /// Eliminarea elementului care a fost adaugat cel mai demult
        /// </summary>
        /// <returns></returns>
        public Item dequeue()
        {
            if (left < right)
                return data[left++];
            else
                throw new QueueEmptyException();
        }
        /// <summary>
        /// Este goala coada?
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return left == right;
        }
        /// <summary>
        /// Numarul de elemente din coada
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return right - left;
        }
        public static void Main(string[] args)
        {
            Queue<Date> queue = new Queue<Date>();
            queue.enqueue(new Date(31, 12, 1999));

            Date next = queue.dequeue();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            for (int i = left; i < right; i++)
            {
                yield return data[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class QueueEmptyException : System.Exception
    {
    }

    class QueueFullException : System.Exception
    {
    }
}
