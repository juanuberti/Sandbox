using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Data_Structures
{
    public class SinglyLinkedList
    {
        //Head ndoe, marks the beginning of the Linked List.
        public Node head { get; set; }


        public class Node
        {
            public int val { get; set; }
            public Node next { get; set; }

            public Node(int val)
            {
                this.val = val;
            }
        }

        /// <summary>
        /// Merges two sorted Linked Lists, a and b, in ascending order.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Node SortedMerge(Node a, Node b)
        {
            Node result = null;

            /* Base cases */
            if (a == null)
                return b;
            if (b == null)
                return a;
            
            /* Pick either a or b, and recur */
            if (a.val <= b.val)
            {
                result = a;
                result.next = SortedMerge(a.next, b);
            }
            else
            {
                result = b;
                result.next = SortedMerge(a, b.next);
            }
            return result;

        }

        //Utility functions


        /// <summary>
        /// Utility function to get the middle of the linked list
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Node GetMiddle(Node h)
        {
            //Base case
            if (h == null)
                return h;
            Node fastptr = h.next;
            Node slowptr = h;

            // Move fastptr by two and slow ptr by one
            // Finally slowptr will point to middle node
            while (fastptr != null)
            {
                fastptr = fastptr.next;
                if (fastptr != null)
                {
                    slowptr = slowptr.next;
                    fastptr = fastptr.next;
                }
            }
            return slowptr;
        }

        public void Push(int new_data)
        {
            /* allocate node */
            Node new_node = new Node(new_data);

            /* link the old list off the new node */
            new_node.next = head;

            /* move the head to point to the new node */
            head = new_node;
        }

        /// <summary>
        /// Utility function to print the linked list 
        /// </summary>
        /// <param name="headref"></param>
        public void PrintList(Node headref)
        {
            while (headref != null)
            {
                Console.Write(headref.val + ", ");
                headref = headref.next;
            }
        }



    }
}
