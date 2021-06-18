using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Edge
    {
        internal int currentid=0;
        internal int id;

        public  Edge(){
            this.currentid=currentid++;
        }
        public Edge(int id) {
            this.id = id;
        }
         public int Id 
        { 
            get => id; 
            set => id = value; 
        }


    }
}