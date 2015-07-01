using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class ResizingQueue<Item>: IEnumerable<Item>
    {
        private Item[] data;
        private int capacity = 32;
        private int left = 0, right = 0;
        /// <summary>
        /// Crearea unei cozi fara nici un element
        /// </summary>
        public ResizingQueue()
        {
            data = new Item[capacity];
        }
        public ResizingQueue(int capacity)
        {
            this.capacity = capacity;
            data = new Item[capacity];
        }
        /// <summary>
        /// Redimensionare Bag
        /// </summary>
        /// <param name="max">Noua dimensiune a bag-lui</param>
        private void resize(int max)
        {
            Item[] temp = new Item[max];
            for (int i = left; i < right; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
            this.capacity = max;
        }
        /// <summary>
        /// Adaugarea unui element in coada
        /// </summary>
        /// <param name="item">Elementul ce se adauga</param>
        public void enqueue(Item item)
        {
            if (right == capacity)
                resize(2 * capacity);

            data[right++] = item;

        }
        /// <summary>
        /// Eliminarea elementului care a fost adaugat cel mai demult
        /// </summary>
        /// <returns></returns>
        public Item dequeue()
        {
            if (right == capacity / 4)
            {
                resize(capacity / 2);
            }
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
