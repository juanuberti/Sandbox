using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    public class MergeSort
    {


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
            for(int i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }
            for (int j = 0; j < n2; j++)
            {
                R[j] = arr[m + 1 + j];
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
    }
    
}
}
