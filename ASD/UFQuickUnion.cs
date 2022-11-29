using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ASD
{
    /// <summary>
    /// Se va genera un vector de tati pentru reprezentarea unei paduri de arbori. 
    /// Daca doua elemente sunt in acelasi arbore (componenta conexa) atunci ele sunt conectate
    /// </summary>
    class UFQuickUnion
    {
        private int[] id;
        private int componentNo;
        /// <summary>
        /// Initializare
        /// </summary>
        /// <param name="n"></param>
        public UFQuickUnion(int n)
        {
            id = new int[n];
            componentNo = n;
            for (int i = 0; i < n; i++)
                id[i] = i;
        }
        /// <summary>
        /// Stabileste o conexiune intre p si q
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void union(int p, int q)
        {
            int pRoot = find(p);
            int qRoot = find(q);

            if (pRoot != qRoot)
            {
                id[pRoot] = qRoot;
                componentNo--; // numarul de componente scade cu 1
            }
                
        }
        /// <summary>
        /// Determina componenta in care se afla p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int find(int p)
        {
            while (p != id[p])
                p = id[p];

            return p;
        }
        /// <summary>
        /// Determina daca p si q sunt conectate
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool connected(int p, int q)
        {
            return find(p) == find(q);
        }
        /// <summary>
        /// Determina numarul de componente conexe
        /// </summary>
        /// <returns></returns>
        public int count()
        {
            return componentNo;
        }
        public static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("largeUF.txt");
            string line;

            int N, p, q;
            line = sr.ReadLine();
            N = int.Parse(line);
            int procent = 0;
            UFQuickUnion uf = new UFQuickUnion(N);
            int contor = 0;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] tokens = line.Split(' ');
                p = int.Parse(tokens[0]);
                q = int.Parse(tokens[1]);

                contor++;
                
                if (contor % 20000 == 0)
                {
                    ++procent;
                    Console.WriteLine($"{procent}%");
                }
                if (uf.connected(p, q))
                    continue;

                uf.union(p, q);
                //Console.WriteLine("{0} - {1}", p, q);
            }

            Console.WriteLine("{0} componente", uf.count());
        }
    }
}
