using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Data_Structures
{
    public class DoublyLinkedList
    {
        public Node head { get; set; }

        /* a node of the doubly linked list */
        public class Node
        {
            public int data { get; set; }
            public Node next { get; set; }
            public Node prev { get; set; }

            public Node(int d)
            {
                data = d;
                next = null;
                prev = null;
            }
        }

        // A utility function to find last node of linked list    
        public static Node LastNode(Node node)
        {
            while (node.next != null)
                node = node.next;
            return node;
        }

        // A utility function to print contents of arr
        public void printList(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + ", ");
                head = head.next;
            }
        }

        /* Function to insert a node at the beginging of the Doubly Linked List */
        public void Push(int new_Data)
        {
            Node new_Node = new Node(new_Data);     /* allocate node */

            // if head is null, head = new_Node
            if (head == null)
            {
                head = new_Node;
                return;
            }

            /* link the old list off the new node */
            new_Node.next = head;

            /* change prev of head node to new node */
            head.prev = new_Node;

            /* since we are adding at the begining, prev is always NULL */
            new_Node.prev = null;

            /* move the head to point to the new node */
            head = new_Node;
        }

    }
}
