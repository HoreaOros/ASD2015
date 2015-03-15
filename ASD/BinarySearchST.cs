using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ASD
{
    class BinarySearchST<Key, Value> where Key: IComparable<Key>
    {
        private static readonly int INIT_CAPACITY = 2;
        private Key[] keys;
        private Value[] vals;
        private int N = 0;
        /// <summary>
        /// Constructor care creeaza o tabela de simboluri cu capacitatea initiala egala cu valoarea implicita
        /// </summary>
        public BinarySearchST(): this(INIT_CAPACITY)
        { 
            
        }

        /// <summary>
        /// Constructor care creeaza o tabela de simboluri cu capacitatea initiala data
        /// </summary>
        /// <param name="capacity">Capacitatea initiala a tabelei de simboluri</param>
        public BinarySearchST(int capacity)
        {
            keys = new Key[capacity];
            vals = new Value[capacity];
        }
        /// <summary>
        /// Redimensioneaza tablourile in care se pastreaza datele
        /// </summary>
        /// <param name="capacity">Noua dimensiune</param>
        private void resize(int capacity) 
        {
            Debug.Assert(capacity >= N);

            Key[]   tempk = new Key[capacity];
            Value[] tempv = new Value[capacity];
            
            for (int i = 0; i < N; i++) 
            {
                tempk[i] = keys[i];
                tempv[i] = vals[i];
            }
            vals = tempv;
            keys = tempk;
        }
        /// <summary>
        /// Exista cheia in tabela de simboluri?
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool contains(Key key)
        {
            return get(key) != null;
        }

        /// <summary>
        /// Numarul de perechi (cheie, valoare) din colectie
        /// </summary>
        /// <returns>Dimensiunea tabelei de simboluri</returns>
        public int size()
        {
            return N;
        }

        /// <summary>
        /// Este goala tabela de simboluri
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return size() == 0;
        }
        /// <summary>
        /// Intoarce valoarea asociata unei chei sau null daca nu exista cheia in tabela
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Value get(Key key)
        {
            if (isEmpty()) 
                return default(Value);

            int i = rank(key);
            if (i < N && keys[i].CompareTo(key) == 0) 
                return vals[i];
            
            return default(Value);
        }
        
        /// <summary>
        /// Intoarce numarul de chei din tabela care sunt mai mici decat cheia data
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Numarul de chei care sunt mai mici decat key</returns>
        public int rank(Key key)
        {
            int lo = 0, hi = N - 1;
            while (lo <= hi)
            {
                int m = lo + (hi - lo) / 2;
                
                int cmp = key.CompareTo(keys[m]);
                
                if (cmp < 0) 
                    hi = m - 1;
                else if (cmp > 0) 
                    lo = m + 1;
                else 
                    return m;
            }
            return lo;
        }
        
        /// <summary>
        /// Cauta o cheie. Actualizeaza valoarea daca o gaseste; o adauga daca este o cheie noua
        /// </summary>
        /// <param name="key">Cheia</param>
        /// <param name="val">Valoarea</param>
        public void put(Key key, Value val)  
        {
            if (val == null) 
            { 
                delete(key); 
                return; 
            }

            int i = rank(key);

            // Cheia este deja in tabela
            if (i < N && keys[i].CompareTo(key) == 0) 
            {
                vals[i] = val;
                return;
            }

            // insereaza o noua pereche (cheie, valoare)
            if (N == keys.Length) 
                resize(2 * keys.Length);

            for (int j = N; j > i; j--)  
            {
                keys[j] = keys[j-1];
                vals[j] = vals[j-1];
            }
            keys[i] = key;
            vals[i] = val;
            N++;

            Debug.Assert(check());
        }

        /// <summary>
        /// Eliminam perechea (cheie, valoare) daca este prezenta
        /// </summary>
        /// <param name="key"></param>
        public void delete(Key key)  
        {
            if (isEmpty()) 
                return;

           
            int i = rank(key);

            // cheia nu este in tabela
            if (i == N || keys[i].CompareTo(key) != 0) 
            {
                return;
            }

            for (int j = i; j < N-1; j++)  
            {
                keys[j] = keys[j+1];
                vals[j] = vals[j+1];
            }

            N--;
            keys[N] = default(Key);  
            vals[N] = default(Value);

            // redimensionam daca este doar 1/4 plin
            if (N > 0 && N == keys.Length/4) 
                resize(keys.Length / 2);

            Debug.Assert(check());
        }


        /// <summary>
        /// Stergem cheia minima si valoarea asociata
        /// </summary>
        public void deleteMin()
        {
            if (isEmpty()) 
                throw new NoSuchElementException("Symbol table underflow error");
            delete(min());
        }

        /// <summary>
        /// Stergem cheia maxima si valoarea asociata
        /// </summary>
        public void deleteMax()
        {
            if (isEmpty()) 
                throw new NoSuchElementException("Symbol table underflow error");
            delete(max());
        }


        /*****************************************************************************
        *  Metode pentru tabela simbolica ordonata 
        *****************************************************************************/
        public Key min()
        {
            if (isEmpty()) 
                return default(Key);
            return keys[0];
        }

        public Key max()
        {
            if (isEmpty()) 
                return default(Key);
            return keys[N - 1];
        }

        public Key select(int k)
        {
            if (k < 0 || k >= N) 
                return default(Key);
            return keys[k];
        }

        public Key floor(Key key)
        {
            int i = rank(key);
            
            if (i < N && key.CompareTo(keys[i]) == 0) 
                return keys[i];
            
            if (i == 0) 
                return default(Key);
            else 
                return keys[i - 1];
        }

        public Key ceiling(Key key)
        {
            int i = rank(key);
            if (i == N) 
                return default(Key);
            else 
                return keys[i];
        }

        public int size(Key lo, Key hi)
        {
            if (lo.CompareTo(hi) > 0) 
                return 0;
            if (contains(hi)) 
                return rank(hi) - rank(lo) + 1;
            else 
                return rank(hi) - rank(lo);
        }

        public IEnumerable<Key> Keys()
        {
            return Keys(min(), max());
        }

        public IEnumerable<Key> Keys(Key lo, Key hi)
        {
            Queue<Key> queue = new Queue<Key>();
            
            if (lo == null && hi == null) 
                return queue;
            
            if (lo == null) 
                throw new NullPointerException("lo is null in keys()");
            
            if (hi == null) 
                throw new NullPointerException("hi is null in keys()");
            
            if (lo.CompareTo(hi) > 0) 
                return queue;
            
            for (int i = rank(lo); i < rank(hi); i++)
                queue.enqueue(keys[i]);
            
            if (contains(hi)) 
                queue.enqueue(keys[rank(hi)]);
            return queue;
        }

        /*****************************************************************************
        *  Verificam invariantii interni
        *****************************************************************************/

        private bool check()
        {
            return isSorted() && rankCheck();
        }

        // sunt ordonate itemele in tablou?
        private bool isSorted()
        {
            for (int i = 1; i < size(); i++)
                if (keys[i].CompareTo(keys[i - 1]) < 0) return false;
            return true;
        }

        // verificam daca rank(select(i)) = i
        private bool rankCheck()
        {
            for (int i = 0; i < size(); i++)
                if (i != rank(select(i))) 
                    return false;
            for (int i = 0; i < size(); i++)
                if (keys[i].CompareTo(select(rank(keys[i]))) != 0) 
                    return false;
            return true;
        }


    }
}
