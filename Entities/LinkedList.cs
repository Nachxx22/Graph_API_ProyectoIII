using System;
using System.Collections.Generic;
using System.Diagnostics;

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

        public void printlist(LinkedList lista)
        {
            if (lista.head == null)
            {
                Debug.WriteLine("La lista esta vacia");
            }
            else
            {
                for (int i = 0; i < lista.size; i++) {
                    if (lista.ver(i) != null)
                    {
                        Debug.WriteLine(lista.ver(i)+"");
                    }
                    else
                    { Debug.WriteLine("Esta vacio");}
                }
            }

        }

        public Object ver(int indice)
        {
            LinkedListNode temp = head;
            for (int i = 0; i < indice; i++)
            {
                temp = temp.Siguiente;
            }

            if (temp != null)
            {
                if (temp.Verdato() != null)
                {
                    return temp.Verdato();
                }
                else{return null;}
            }else{return null;}
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