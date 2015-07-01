using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    class ResizingBag<Item>: IEnumerable<Item>
    {
        private Item[] data;
        private int count = 0;
        private int capacity = 25;
        /// <summary>
        /// Crearea unui Bag fara nici un element
        /// </summary>
        public ResizingBag()
        {
            data = new Item[capacity];
        }
        public ResizingBag(int capacity)
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
            for (int i = 0; i < count; i++)
            {
                temp[i] = data[i];
            }
            data = temp;
            this.capacity = max;
        }
        /// <summary>
        /// Adaugarea unui element
        /// </summary>
        /// <param name="item"></param>
        public void add(Item item)
        {
            if (count == capacity)
            {
                resize(2 * capacity);
                
            }
            else if (count == capacity / 4)
            {
                resize(capacity / 2);
            }
            data[count++] = item;
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
