using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class LinkedListNode
    {
        private LinkedListNode siguente;
        private Object dato;
        private LinkedListNode prev;

        LinkedListNode(Object dato){
            this.dato=dato;
            this.siguente=null;
            this.prev=null;
        }

        LinkedListNode versig(){
            return this.siguente;
        }
        void agregar(LinkedListNode n){
            this.siguente=n;
        }
        Object Verdato(){
            return this.dato;
        }
        public string Siguiente
        {
            get => siguiente;
            set => this.siguiente = siguiente;
        }
        public string Previo
        {
            get => prev;
            set => this.prev = prev;
        }
    }
}