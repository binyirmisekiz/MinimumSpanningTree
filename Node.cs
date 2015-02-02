using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class Node<T> where T : IComparable
    {
        public T value;
        public Node<T> next;

        public Node(T val)
        {
            value = val;
            next = null;

        }

        public string toString()
        {
            return value.ToString();
        }

    }
}
