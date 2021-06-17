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
        public addLast(Object e){
            if(this.head==null){
                LinkedListNode temp=head;
                while(temp.versig != null){
                    temp=temp.versig;
                }
                LinkedListNode n= new LinkedListNode(e);
                temp.siguiente =n;
                n.prev=temp;
                size++;
            }
            else{
                head=new LinkedListNode(e);
                size++;
    
            }
        }



        //Para 
        public void setSize(int size){this.setSize=size;}
    }
}