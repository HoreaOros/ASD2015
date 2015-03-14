using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD
{
    /// <summary>
    /// Tabela de simboluri implementata cu o lista simplu inlantuita si cautare liniara 
    /// </summary>
    /// <typeparam name="Key">Tipul cheii</typeparam>
    /// <typeparam name="Value">Tipul valorii</typeparam>
    class ST<Key, Value>
    {
        private int N; // numarul de perechi (cheie, valoare) din colectie
        private Node first; // lista inalantuita de perechi (cheie, valoare)
        /// <summary>
        /// Clasa ajutatoare pentru implementarea listei inlantuite
        /// </summary>
        private class Node
        {
            public Key key;
            public Value val;
            public Node next;

            public Node(Key key, Value val, Node next)
            {
                this.key = key;
                this.val = val;
                this.next = next;
            }
        }
        public ST() // crearea unei tabele de simboluri
        {
            N = 0;
            first = null;
        }
        public void put(Key key, Value value) // adaugarea unei perechi (cheie, valoare) in tabela; eliminarea cheii daca value este null
        {
            if (value == null)
            {
                delete(key);
                return;
            }
            for (Node x = first; x != null; x = x.next)
                if (key.Equals(x.key)) 
                { 
                    x.val = value; 
                    return; 
                }
            first = new Node(key, value, first);
            N++;
        }
        public Value get(Key key) // obtine valoarea asociata cheii; daca in tabela nu exista cheia se intoarce null
        {
            for (Node x = first; x != null ; x = x.next)
            {
                if (key.Equals(x.key))
                    return x.val;
            }
            return default(Value);
        }
        public void delete(Key key) // sterge din tabela cheia (si valoarea asociata)
        {
            first = delete(first, key);
        }
        private Node delete(Node x, Key key)
        {
            if (x == null) 
                return null;
            if (key.Equals(x.key)) 
            { 
                N--; 
                return x.next; 
            }
            x.next = delete(x.next, key);
            return x;
        }
        public bool contains(Key key) // exista in tabela o valoare asociata cheii?
        {
            return get(key) != null;
        }
        public bool isEmpty() //  tabela este goala?    
        {
            return size() == 0;
        }
        public int size() // numarul de perechi (cheie, valoare) din tabela
        {
            return N;
        }
        public IEnumerable<Key> keys() // toate cheile din tabela
        {
            Queue<Key> queue = new Queue<Key>();
            
            for (Node x = first; x != null; x = x.next)
                queue.enqueue(x.key);
            
            return queue;
        }
    }
}
