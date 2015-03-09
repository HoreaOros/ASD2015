using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Coada FIFO de dimensiune fixa
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class Queue<Item>: IEnumerable<Item>
    {
        private Item[] data;
        private int capacity = 32;
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
        int nextPoz(int index)
        {
            if (index < capacity - 1)
                return index + 1;
            else
                return 0;
        }
        /// <summary>
        /// Adaugarea unui element in coada
        /// </summary>
        /// <param name="item">Elementul ce se adauga</param>
        public void enqueue(Item item)
        {
            if (left == nextPoz(right))
                throw new QueueFullException();
            else
                data[right] = item;
            right = nextPoz(right);

         } 
        /// <summary>
        /// Eliminarea elementului care a fost adaugat cel mai demult
        /// </summary>
        /// <returns></returns>
        public Item dequeue()
        {
            Item x;
            if (left == right)
                throw new QueueEmptyException();
            else
                x = data[left];
            left = nextPoz(left);
            return x;
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
            if(left<right)
            return right - left;
            else
            return left-right;
        }
        public IEnumerator<Item> GetEnumerator()
        {
            if (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    yield return data[i];
                }
            }
            else
            {
                for (int j = 0; j < right; j++)
                    yield return data[j];
                for (int i = left; i < capacity; i++)
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
