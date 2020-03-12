using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    public class EditDistance
    {
        /// <summary>
        /// Given two strings str1 and str2 and below operations that can performed on str1. Find minimum number of edits (operations) required to convert ‘str1’ into ‘str2’.
        ///     Insert
        ///     Remove
        ///     Replace
        /// All of the above operations are of equal cost.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="m">Length of str1 (first string)</param>
        /// <param name="n">Length of str2 (second string)</param>
        /// <returns></returns>
        public static int EditDist(string str1, string str2, int m, int n)
        {
            // Create a table to store 
            // results of subproblems 
            int[,] subres = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for(int j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to insert all characters of str2
                    if (i == 0)
                        subres[i, j] = j;
                    // If second string is empty, only option is to insert all characters of str1
                    else if (j == 0)
                        subres[i, j] = i;
                    // If last characters are the same, ignore them and recur for the remaining substrings
                    else if (str1[i - 1] == str2[j - 1])
                        subres[i, j] = subres[i - 1, j - 1];

                    else
                        subres[i, j] = 1 + min(subres[i, j - 1],   // Insert
                                              subres[i - 1, j], // Remove
                                              subres[i - 1, j - 1] // Replace
                                              );
                }
            }

            return subres[m, n];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static int min(int x, int y, int z)
        {
            if (x <= y && x <= z)
                return x;
            if (y <= x && y <= z)
                return y;
            else
                return z;
        }

        public static void Test()
        {
            String str1 = "sunday";
            String str2 = "saturday";
            Console.Write(EditDist(str1, str2, str1.Length,
                                     str2.Length));
        }
    }
}
