using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Stiva implementata cu o lista inlantuita
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class StackLL<Item>: IEnumerable<Item>
    {
        Node first = null;
        int count = 0;
        /// <summary>
        /// Clasa incuibata pentru reprezentarea unui nod al listei inlantuite
        /// </summary>
        private class Node
        {
            public Item item;
            public Node next;
        }
        public StackLL()
        {
            
        }
        /// <summary>
        /// Adauga un nou element in stiva
        /// </summary>
        /// <param name="item"></param>
        public void push(Item item)
        {
            Node p = new Node();
            p.item = item;
            p.next = first;
            first = p;
            count++;
        }
        /// <summary>
        /// Elimina un element din stiva
        /// </summary>
        /// <returns></returns>
        public Item pop()
        {
            if(!isEmpty())
            {
                Node temp = first;
                first = first.next;
                count--;
                return temp.item;
            }
            else
                throw new StackEmptyException();
        }

        /// <summary>
        /// Verifica daca stiva e goala
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return first == null; // sau count == 0;
        }
        /// <summary>
        /// Numarul de elemente din stiva
        /// </summary>
        /// <returns></returns>
        public int size()
        {
            return count;
        }

        public IEnumerator<Item> GetEnumerator()
        {
            Node p = first;
            while (p != null)
            {
                yield return p.item;
                p = p.next;
            }    
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
