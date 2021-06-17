using System;
using System.Collections.Generic;

namespace graph_api.Entities
{
    public class LinkedList
    {
        LinkedListNode head;
        int size;


        public LinkedList(){
            head=null;
            setSize(0);
        }


        //Añadir de último a la lista 
        public void addLast(Object e){
            if(this.head==null){
                LinkedListNode temp=head;
                while(temp.Siguiente != null){
                    temp=temp.Siguiente;
                }
                LinkedListNode n= new LinkedListNode(e);
                temp.Siguiente=n;
                n.Previo=temp;
                size++;
            }
            else{
                head=new LinkedListNode(e);
                size++;

            }
        }


        //Para 
        public void setSize(int size)
        {
            this.size=size;
        }

        public int Size
        {
            get => size;
            set => size=value;
        }
    }
}