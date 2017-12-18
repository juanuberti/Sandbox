using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    public class InsertionSort
    {

        /// <summary>
        /// O(n^2) worst case scenario.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] SortIntArray(int[] arr)
        {
            int n = arr.Length;

            for(int i =1;i<n;i++)
            {
                int key = arr[i];
                int j = i - 1;

                //Move all elements of arr[i..n] that are greater than the key one slot ahead of their current position.
                while(j>=0 && arr[j]>key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                //Now place the value key into it's appropriate slot.
                arr[j+1] = key;
            }

            return arr;
        }
    }
}
