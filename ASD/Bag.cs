using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Bag de dimensiune fixa
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    public class Bag<Item>: IEnumerable<Item>
    {
        private Item[] data;
        private int count = 0;
        private int capacity = 32;
        /// <summary>
        /// Crearea unui Bag fara nici un element
        /// </summary>
        public Bag()
        {
            data = new Item[capacity];
        }
        public Bag(int capacity)
        {
            this.capacity = capacity;
            data = new Item[capacity];
        }
        /// <summary>
        /// Adaugarea unui element
        /// </summary>
        /// <param name="item"></param>
        public void add(Item item)
        {
            if (count < capacity - 1)
            {
                data[count++] = item;
            }
            else
                Console.WriteLine("Bag full. No more space for new items.");
        }
        /// <summary>
        /// Este gol?
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return count == 0;
        }
        /// <summary>
        /// Numarul de elemente din Bag
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return count;
        }
        
        public IEnumerator<Item> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
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
