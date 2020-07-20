using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinCut
{
    public class Edge
    {
        public int Src { get; set; }
        public int Dest { get; set; }

        public Edge(int src , int dest)
        {
            Src = src;
            Dest = dest;
        }
        
    }
}
