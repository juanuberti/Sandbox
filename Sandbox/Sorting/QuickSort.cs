using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{

    /// <summary>
    /// Worst case (array already sorted in opposite order) running time O(n^2)
    /// Average run time O(nlogn)
    /// </summary>
    public class QuickSort
    {

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
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            } // at this point i will mark the location where all arr[low..i] are smaller than the pivot and all arr[i+1..high-1] are larger than the pivot. (remember arr[high] IS the pivot).

            //swap arr[i] with arr[high] (the pivot) and the array will now be sorted in relation to the pivot (all elements left of it are smaller, all elements right of it are larger)
            arr[high] = arr[i+1];
            arr[i+1] = pivot;

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
        public static void Sort(int[] arr, int low, int high)
        {
            if(low < high)
            {
                //Get partitioning index. 
                //This is the index at which the pivot point lands, under the conditions that all elements left of it are smaller and all elements right of it are larger than it.
                //in other words, arr[i] is in the correct location for a sorted array.
                int i = Partition(arr, low, high);

                //Now recursively sort the subarrays left and right of the pivot.
                Sort(arr, low, i - 1);
                Sort(arr, i + 1, high);
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

            Sort(arr, 0, n - 1);

            Console.WriteLine("\nsorted array");

            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + ", ");
        }
    }
}
