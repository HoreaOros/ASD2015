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
            /*
            data[right] = item;
            if (right == capacity - 1)
            {
                
                right = 0;
            }
            else
            {
                right += 1;
            }
             */
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
            if (left < right)
                return data[left++];
            else
                throw new QueueEmptyException();
        }
        /// <summary>
        /// Este goala coada?
        /// </summary>
        /// <returns></returns>
        public Item dequeue()
        {
            /*
            Item x = data[left];
            if (left == capacity - 1)
                left = 0;
            else
                left += 1;

            return x;
             */
            Item x;
            if (left == right)
                throw new QueueEmptyException();
            else
                x = data[left];
            left = nextPoz(left);
            return x;
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
        public static void Main(string[] args)
        {
            Queue<Date> queue = new Queue<Date>();
            queue.enqueue(new Date(31, 12, 1999));

            Date next = queue.dequeue();
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
