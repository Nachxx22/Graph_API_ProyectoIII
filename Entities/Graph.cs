using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Graph {
        private static int currentId = 0;
        private static LinkedList nodes;

        private int id;

        public Graph() {
            this.id = currentId++;
        }
        
        public Graph(int id) {
            this.id = id;
        }

        public int Id 
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public void addNode(Node e)
        {
            if (nodes == null)
            {
                nodes = new LinkedList();
            }
            nodes.addLast(e);
        }
        public LinkedList Nodes { 
            get => nodes; 
        }
        /*
        public void addEdge(Edge e)
        {
            if (edges ==null)
            {
                edges = new LinkedList();
            }
            edges.addLast(e);
        }
        */
        /*
        public LinkedList Edges{
            get => edges;
        }
        */
    }
}