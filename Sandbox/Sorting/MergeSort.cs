using Sandbox.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sandbox.Data_Structures.SinglyLinkedList;

namespace Sandbox.Sorting
{
    public class MergeSort
    {
        #region basic sorting

        /// <summary>
        /// Splits the array into two halves, recursively calls self on those halves until they can't be split anymore and then merges the results.
        /// O(n log n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        public static void Sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                //Find the middle point:
                int m = (l + r) / 2;

                //Sort the two halves
                Sort(arr, l, m);
                Sort(arr, m + 1, r);

                //And merge them
                Merge(arr, l, m, r);
            }
        }

        /// <summary>
        /// Helper function, compares, sorts and merges two subarrays
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l"></param>
        /// <param name="m"></param>
        /// <param name="r"></param>
        public static void Merge(int[] arr, int l, int m, int r)
        {

            //get the sizes of the two arrays to be merged:
            int n1 = m - l + 1;
            int n2 = r - m;

            //create two temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            //Fill them in
            for(int x = 0; x < n1; x++)
            {
                L[x] = arr[l + x];
            }
            for (int y = 0; y < n2; y++)
            {
                R[y] = arr[m + 1 + y];
            }

            //Now merge them

            //Initial indexes for both arrays.
            int i = 0, j = 0;
            int k = l;

            while (i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            //Copy remaining items of L
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            //Copy remaining items of R
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }

        }


        ///Utility functions for testing:

        /* A utility function to print array of size n */
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver method
        public static void SimpleTest()
        {
            int[] arr = { 12, 11, 13, 5, 6, 7 };

            Console.WriteLine("Given Array");
            printArray(arr);

            MergeSort.Sort(arr, 0, arr.Length - 1);

            Console.WriteLine("\nSorted array");
            printArray(arr);
        }

        #endregion


        #region LinkedLists

        /// <summary>
        /// MergeSort for a singly-linked list.
        /// O n(logn) time complexity.
        /// Utilizes custom LinkedList class with utility methods.
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public static Node Sort(Node h)
        {
            // Base case : if head is null
            if (h == null || h.next == null)
            {
                return h;
            }

            // get the middle of the list
            Node middle = GetMiddle(h);
            Node nextOfMiddle = middle.next;

            // set the next of middle node to null, cutting it off from the right half of the list.
            middle.next = null;

            // Apply mergeSort on left list
            Node left = Sort(h);

            // Apply mergeSort on right list
            Node right = Sort(nextOfMiddle);

            // Merge the left and right lists
            Node sortedlist = SortedMerge(left, right);

            return sortedlist;
        }


        public void Test()
        {

            SinglyLinkedList li = new SinglyLinkedList();
            /*
             * Let us create a unsorted linked lists to test the functions Created
             * lists shall be a: 2->3->20->5->10->15
             */
            li.Push(15);
            li.Push(10);
            li.Push(5);
            li.Push(20);
            li.Push(3);
            li.Push(2);
            Console.Write("Linked List without sorting is: ");
            li.PrintList(li.head);

            // Apply merge Sort
            li.head = Sort(li.head);
            Console.Write("\n Sorted Linked List is: ");
            li.PrintList(li.head);
        }

        #endregion


    }
}
