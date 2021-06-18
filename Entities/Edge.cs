using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class Edge
    {
        private int currentid=0;
        private int id;

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