using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class Edge<T> where T : IComparable
    {
        string vertexId;

        public string VertexId
        {
            get { return vertexId; }
            set { vertexId = value; }
        }
        T weight;

        public T Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        Edge<T> next;

        internal Edge<T> Next
        {
            get { return next; }
            set { next = value; }
        }

        public Edge(string id, T w)
        {
            vertexId = id;
            weight = w;
        }



        public override string ToString()
        {
            return vertexId + " " + weight.ToString();
        }
        internal int AllCompareTo(Edge<T> edg)
        {
            if (this.vertexId.CompareTo(edg.vertexId) == 0)
            {
                if (this.weight.CompareTo(edg.weight) == 0)
                    if (this.Next.vertexId.CompareTo(edg.Next.vertexId) == 0)
                        return 0;
            }
            return -1;
        }
        internal int VCompareTo(Edge<T> edg)
        {
            if (this.vertexId.CompareTo(edg.vertexId) == 0)
                return 0;
            else return -1;
        }

        internal int WCompareTo(Edge<T> edg)
        {
            if (this.weight.CompareTo(edg.weight) == 0)
                return 0;
            else return -1;
        }
    }
}
