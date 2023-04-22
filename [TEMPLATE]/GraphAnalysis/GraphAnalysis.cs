using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    public static class GraphAnalysis
    {
        #region YOUR CODE IS HERE
        //Your Code is Here:
        //==================
        /// <param name="vertices"></param>
        /// <param name="edges"></param>
        /// <param name="startVertex"></param>
        /// <param name="outputs"></param>

        /// <summary>
        /// Analyze the edges of the given DIRECTED graph by applying DFS starting from the given "startVertex" and count the occurrence of each type of edges
        /// NOTE: during search, break ties (if any) by selecting the vertices in ASCENDING alpha-numeric order
        /// </summary>
        /// <param name="vertices">array of vertices in the graph</param>
        /// <param name="edges">array of edges in the graph</param>
        /// <param name="startVertex">name of the start vertex to begin from it</param>
        /// <returns>return array of 3 numbers: outputs[0] number of backward edges, outputs[1] number of forward edges, outputs[2] number of cross edges</returns>

        private static int time = 0;

        public static int[] AnalyzeEdges(string[] vertices, KeyValuePair<string, string>[] edges, string startVertex)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            //Console.WriteLine(startVertex + "**************************");
            int[] result = new int[3];

            Dictionary<string, Stack<string>> graph = new Dictionary<string, Stack<string>>();
            Dictionary<string, int> discoveryTime = new Dictionary<string, int>();
            Dictionary<string, int> color = new Dictionary<string, int>();

            foreach (string vertex in vertices)
            {
                graph[vertex] = new Stack<string>();
                color[vertex] = 0;  //WHITE
            }

            foreach (KeyValuePair<string, string> edge in edges)
                graph[edge.Key].Push(edge.Value);

            //foreach (KeyValuePair<string, Stack<string>> item in graph)
            //{
            //    Console.WriteLine(item.Key + "{");
            //    foreach (var lst in item.Value)
            //    {
            //        Console.WriteLine(lst);
            //    }
            //    Console.WriteLine("}");
            //    Console.WriteLine();
            //}

            DFS(startVertex, graph, discoveryTime, color, result);

            //foreach(KeyValuePair<string, List<string>> vertex in graph)
            //{
            //    if (color[vertex.Key] == 0)
            //        DFS(vertex.Key, graph, discoveryTime, color, result);

            //}

            return result;
        }

        private static void DFS(string vertex, Dictionary<string, Stack<string>> graph, Dictionary<string, int> discoveryTime, Dictionary<string, int> color, int[] result)
        {
            color[vertex] = 1; //GRAY
            time++;
            discoveryTime[vertex] = time;

            foreach (string adjacentVertex in graph[vertex])
            {
                if (color[adjacentVertex] == 0)
                    DFS(adjacentVertex, graph, discoveryTime, color, result);
                else if (color[adjacentVertex] == 1)         //(graph[adjacentVertex].Contains(vertex))
                {
                    result[0]++;
                    //Console.WriteLine(adjacentVertex + " BACK");
                }
                else
                {
                    if (discoveryTime[vertex] < discoveryTime[adjacentVertex])
                    {
                        result[1]++;
                        //Console.WriteLine(adjacentVertex + " FOR");
                    }
                    else
                    {
                        result[2]++;
                        //Console.WriteLine(adjacentVertex + " CROSS");
                    }
                }
            }
            color[vertex] = 2;  //BLACK
        }
        #endregion
    }
}
