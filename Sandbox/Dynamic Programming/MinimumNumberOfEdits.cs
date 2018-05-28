using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    public static class MinimumNumberOfEdits
    {

        /// <summary>
        /// Given two strings str1 and str2 and below operations that can performed on str1. Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’.
        /// Insert
        /// Remove
        /// Replace
        /// All of the above operations are of equal cost.
        /// </summary>
        /// <param name="str1"> Original string</param>
        /// <param name="str2"> Target string (what we want to convert str1 into)</param>
        /// <param name="m"> Length of str1 </param>
        /// <param name="n">Length of str2 </param>
        /// <returns></returns>
        public static int FindMinimumEdits(string str1, string str2, int m, int n)
        {
            // Create a table to store
            // results of subproblems
            int[,] dp = new int[m + 1, n + 1];

            //Fill dp[][] in bottom up manner

            for(int i = 0; i<= m; i++)
            {
                for(int j = 0;j<=n;j++)
                {
                    // If first string is empty, only option is to
                    // insert all characters of second string
                    if (i == 0)
                        //Min operations = j
                        dp[i, j] = j;

                    //If second string is empty, only option is to remove all characters of first string
                    else if (j == 0)
                        dp[i, j] = i;

                    //If last characters are same, ignore it and copy the diagonal value in the chart.
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];

                    //If the last characters are different, pick the minimum of all possibilities
                    else
                        dp[i, j] = 1 + min(dp[i, j - 1], // Insert
                                          dp[i - 1, j], // Remove
                                          dp[i - 1, j - 1] // Replace
                            );
                }
            }
            return dp[m, n];
        }

        public static int min(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= x && y <= z) return y;
            return z;
        }

        public static void Test()
        {
            string str1 = "sunday";
            string str2 = "saturday";
            Console.WriteLine(FindMinimumEdits(str1, str2, str1.Length,
                                                   str2.Length));
        }



    }
}
