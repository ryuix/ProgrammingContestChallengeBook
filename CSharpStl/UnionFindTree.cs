using System;
using System.Linq;

namespace CSharpStl
{
    public class UnionFindTree
    {
        int[] parent;
        int[] rank;

        public UnionFindTree(int size)
        {
            parent = new int[size];
            rank = new int[size];

            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] == x)
            {
                return x;
            }
            else
            {
                return parent[x] = Find(parent[x]);
            }
        }

        public void Unite(int x, int y)
        {
            (x, y) = (Find(x), Find(y));
            if (x == y) return;

            if (rank[x] < rank[y])
            {
                parent[x] = y;
            }
            else
            {
                parent[y] = x;
                if (rank[x] == rank[y]) rank[x]++;
            }
        }

        public bool IsSame(int x, int y)
        {
            return Find(x) == Find(y);
        }
    }
}
