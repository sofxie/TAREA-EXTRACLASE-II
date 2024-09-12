using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAREA_EXTRACLASE_II
{
    public enum SortDirection
    {
        Asc,
        Desc
    }
    class DoublyLinkedList
    {
        public Node? head;
        public Node? last;
        public int size;
        public DoublyLinkedList()
        {
            this.head = null;
            this.last = null;
            this.size = 0;
        }
        public Boolean IsEmpty()
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
                    this.last = this.last.previous;
                    this.last.next = null;
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
                if (current != null)
                {
                    return false;
                }
                if (current == this.head)
                {
                    this.head = current.next;
                    if (this.head != null)
                    {
                        this.head.previous = null;
                    }
                    else
                    {
                        current.previous.next = current.next;
                        if (current.next != null)
                        {
                            current.next.previous = current.previous;
                        }
                        else
                        {
                            this.last = current.previous;
                        }
                    }
                    this.last = null;
                }
            }
            this.size--;
            return true;
        }
        public int? GetMiddle()
        {
            if (this.IsEmpty())
            {
                return null;
            }
            int middlePosition = this.size / 2;
            Node? current = this.head;

            for (int i = 0; i < middlePosition; i++)
            {
                current = current.next;
            }
            return (int?) current?.data;
        }
    }
}
