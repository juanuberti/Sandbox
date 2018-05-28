using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Questions
{
    public class TrappingRainWater
    {

        /// <summary>
        /// Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
        /// Space-optimized solution.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int FindWater(int[] arr)
        {
            int n = arr.Length;

            int Result = 0;

            //Maximum height on left and right
            int left_max = 0, right_max = 0;

            //indices to traverse the array
            int lo = 0, hi = n - 1;

            //traverse the array, moving indices to meet at middle.
            while(lo<=hi)
            {
                if (arr[lo] < arr[hi])
                {
                    if (arr[lo] > left_max)
                        //update max in the left
                        left_max = arr[lo];
                    else
                    {
                        //water on current element = max - current
                        Result += left_max - arr[lo];
                        lo++;
                    }
                }
                else
                {
                    if (arr[hi] > right_max)
                        //update max in the right
                        right_max = arr[hi];
                    else
                    {
                        Result += right_max - arr[hi];
                        hi--;
                    }
                }   
            }

            return Result;

        }

        public static void Test()
        {
            int[] arr = {0, 1, 0, 2, 1, 0, 1,
                    3, 2, 1, 2, 1};
            int n = arr.Length;

            Console.WriteLine("Maximum water that "
                             + "can be accumulated is "
                             + FindWater(arr));
        }
    }
}
