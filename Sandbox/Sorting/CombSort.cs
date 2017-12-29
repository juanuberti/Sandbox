using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    public class CombSort
    {

        /// <summary>
        /// Find the next gap between elements.
        /// Best performance has been empirically found to be using a gap size of 1.3 [https://en.wikipedia.org/wiki/Comb_sort]
        /// </summary>
        /// <param name="gap"></param>
        /// <returns></returns>
        int getNextGap(int gap)
        {
            // Shrink gap by Shrink factor
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }

        /// <summary>
        /// Function to sort arr[] using Comb Sort
        /// An improvement over BubbleSort, but it still has a worst case of O(n^2).
        /// </summary>
        /// <param name="arr"></param>
        void sort(int[] arr)
        {
            int n = arr.Length;

            // initialize gap
            int gap = n;

            // Initialize swapped as true to make sure that
            // loop runs
            bool swapped = true;

            // Keep running while gap is more than 1 and last
            // iteration caused a swap
            while (gap != 1 || swapped == true)
            {
                // Find next gap
                gap = getNextGap(gap);

                // Initialize swapped as false so that we can
                // check if swap happened or not
                swapped = false;

                // Compare all elements with current gap
                for (int i = 0; i < n - gap; i++)
                {
                    if (arr[i] > arr[i + gap])
                    {
                        // Swap arr[i] and arr[i+gap]
                        int temp = arr[i];
                        arr[i] = arr[i + gap];
                        arr[i + gap] = temp;

                        // Set swapped
                        swapped = true;
                    }
                }
            }
        }
    }
}
