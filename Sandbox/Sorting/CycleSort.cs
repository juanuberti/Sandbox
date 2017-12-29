using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    public class CycleSort
    {

        /// <summary>
        /// Awful running time { O(n^2) on most cases } but minimal number of writes, so it's good if your main concern is minimizing write operations.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        public static void Sort( int[] arr, int n)
        {
            Console.WriteLine("Unsorted Array: ");
            for (int x = 0; x < n; x++)
                Console.Write(arr[x] + " ");

            // count number of memory writes
            int writes = 0;

            // traverse array elements and put it to on
            // the right place
            for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
            {
                // initialize item as starting point
                int item = arr[cycle_start];

                // Find position where we put the item. We basically
                // count all smaller elements on right side of item.
                int pos = cycle_start;
                for (int i = cycle_start + 1; i < n; i++)
                    if (arr[i] < item)
                        pos++;

                // If item is already in correct position
                if (pos == cycle_start)
                    continue;

                // ignore all duplicate elements
                while (item == arr[pos])
                    pos += 1;

                // put the item to its right position
                if (pos != cycle_start)
                {
                    int temp = item;
                    item = arr[pos];
                    arr[pos] = temp;
                    writes++;
                }

                // Rotate rest of the cycle
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Find position where we put the element
                    for (int i = cycle_start + 1; i < n; i++)
                        if (arr[i] < item)
                            pos += 1;

                    // ignore all duplicate elements
                    while (item == arr[pos])
                        pos += 1;

                    // put the item to it's right position
                    if (item != arr[pos])
                    {
                        int temp = item;
                        item = arr[pos];
                        arr[pos] = temp;
                        writes++;
                    }

                }
            }
        }

        public static void Test()
        {
            int[] arr = { 1, 8, 3, 9, 10, 10, 2, 4 };
            int n = arr.Length;
            Sort(arr, n);

           Console.WriteLine("Sorted Array: ");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
        }


    }
}
