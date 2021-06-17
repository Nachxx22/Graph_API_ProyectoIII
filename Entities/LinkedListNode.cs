using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class LinkedListNode
    {
        private LinkedListNode siguiente;
        private Object dato;
        private LinkedListNode prev;

         public LinkedListNode(Object dato){
            this.dato=dato;
            this.siguiente=null;
            this.prev=null;
        }

        public LinkedListNode versig(){
            return this.siguiente;
        }
        void agregar(LinkedListNode n){
            this.siguiente=n;
        }
        Object Verdato(){
            return this.dato;
        }
        public LinkedListNode Siguiente
        {
            get => siguiente;
            set => siguiente = value;
        }
        public LinkedListNode Previo
        {
            get => prev;
            set => prev = value;
        }
    }
}