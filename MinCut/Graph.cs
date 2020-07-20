using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCut
{
    public class Graph
    {
        private readonly int _vertices;
        private readonly int _numOfEdges;
        private readonly Random _random = new Random();

        public int cuts = 0;
        public List<int> contractedVertices= new List<int>();
        public Subset[] subsets;
        public List<Edge> edges { get; set; }
        public Graph(List<Edge> e , int vertices )
        {
            edges = e;
            _numOfEdges = e.Count;
            _vertices = vertices;
            subsets = new Subset[_vertices];
        }

        public Graph(List<Edge> e, int vertices , Subset[] s)
        {
            edges = e;
            _numOfEdges = e.Count;
            _vertices = vertices;
            subsets = s;
        }

        public int MinCut()
        {
            
            for (int i = 0; i < _vertices; i++)
            {
                subsets[i] = new Subset();
                subsets[i].parent = i;
                subsets[i].rank = 0;
            }

            int v = _vertices;
            while (v > 2)
            {

                // Pick a random edge 
                int i = _random.Next(0 , _numOfEdges - 1);

                int subset1 = Find(subsets, edges[i].Src );
                int subset2 = Find(subsets, edges[i].Dest);

                if (subset1 == subset2)
                    continue;
                else
                {
                    if (!contractedVertices.Contains(edges[i].Src))
                        contractedVertices.Add(edges[i].Src);
 
                    if (!contractedVertices.Contains(edges[i].Dest))
                        contractedVertices.Add(edges[i].Dest);

                    v--;
                    Union(subsets, subset1, subset2);
                }
            }

            for (int i = 0; i < _numOfEdges; i++)
            {
                int subset1 = Find(subsets, edges[i].Src);
                int subset2 = Find(subsets, edges[i].Dest);

                if (subset1 != subset2)
                {
                    cuts++;
                }
            }

            return cuts;
        }

        private int Find(Subset[] subsets , int i)
        {
            if (subsets[i].parent != i)
                subsets[i].parent = Find(subsets, subsets[i].parent);

            return subsets[i].parent;
        }

        private void Union(Subset[] subsets , int x , int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (subsets[xroot].rank < subsets[yroot].rank)
                subsets[xroot].parent = yroot;

            else if (subsets[xroot].rank > subsets[yroot].rank)
                subsets[yroot].parent = xroot;

            else
            {
                subsets[yroot].parent = xroot;
                subsets[xroot].rank++;
            }
        }
    }
}
