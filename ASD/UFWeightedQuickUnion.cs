using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ASD
{
    /// <summary>
    /// Rezolvare logaritmica pentru UF
    /// </summary>
    class UFWeightedQuickUnion
    {
        private int[] id;
        private int[] sz;
        private int componentNo;
        /// <summary>
        /// Initializare
        /// </summary>
        /// <param name="n"></param>
        public UFWeightedQuickUnion(int n)
        {
            id = new int[n];
            sz = new int[n];
            componentNo = n;
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
                


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
                if(sz[pRoot] < sz[qRoot])
                {
                    id[pRoot] = qRoot;
                    sz[qRoot] += sz[pRoot];
                }
                else
                {
                    id[qRoot] = pRoot;
                    sz[pRoot] += sz[qRoot];
                }

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

                UFWeightedQuickUnion uf = new UFWeightedQuickUnion(N);

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] tokens = line.Split(' ');
                    p = int.Parse(tokens[0]);
                    q = int.Parse(tokens[1]);

                    if (uf.connected(p, q))
                        continue;

                    uf.union(p, q);
                    //Console.WriteLine("{0} - {1}", p, q);
                }

                Console.WriteLine("{0} componente", uf.count());
        }
    }
}
