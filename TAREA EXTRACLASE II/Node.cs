using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA_EXTRACLASE_II
{
    public class Node
    {
        public object data;
        public Node? next;
        public Node? previous;

        public Node (object data)
        {
            this.data = data;
            this.next = null;
            this.previous = null;
        }
        public object getData()
        {
            return this.data;
        }
        public void setData(object data)
        {
            this.data = data;
        }
        public Node? getNext()
        {
            return this.next;
        }
        public Node? getPrevious()
        {
            return this.previous;
        }
        public void setNext(Node node)
        {
            this.next = node;
        }
        public void setPrevious(Node node)
        {
            this.previous = node;
        }
    }
}
