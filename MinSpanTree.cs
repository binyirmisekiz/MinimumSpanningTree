using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class MinSpanTree
    {
        FileOperation file = new FileOperation("graph.txt");
        public Graph<int> grph = new Graph<int>();
        string[] lines;

        public MinSpanTree()
        {
            lines = file.readFrom();        // class oluşurken txt deki içerik satır satır diziye atılıyor.
            makeGraph();            //graph ı olusturuyor

            Console.WriteLine("--- Graph ---"); Console.WriteLine();

            grph.display(); 
            Console.WriteLine();

            Console.WriteLine("---Minimum Spanning Tree---");
            Console.WriteLine();
            Console.WriteLine("-- By Prims Algorthm --");            Console.WriteLine();
            grph.primsAlgorithm().display(); Console.WriteLine();
            


            Console.WriteLine("-- By Kruksal Algorthm --");Console.WriteLine();
            grph.kruskalAlgorithm().display();
          
        }


        public void makeGraph()
        {
            string[] verties = lines[0].Split(' '); //ilk satirdaki vertexleri parçalayıp her birini dizinin bir elemanı yaptık
            for (int i = 0; i < verties.Length - 1; i++) //vertexleri graph a ekledik.(son vertex hariç)
            {
                grph.addVertex(verties[i]);
            }

            string[] endVertex = verties[verties.Length - 1].Split('\r');//son vertexi /r ifadesinden ayirmak için ayrıca isleme aldik.
            grph.addVertex(endVertex[0]);

            for (int i = 1; i < lines.Length; i++)  //edge lerin oldugu satirları de 
            {
                string[] edge = lines[i].Split(' ');
                if (edge.Length > 1)
                    grph.addEdge(edge[0], edge[1], Convert.ToInt16(edge[2]));
            }


        }





    }
}
