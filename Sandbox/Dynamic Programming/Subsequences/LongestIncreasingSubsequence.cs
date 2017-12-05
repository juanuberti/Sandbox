using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    /// <summary>
    /// O(n^2) and O(nlogn) methods for finding Length Longest Increasing Subsequences.
    /// Example text from http://www.geeksforgeeks.org/longest-increasing-subsequence/ :
    /// The Longest Increasing Subsequence(LIS) problem is to find the length of the longest subsequence of a given sequence such that all elements of the subsequence are sorted in increasing order.
    /// For example, the length of LIS for { 10, 22, 9, 33, 21, 50, 41, 60, 80} is 6 and LIS is {10, 22, 33, 50, 60, 80}.
    /// 
    /// EDIT: The O(nlogn) solution is a bit out of my league right now so I'm gonna focus on other problems and build up to it later.
    /// </summary>
    public class LongestIncreasingSubsequence
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="n"> size of the sequence -- or subsequence if deesired.</param>
        /// <returns></returns>
        public static int On2LIS(int[] sequence, int n)
        {
            int[] lis = new int[n];
            int i, j, max = 0;

            //Initialize LIS values for 0...n as 1
            for(i=0;i<n;i++)
            {
                lis[i] = 1;
            }

            //compute the LIS values form the bottom up
            for(i=1;i<n;i++)
            {
                for(j=1;j<i;j++)
                {
                    if (//Check if the number at i is larger than the number at j (thus being an increasing sequence)
                        sequence[i] > sequence[i]
                        &&
                        // Check if this subsequence would be larger by including this number or shorter
                        // In other words check if this is the max subsequence
                        lis[i] < lis[j] + 1
                        )
                        lis[i] = lis[j] + 1;
                }
            }

            //Pick the maximum value
            for(i=0;i<n;i++)
            {
                if (lis[i] > max)
                    max = lis[i];
            }

            return max;
        }
    }
}
