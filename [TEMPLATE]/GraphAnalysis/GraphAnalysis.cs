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

        private static Dictionary<string, List<string>> adj; // adjacency list
        private static Dictionary<string, int> color = new Dictionary<string, int>();
        private static Dictionary<string, string> parent = new Dictionary<string, string>();
        private static Dictionary<string, int> d = new Dictionary<string, int>();
        private static Dictionary<string, int> f = new Dictionary<string, int>();
        private static int time = 0, backward = 0, forward = 0, cross = 0;

        public static void DFS(string startVertex)
        {
            // initialize color, parent, d, and f dictionaries
            foreach (string vertex in adj.Keys)
            {
                color[vertex] = 0; // WHITE
                parent[vertex] = null; // NIL
                d[vertex] = 0;
                f[vertex] = 0;
            }
            DFSVisit(startVertex);
            // call DFSVisit on startVertex
            foreach (string u in adj.Keys)
                if (color[u] == 0)
                    DFSVisit(u);
        }

        private static void DFSVisit(string u)
        {
            color[u] = 1; // GRAY
            time++;
            d[u] = time;

            foreach (string v in adj[u])
            {
                if (color[v] == 0) // WHITE
                {
                    parent[v] = u;
                    DFSVisit(v);
                }
                else if (color[v] == 1)
                    backward++;
                else
                {
                    if (d[u] < d[v])
                        forward++;
                    else
                        cross++;
                }
            }

            color[u] = 2; // BLACK
            time++;
            f[u] = time;
        }
        public static int[] AnalyzeEdges(string[] vertices, KeyValuePair<string, string>[] edges, string startVertex)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int[] result = new int[3];
            adj = new Dictionary<string, List<string>>();

            // add vertices to adjacency list
            foreach (string vertex in vertices)
            {
                adj[vertex] = new List<string>();
            }

            // add edges to adjacency list
            foreach (KeyValuePair<string, string> edge in edges)
            {
                adj[edge.Key].Add(edge.Value);
                adj[edge.Value].Add(edge.Key);
            }

            DFS(startVertex);

            result[0] = backward;
            result[1] = forward;
            result[2] = cross;

            return result;
        }

        #endregion
    }
}
