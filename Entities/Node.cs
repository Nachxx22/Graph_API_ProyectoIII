using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Node : IComparable<Node>
    {
        private static int currentId = 0;
        private int id;
        private Entity entity;

        public Node() { 
            this.id = Node.currentId++;
        }

        public Node(int Id, Entity Entity)
        {
            id = Id;
            entity = Entity;
        }
        public Node(int id)
        {
            this.id = id;
        }

        public Entity Entity
        {
            get => entity;
            set => this.entity = value;
        }
        
        public int Id 
        { 
            get => id; 
            set => id = value; 
        }
         
        public int CompareTo(Node other)
        {
            if (this.Id < other.Id) return -1;
            if (this.Id == other.Id) return 0;
            return 1;
        }
    }
}