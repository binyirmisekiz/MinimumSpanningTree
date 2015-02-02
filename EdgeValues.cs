using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{

    class EdgeValues<T> :IComparable 
    {
        public string startId, endId;
        public T weight;

        public EdgeValues(string startId, string endId, T weight)
        {

            this.startId = startId;
            this.endId = endId;
            this.weight = weight;


        }
        public override string ToString()
        {
            return startId + " " + endId + " " + weight.ToString();
        }
        public int CompareTo(object obj)
        {
            var o=  ((EdgeValues<T>)obj);
            return ((IComparable)this.weight).CompareTo(o.weight);
        }
    }
}
