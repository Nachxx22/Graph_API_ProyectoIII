using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Edge
    {
        internal int currentid=0;
        internal int id;
        internal Node origin;
        internal Node destination;
        internal double time;

        public  Edge(){
            this.currentid=currentid++;
        }
        public Edge(int id) {
            this.id = id;
        }

        public Edge(Node origin, Node destination, double time)
        {
            this.origin = origin;
            this.destination = destination;
            this.time = time;
        }

        public int Id 
        { 
            get => id; 
            set => id = value; 
        }
         public Node Origin
         { 
             get => origin; 
             set => origin = value; 
         }
         public Node Destination
         { 
             get => destination; 
             set => destination = value; 
         }

         public double Time
         {
             get => time; 
             set => time = value; 
         }


    }
}