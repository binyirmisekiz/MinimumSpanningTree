using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    class LinkedList<T> where T : IComparable
    {
        public Node<T> head;
        public T getFirstValue()
        {
            if (head != null)
                return head.value;
            return default(T);
        }

        public int Length()
        {
            Node<T> iterator = head;
            int counter = 0;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.next;
            }
            return counter;
        }

        public void deleteFirst()
        {
            if (head != null)
            {
                head = head.next;
            }
        }
        public void addToFront(T val)
        {
            Node<T> newNode = new Node<T>(val);

            if (head == null)
                head = newNode;
            else
            {
                newNode.next = head;
                head = newNode;
            }
        }

        public void addToEnd(T val)
        {
            Node<T> newNode = new Node<T>(val);

            if (head == null)
                head = newNode;
            else
            {
                Node<T> iterator = head;
                while (iterator.next != null)
                {
                    iterator = iterator.next;
                }
                iterator.next = newNode;

            }


        }


        public bool isEmpty()
        {
            if (head == null)
                return true;
            return false;

        }
        public void addSorted(T edVal)
        {
            Node<T> newNode = new Node<T>(edVal);
            if (head == null)
                head = newNode;
            else if (head.value.CompareTo(newNode.value) >= 0)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                Node<T> iterator = head.next;
                Node<T> previous = head;
                while (iterator != null)
                {
                    if (iterator.value.CompareTo(edVal) >= 0)
                    {
                        previous.next = newNode;
                        newNode.next = iterator;
                        break;
                    }
                    previous = iterator;
                    iterator = iterator.next;
                }
                if (iterator == null)
                    previous.next = newNode;

            }
        }


        public void addSorted(Node<T> node)
        {
            Node<T> newNode = node;
            if (head == null)
                head = newNode;
            else if (head.value.CompareTo(newNode.value) >= 0)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                Node<T> iterator = head.next;
                Node<T> previous = head;
                while (iterator != null)
                {
                    if (iterator.value.CompareTo(node.value) >= 0)
                    {
                        previous.next = node;
                        node.next = iterator;
                        break;
                    }
                    previous = iterator;
                    iterator = iterator.next;
                }
                if (iterator == null)
                    previous.next = newNode;

            }
        }
        public void deleteOne(T val)
        {
            if (head == null)
                return;
            if (head.value.CompareTo(val) == 0)
                head = head.next;
            else
            {
                Node<T> iterator = head;

                while (iterator.next != null)
                {
                    if (iterator.next.value.CompareTo(val) == 0)
                    {
                        iterator.next = iterator.next.next;
                        break;
                    }
                    iterator = iterator.next;
                }
            }
        }

        public void display()
        {
            if (head != null)
            {
                Node<T> iterator = head;

                while (iterator != null)
                {
                    Console.WriteLine(iterator.value.ToString());
                    iterator = iterator.next;

                }

            }




        }
    }
}
