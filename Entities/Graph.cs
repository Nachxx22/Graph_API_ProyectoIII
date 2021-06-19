using System;
using System.Collections.Generic;
using System.Linq;

namespace graph_api.Entities
{
    public class Graph : IComparable<Graph>
    {
        private static int currentId = 0;

        private int id;
        private LinkedList<Node> nodes;        
        private LinkedList<Edge> edges;        

        public Graph() {
            this.id = currentId++;
        }
        
        public Graph(int id) {
            this.id = id;
            nodes = new LinkedList<Node>();
            edges = new LinkedList<Edge>();
        }

        public int Id 
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public LinkedList<Node> Nodes { 
            get => nodes; 
        }
        public LinkedList<Edge> Edges{
            get => edges;
        }


        public int NewNodeId()
        {
            if (!Nodes.Any())
            {
                return 0;
            }

            var maxVal = Nodes.Max(w => w?.Id);
            if (maxVal != null)
            {
                return maxVal.Value + 1;
            }
            else
            {
                return 0; 
            }
        }

        public int NewEdgeId()
        {
            if (!Edges.Any())
            {
                return 0;
            }

            var maxVal = Edges.Max(w => w?.Id);
            if (maxVal != null)
            {
                return maxVal.Value + 1;
            }
            else
            {
                return 0;
            }
        } 

        internal object GetDegree(string sort)
        {
            throw new NotImplementedException();
        }

        internal object GetDijkstra(int startNode, int endNode)
        {
            throw new NotImplementedException();
        } 
        public int CompareTo(Graph that)
        {
            if (this.id < that.id) return -1;
            if (this.id == that.id) return 0;
            return 1;
        }
    }
}