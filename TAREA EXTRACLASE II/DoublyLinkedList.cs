using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TAREA_EXTRACLASE_II
{
    public enum SortDirection
    {
        Asc,
        Desc
    }
    public class DoublyLinkedList
    {
        public Node? head;
        public Node? last;
        public Node? middle;
        public int size;
        public DoublyLinkedList()
        {
            this.head = null;
            this.last = null;
            this.middle = null;
            this.size = 0;
        }
        public bool IsEmpty()
        {
            return this.head == null;
        }
        public int Size()
        {
            return this.size;
        }
        public void InsertInOrder(int data)
        {
            Node newNode = new Node(data);

            if (this.IsEmpty())
            {
                this.head = newNode;
                this.last = newNode;
                this.middle = newNode;
                newNode.next = null;
                newNode.previous = null;
            }
            else
            {
                Node? current = this.head;

                if (data <= (int)current.data)
                {
                    newNode.next = this.head;
                    newNode.previous = null;
                    this.head.previous = newNode;
                    this.head = newNode;
                }
                else
                {
                    while (current.next != null && (int)current.next.data < data)
                    {
                        current = current.next;
                    }
                }
                newNode.next = current.next;
                newNode.previous = current;
                if (current.next != null)
                {
                    current.next.previous = newNode;
                }
                else
                {
                    this.last = newNode;
                }

                current.next = newNode;
            }
            if (this.size % 2 == 0)
            {
                if ((int)newNode.data < (int)this.middle.data)
                {
                    this.middle = this.middle.previous;
                }
            }
            else
            {
                if ((int)newNode.data >= (int)this.middle.data)
                {
                    this.middle = this.middle.next;
                }
            }
            this.size++;
        }

        public Node? DeleteFirst()
        {
            if (this.head != null)
            {
                Node? temp = this.head;
                this.head = this.head.next;
                if (this.head != null)
                {
                    this.head.previous = null;
                }
                else
                {
                    this.last = null;
                }
                if (this.size % 2 == 1) 
                {
                    this.middle = this.middle?.next; 
                }

                this.size--;
                return temp;
            }
            else
            {
                return null;
            }
        }
        public Node? DeleteLast()
        {
            if (this.head != null)
            {
                Node? temp = this.last;
                if (this.head == this.last)
                {
                    this.head = null;
                    this.last = null;
                }
                else
                {
                    this.last = this.last?.previous;
                    this.last.next = null;
                }
                if (this.size % 2 == 1)
                {
                    this.middle = this.middle?.previous;
                }
                this.size--;
                return temp;
            }
            else
            {
                return null;
            }
        }
        public bool DeleteValue(int Data)
        {
            if (this.IsEmpty())
            {
                return false;
            }
            else
            {
                Node? current = this.head;
                while (current != null && (int)current.data != Data)
                {
                    current = current.next;
                }
                if (current == null)
                {
                    return false;
                }
                if (current == this.head)
                {
                    return DeleteFirst() != null;
                }
                if (current == this.last)
                {
                    return DeleteLast() != null;
                }
                if (current == this.middle)
                {
                    if (this.size % 2 == 1)
                    {
                        this.middle = this.middle?.next;
                    }
                    else
                    {
                        this.middle = this.middle?.previous;
                    }
                }
                
                if (current.previous != null)
                {
                    current.previous.next = current.next;
                }
                if (current.next != null)
                {
                    current.next.previous = current.previous;
                }
                this.size--;
                return true;
                }
            }
        
        // PROBLEMA #1: MEZCLAR EN ORDEN 
        public static List<Node> MergeSorted(IList<Node> listA, IList<Node> listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new ArgumentNullException("List can not be null");
            }
            List<Node> mergedList = new List<Node>();
            int indexA = 0;
            int indexB = 0;

            while (indexA < listA.Count && indexB < listB.Count)
            {
                int comparisonResult = CompareNodes(listA[indexA], listB[indexB]);
                bool shouldInsertA = direction == SortDirection.Asc ? comparisonResult <= 0 : comparisonResult >= 0;
                if (shouldInsertA)
                {
                    mergedList.Add(listA[indexA]);
                    indexA++;
                }
                else
                {
                    mergedList.Add(listB[indexB]);
                    indexB++;
                }
            }
            while (indexA < listA.Count)
            {
                mergedList.Add(listA[indexA]);
                indexA++;
            }

            while (indexB < listB.Count)
            {
                mergedList.Add(listB[indexB]);
                indexB++;
            }
            return mergedList;
        }
        private static int CompareNodes(Node nodeA, Node nodeB)
        {
           
            return ((int)nodeA.data).CompareTo((int)nodeB.data);
        }


        // PROBLEMA #2: INVERTIR LISTA

        public void Invert()
        {
            if (this.head == null)
            {
                throw new ArgumentNullException("List can not be null");
            }
            Node? current = this.head;
            Node? temp = null;
            while (current != null)
            {
                temp = current.previous;
                current.previous = current.next;
                current.next = temp;
                current = current.previous;
            }
            if (temp != null)
            {
                this.head = temp.previous;
            }
        }

        // PROBLEMA #3: OBTENER EL ELEMENTO CENTRAL
        public int? GetMiddle()
        {
            if (this.IsEmpty())
            {
                throw new InvalidOperationException("Empty list."); ;
            }
            return (int)this.middle?.data;
        }
    }
}