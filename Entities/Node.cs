using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace graph_api.Entities
{
    public class Node
    {
        internal static int currentId = 0;
        internal int id;
        internal String name;

        public Node() { 
            this.id = Node.currentId++;
            
        }

        public Node(int id)
        {
            this.id = id;
        }
        

        public string Name
        {
            get => name;
            set => this.name = value;
        }
        
        public int Id 
        { 
            get => id; 
            set => id = value; 
        }
        
    }
}