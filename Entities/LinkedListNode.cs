using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class LinkedListNode
    {
        internal LinkedListNode siguiente;
        internal Object dato;
        internal LinkedListNode prev;

         public LinkedListNode(Object dato){
            this.dato=dato;
            this.siguiente=null;
            this.prev=null;
        }

        internal LinkedListNode versig(){
            return siguiente;
        }
         internal void agregar(LinkedListNode n){
            this.siguiente=n;
        }
        internal Object Verdato(){
            return this.dato;
        }
        
        
        internal LinkedListNode Siguiente
        {
            get => siguiente;
            set => siguiente = value;
        }
        internal LinkedListNode Previo
        {
            get => prev;
            set => prev = value;
        }
    }
}