using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    public class DNF_Sort
    {

        /// <summary>
        /// Basic Dutch National Flag sort with three "colours" (here simplified as ints).
        /// O(n) time complexity.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="red"></param>
        /// <param name="white"></param>
        /// <param name="blue"></param>
        public static void Sort(int[] arr, int red, int white, int blue)
        {
            int low = 0, mid = 0; int high=arr.Length-1;
            while(mid<high)
            {
                if (arr[mid] == red)
                {
                    arr[mid] = arr[low];
                    arr[low] = red;
                    low++;
                    mid++;
                }
                if(arr[mid] == white)
                {
                    mid++;
                }
                else if (arr[mid] == blue)
                {
                    arr[mid] = arr[high];
                    arr[high] = blue;
                    high--;
                }
            }
        }

        public static void Test()
        {
            int[] flag = { 0, 1, 1, 0, 2, 1, 2, 0, 2, 1, 1, 0, 0, 1, 2 };
            Sort(flag, 0, 1, 2);
            foreach( int a in flag)
            {
                Console.Write(a + " ");
            }
        }
    }
}
