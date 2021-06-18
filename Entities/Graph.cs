using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Graph {
        internal static int currentId = 0;
        internal static LinkedList nodes;
        internal Guid key = Guid.NewGuid();
        internal static LinkedList edges;

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

        public Guid Key
        {
            get => key;
        }

        public void addNode(Object e)
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

        internal LinkedList getNodes()
        {
            return nodes;
    }
        
        public void addEdge(Edge e)
        {
            if (edges ==null)
            {
                edges = new LinkedList();
            }
            edges.addLast(e);
        }
        
        public LinkedList Edges{
            get => edges;
        }
        
    }
}