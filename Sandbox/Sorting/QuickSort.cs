using Sandbox.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sandbox.Data_Structures.DoublyLinkedList;

namespace Sandbox.Sorting
{

    /// <summary>
    /// Worst case (array already sorted in opposite order) running time O(n^2)
    /// Average run time O(nlogn)
    /// </summary>
    public class QuickSort
    {

        #region Recursive sort

        /// <summary>
        /// We choose the last element in the array as pivot. 
        /// Sort all lower elements to its left and higher elements to its right.
        /// Returns the index value at which the pivot ends up
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];

            int i = low - 1; // index of beginning section of the array.

            for(int j = low; j < high; j++)
            {
                if(arr[j]<pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            } // at this point i will mark the location where all arr[low..i] are smaller than the pivot and all arr[i+1..high-1] are larger than the pivot. (remember arr[high] IS the pivot).

            //swap arr[i+1] with arr[high] (the pivot) and the array will now be sorted in relation to the pivot (all elements left of it are smaller, all elements right of it are larger)
            Swap (arr,i+1,high);
            return i+1;
        }

        /// <summary>
        /// Recursive quicksort function.
        /// Takes an array, and two indexes - low and high - of the array to sort.
        /// Calls partition to position a pivot in sorted order and then recursively calls itself to sort sub arrays around the pivot.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public static void RecursiveSort(int[] arr, int low, int high)
        {
            if(low < high)
            {
                //Get partitioning index. 
                //This is the index at which the pivot point lands, under the conditions that all elements left of it are smaller and all elements right of it are larger than it.
                //in other words, arr[i] is in the correct location for a sorted array.
                int i = Partition(arr, low, high);

                //Now recursively sort the subarrays left and right of the pivot.
                RecursiveSort(arr, low, i - 1);
                RecursiveSort(arr, i + 1, high);
            }
        }

        /// <summary>
        /// simple test function
        /// </summary>
        public static void Test()
        {
            Console.WriteLine("\n\nQuicksort test:\n");

            int[] arr = { 10, 7, 8, 9, 1, 5 };
            int n = arr.Length;


            Console.WriteLine("Unsorted array");

            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + ", ");

            RecursiveSort(arr, 0, n - 1);

            Console.WriteLine("\nsorted array");

            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + ", ");
        }

        #endregion

        #region Iterative sort

        // Sorts arr[l..h] using iterative QuickSort
        void IterativeSort(int[] arr, int low, int high)
        {
            // create auxiliary stack
            int[] stack = new int[high - low + 1];

            // initialize top of stack
            int top = -1;

            // push initial values in the stack
            stack[++top] = low;
            stack[++top] = high;

            // keep popping elements until stack is not empty
            while (top >= 0)
            {
                // pop h and l
                high = stack[top--];
                low = stack[top--];

                // set pivot element at it's proper position
                int p = Partition(arr, low, high);

                // If there are elements on left side of pivot,
                // then push left side to stack
                if (p - 1 > low)
                {
                    stack[++top] = low;
                    stack[++top] = p - 1;
                }

                // If there are elements on right side of pivot,
                // then push right side to stack
                if (p + 1 < high)
                {
                    stack[++top] = p + 1;
                    stack[++top] = high;
                }
            }
        }

        #endregion

        #region Linked lists

        /// <summary>
        /// Considers last element as pivot, places the pivot element at its
        /// correct position in sorted array, and places all smaller (smaller than
        /// pivot) to left of pivot and all greater elements to right of pivot */
        /// </summary>
        /// <param name="l"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Node DLLPartition(Node l, Node h)
        {
            // set pivot as h element
            int x = h.data;

            // similar to i = l-1 for array implementation
            Node i = l.prev;

            // Similar to "for (int j = l; j <= h- 1; j++)"
            for (Node j = l; j != h; j = j.next)
            {
                if (j.data <= x)
                {
                    // Similar to i++ for array
                    i = (i == null) ? l : i.next;
                    // Swap
                    int t = i.data;
                    i.data = j.data;
                    j.data = t;
                }
            }
            i = (i == null) ? l : i.next;  // Similar to i++
            int temp = i.data;
            i.data = h.data;
            h.data = temp;
            return i;
        }

        /* A recursive implementation of quicksort for linked list */
        public static void _DLLSort(Node l, Node h)
        {
            if (h != null && l != h && l != h.next)
            {
                Node temp = DLLPartition(l, h);
                _DLLSort(l, temp.prev);
                _DLLSort(temp.next, h);
            }
        }


        /// <summary>
        /// The main function to sort a doubly linked list. It mainly calls _quickSort()
        /// </summary>
        /// <param name="node"></param>
        public static void DLLSort(Node node)
        {
            // Find last node
            Node head = LastNode(node);

            // Call the recursive QuickSort
            _DLLSort(node, head);
        }


        /* Driver program to test above function */
        public static void DoublyLinkedListTest()
        {
            DoublyLinkedList list = new DoublyLinkedList();


            list.Push(5);
            list.Push(20);
            list.Push(4);
            list.Push(3);
            list.Push(30);


            Console.Write("Linked List before sorting ");
            list.printList(list.head);
            Console.Write("\nLinked List after sorting");
            DLLSort(list.head);
            list.printList(list.head);

        }
        #endregion

        #region Utility functions
        public static void Swap(int[] arr, int i, int j)
        {
            int t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        #endregion
    }
}
