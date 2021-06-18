using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace graph_api.Entities
{
    public class Node
    {
        private static int currentId = 0;
        private int id;
        private String name;
        private static LinkedList edges;
        private Guid UUID = Guid.NewGuid();

        public Node() { 
            this.id = Node.currentId++;
            
        }

        public Node(int id)
        {
            this.id = id;
        }

        public string Value
        {
            get => name;
            set => this.name = value;
        }
        
        public int Id 
        { 
            get => id; 
            set => id = value; 
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