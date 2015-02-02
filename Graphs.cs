using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class Graph<T> where T : IComparable
    {
        Vertex<T> head;

        LinkedList<EdgeValues<T>> edgeList;        //kruksal algoritmasını oluşturmak için edgeleri tutacağımız liste.
        public Vertex<T> findVertex(string id)
        {
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return iterator;
                iterator = iterator.Next;
            }
            return null;
        }
        private bool onlyOneHave(string startId, string endId)
        {
            bool r = false;
            bool start = searchVertex(startId);
            bool end = searchVertex(endId);
            if (start || !end)
                r = true;
            else if (!start || end)
                r = true;

            return r;
        }

        public bool searchVertex(string id)
        {
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return true;
                iterator = iterator.Next;
            }
            return false;
        }




        public int outDegree(string id)
        {
            Vertex<T> current = findVertex(id);
            if (current != null)
            {
                int counter = 0;
                Edge<T> iterator = current.EdgeLink;
                while (iterator != null)
                {
                    counter++;
                    iterator = iterator.Next;
                }
                return counter;
            }
            return -1;
        }



        public int inDegree(string id)
        {
            Vertex<T> current = findVertex(id);

            if (current != null)
            {
                int counter = 0;

                Vertex<T> iteratorVertex = head;

                while (iteratorVertex != null)
                {
                    Edge<T> edgeIterator = iteratorVertex.EdgeLink;
                    while (edgeIterator != null)
                    {
                        if (edgeIterator.VertexId.CompareTo(id) == 0)
                            counter++;
                        edgeIterator = edgeIterator.Next;
                    }
                    iteratorVertex = iteratorVertex.Next;
                }
                return counter;
            }
            return -1;
        }

        public int[,] matris()
        {
            int vc = vertexCount();
            int[,] matris = new int[vc, vc];
            return matris;
        }

        //matris[findindex(iteratorId),findIndex(edgeId)]
        public int findIndex(string id)
        {
            Vertex<T> iterator = head;
            int index = 0;

            while (iterator != null)
            {
                if (iterator.Id == id)
                    return index;
                index++;
                iterator = iterator.Next;
            }
            return index;
        }


        public void display()
        {
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.ToString() + " --> ");
                Edge<T> iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    Console.Write(iteratorEdge.ToString() + " ");
                    iteratorEdge = iteratorEdge.Next;
                }
                Console.WriteLine();
                iterator = iterator.Next;
            }
            Console.WriteLine();
        }
        public int vertexCount()
        {
            int counter = 0;
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.Next;
            }
            return counter;
        }



        public void deleteVertex(string id)
        {
            if (head.Id == id)
                head = head.Next;
            else
            {
                Vertex<T> iterator = head;
                Vertex<T> prev = head;
                while (iterator != null)
                {
                    if (iterator.Id == id)
                        prev.Next = iterator.Next;
                    prev.Next = iterator.Next;
                    iterator = iterator.Next;
                }
            }
        }

        public Graph<T> copyGraph()
        {
            Graph<T> copy = new Graph<T>();
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                copy.addVertex(iterator.Id);
                iterator = iterator.Next;
            }
            iterator = head;
            while (iterator != null)
            {
                Edge<T> edgeIterator = iterator.EdgeLink;
                while (edgeIterator != null)
                {
                    copy.addEdge(iterator.Id, edgeIterator.VertexId, edgeIterator.Weight);
                    edgeIterator = edgeIterator.Next;
                }
                iterator = iterator.Next;
            }
            return copy;
        }





        public void addVertex(string id)
        {
            if (findVertex(id) == null)
            {
                Vertex<T> newV = new Vertex<T>(id);
                if (head == null)
                    head = newV;
                else
                {
                    Vertex<T> iterator = head;
                    while (iterator.Next != null)
                        iterator = iterator.Next;
                    iterator.Next = newV;
                }
            }
        }


        public void addEdge(string startId, string endId, T weight)
        {
            Vertex<T> current = findVertex(startId);
            if (current != null && findVertex(endId) != null)
            {
                Edge<T> iterator = current.EdgeLink;
                if (iterator == null)
                    current.EdgeLink = new Edge<T>(endId, weight);
                else
                {
                    while (iterator.Next != null)
                        iterator = iterator.Next;
                    iterator.Next = new Edge<T>(endId, weight);
                }
            }
            else
                Console.WriteLine("One edge can not exist");
        }


        public void deleteEdge(string startId, string endId, T weight)
        {
            Vertex<T> current = findVertex(startId);
            if (current != null && findVertex(endId) != null)
            {
                Edge<T> iterator = current.EdgeLink;
                if (iterator == null)
                    Console.WriteLine("This edge can not exist");
                else if (iterator.VertexId.CompareTo(endId) == 0)
                {
                    current.EdgeLink = iterator.Next;
                    return;
                }
                else
                {
                    while (iterator.Next.Next != null)
                    {
                        if (iterator.Next.VertexId.CompareTo(endId) == 0)
                        {
                            iterator.Next = iterator.Next.Next;
                            return;
                        }
                        iterator = iterator.Next;
                    }
                }

                if (iterator.Next.VertexId.CompareTo(endId) == 0)
                    iterator.Next = null;
            }
            else
                Console.WriteLine("This edge can not exist");
        }



        public void deleteAllEdgeFrom(Edge<T> edg, Graph<T> graph)
        {
            Vertex<T> current = findVertex(graph.getFirstVertexId());

            if (current != null)
            {
                while (current != null)
                {
                    Edge<T> iterator = current.EdgeLink;
                    if (iterator != null)
                    {
                        if (iterator.VCompareTo(edg) == 0)
                        {
                            current.EdgeLink = iterator.Next;
                            iterator = current.EdgeLink;
                        }

                        if (iterator != null && iterator.Next != null)
                        {
                            while (iterator.Next.Next != null)   ////burada sıkıntı var burdan sonrasına bak
                            {
                                if (iterator.Next.VCompareTo(edg) == 0)
                                {
                                    iterator.Next = iterator.Next.Next;
                                }
                                iterator = iterator.Next;
                            }

                            if (iterator.Next.VCompareTo(edg) == 0)
                                iterator.Next = null;
                        }




                    }
                    current = current.Next;

                }
            }
        }





        public string getFirstVertexId()
        {
            return head.Id;
        }

        public Edge<T> getMinEdgeFromVertex(Vertex<T> vrtx, Graph<T> grph)
        {
            Vertex<T> vertex = grph.findVertex(vrtx.Id);
            Edge<T> min = vertex.EdgeLink;
            Edge<T> iteratorE = vertex.EdgeLink;
            while (iteratorE != null)
            {
                if (min.Weight.CompareTo(iteratorE.Weight) > 0)
                    min = iteratorE;

                iteratorE = iteratorE.Next;
            }
            return min;
        }


        // recursively edgeleri okuyup addedges yapan algoritmayı yaz.

        private bool onlyOneHave(EdgeValues<T> edVal, Graph<T> grph)
        {
            bool r = false;
            bool start = grph.searchVertex(edVal.startId);
            bool end = grph.searchVertex(edVal.endId);
            if (start && !end)
                return true;
            else if (!start && end)
                return true;

            return false;
        }


        private bool bothHave(EdgeValues<T> edVal, Graph<T> grph)
        {

            bool start = grph.searchVertex(edVal.startId);
            bool end = grph.searchVertex(edVal.endId);
            if (start && end)
                return true;

            return false;
        }

        public Graph<T> kruskalAlgorithm()
        {
            makeEdgeList();
            Graph<T> newGraph = new Graph<T>();
            LinkedList<EdgeValues<T>> tempEdgeList = new LinkedList<EdgeValues<T>>();

            var edVal = edgeList.getFirstValue();

            newGraph.addVertex(edVal.startId);
            newGraph.addVertex(edVal.endId);
            newGraph.addEdge(edVal.startId, edVal.endId, edVal.weight);
            edgeList.deleteFirst();

            while (!edgeList.isEmpty())
            {
                var firstEdge = edgeList.getFirstValue();

                if (bothHave(firstEdge, newGraph))
                {
                    edgeList.deleteFirst();
         
                    while (!tempEdgeList.isEmpty())
                    {
                        edgeList.addSorted(tempEdgeList.getFirstValue());
                        tempEdgeList.deleteFirst();
                    }
                }
                else if (onlyOneHave(firstEdge, newGraph))
                {
                    newGraph.addVertex(firstEdge.startId);
                    newGraph.addVertex(firstEdge.endId);
                    newGraph.addEdge(firstEdge.startId, firstEdge.endId, firstEdge.weight);
                    edgeList.deleteFirst();
                    while (!tempEdgeList.isEmpty())
                    {
                        edgeList.addSorted(tempEdgeList.getFirstValue());
                        tempEdgeList.deleteFirst();
                    }
                }
                else
                {
                    tempEdgeList.addToFront(firstEdge);
                    edgeList.deleteFirst();
                }
            }

            return newGraph;
        }
        public void makeEdgeList()      // dışardan erişilecek olalan method
        {
            Graph<T> copyG = this.copyGraph();
            deleteCycle(copyG);

            travelEdges(copyG);


        }
        private void travelEdges(Graph<T> grph)      // graphtaki tüm edgeleri dolaşarak listeye sıralı olarak ekliyor.
        {
            edgeList = new LinkedList<EdgeValues<T>>();
            Vertex<T> iteratorV = grph.head;
            while (iteratorV != null)
            {
                Edge<T> iteratorE = iteratorV.EdgeLink;

                while (iteratorE != null)
                {
                    var edVal = new EdgeValues<T>(iteratorV.Id, iteratorE.VertexId, iteratorE.Weight);
                    addEdges(edVal, grph);

                    iteratorE = iteratorE.Next;
                }
                iteratorV = iteratorV.Next;
            }
        }

        private void addEdges(EdgeValues<T> edV, Graph<T> grph)
        {
            var newNode = new Node<EdgeValues<T>>(edV);
            edgeList.addSorted(newNode);
        }

        public void deleteCycle(Graph<T> grph)
        {
            Vertex<T> iteratorV = grph.head;
            while (iteratorV != null)
            {
                Edge<T> iteratorE = iteratorV.EdgeLink;
                Edge<T> PrevE = iteratorE;

                if (iteratorE != null)
                {
                    if (iteratorV.Id.CompareTo(iteratorE.VertexId) == 0)        //eğer ilk iterator cycle ise 
                        iteratorV.EdgeLink = iteratorE.Next;

                    while (iteratorE != null)
                    {
                        if (iteratorV.Id.CompareTo(iteratorE.VertexId) == 0)
                            PrevE.Next = iteratorE.Next;
                        PrevE = iteratorE;
                        iteratorE = iteratorE.Next;
                    }
                }

                iteratorV = iteratorV.Next;
            }

        }
        public Graph<T> primsAlgorithm()
        {
            Graph<T> controlGraph = this.copyGraph();
            deleteCycle(controlGraph);

            Graph<T> newGraph = new Graph<T>();
            newGraph.addVertex(getFirstVertexId());
            int n = newGraph.vertexCount();
            int t = this.vertexCount();
            while (n != t)    //butun vertexlere bakilmadigi surece calisacak
            {

                Vertex<T> minEdgesVertex = findVertex(controlGraph.getFirstVertexId());         //newGraph a edge eklemek icin tutuyoruz
                Edge<T> minEdge = getMinEdgeFromVertex(minEdgesVertex, controlGraph);

                if (minEdge == null)        // control graphta edge kalmamıssa agac tamamlanmistir.
                    break;

                Edge<T> controlEdge;            //min edge ile karşılaştırma yapılacak olan degisken
                Vertex<T> newGraphIterator = newGraph.head;             // kontrol edilecek vertexler üzerinde dolasacak
                while (newGraphIterator != null)   //butun bakılmıs vertexlerden tekrar bakacak
                {

                    Edge<T> edgeIterator = controlGraph.findVertex(newGraphIterator.Id).EdgeLink;       //controlgraphtan ilgili vertex bulunuyor ondan gidecek edgeler icinde dolasılacak edgeiteratorle
                    controlEdge = getMinEdgeFromVertex(newGraphIterator, controlGraph);

                    if (controlEdge != null)
                    {
                        if (controlEdge.WCompareTo(minEdge) < 0)
                        {
                            minEdge = controlEdge;
                            minEdgesVertex = newGraphIterator;
                        }
                    }

                    newGraphIterator = newGraphIterator.Next;

                } // ciktiginda mşnedge icinde en kucuk deger olacak

                newGraph.addVertex(minEdge.VertexId);
                n++; // döngünün kontrolü için bunu arttırmalıyız.

                newGraph.addEdge(minEdgesVertex.Id, minEdge.VertexId, minEdge.Weight);
                controlGraph.deleteAllEdgeFrom(minEdge, controlGraph);  // birdaha o edge üzerinden geçmemek icin silmeliyiz

            }

            return newGraph;
        }


    }
}
