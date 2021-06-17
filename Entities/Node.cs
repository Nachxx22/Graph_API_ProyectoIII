using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Node
    {
        private static int currentId = 0;
        private int id;
        private String value;

        public Node() { 
            this.id = Node.currentId++;
        }

        public Node(int id)
        {
            this.id = id;
        }

        public string Value
        {
            get => value;
            set => this.value = value;
        }
        
        public int Id 
        { 
            get => id; 
            set => id = value; 
        }
    }
}