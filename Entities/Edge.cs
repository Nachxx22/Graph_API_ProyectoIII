using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Edge : IComparable<Edge>
    {
        private int currentid=0;
        private int id;
        public int start { get; set; }
        public int end { get; set; }
        public int weight { get; set; }

        public Edge(){
            this.currentid=currentid++;
        }
        public Edge(int id) {
            this.id = id;
        }


        public Edge(int id, int startNode, int endNode, int weight)
        {
            this.id = id;
            start = startNode;
            end = endNode;
            this.weight = weight;
        }

        public int Id 
        { 
            get => id; 
            set => id = value; 
        }

        public int CompareTo(Edge other)
        {
            if (this.Id < other.Id) return -1;
            if (this.Id == other.Id) return 0;
            return 1;
        }
    }
}