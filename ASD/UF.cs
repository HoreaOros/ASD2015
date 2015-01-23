using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ASD
{
    /// <summary>
    /// Union Find - Quick Find
    /// </summary>
    class UF
    {
        private int[] id;
        private int componentNo;
        /// <summary>
        /// Initializare
        /// </summary>
        /// <param name="n"></param>
        public UF(int n)
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
            int pId = find(p);
            int qId = find(q);

            if (pId == qId)
                return;

            for (int i = 0; i < id.Length; i++)
                if (id[i] == pId)
                    id[i] = qId;

            componentNo--;

        }
        /// <summary>
        /// Determina componenta in care se afla p
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int find(int p)
        {
            return id[p];
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
            StreamReader sr = new StreamReader("tinyUF.txt");
            string line;

            int N, p, q;
            line = sr.ReadLine();
            N = int.Parse(line);

            UF uf = new UF(N);

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] tokens = line.Split(' ');
                p = int.Parse(tokens[0]);
                q = int.Parse(tokens[1]);

                if (uf.connected(p, q))
                    continue;

                uf.union(p, q);
                Console.WriteLine("{0} - {1}", p, q);
            }

            Console.WriteLine("{0} componente", uf.count());
        }
    }
}
