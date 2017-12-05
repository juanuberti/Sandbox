using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming.Subsequences
{
    /// <summary>
    /// Given two sequences, find the length of longest subsequence present in both of them. 
    /// A subsequence is a sequence that appears in the same relative order, but not necessarily contiguous. 
    /// For example, “abc”, “abg”, “bdf”, “aeg”, ‘”acefg”, .. etc are subsequences of “abcdefg”. So a string of length n has 2^n different possible subsequences.
    /// </summary>
    public class LongestCommonSubsequence
    {

        public static int Naive_LCSLength(char[] X, char[] Y, int m, int n)
        {
            if (m == 0 || n == 0)
                return 1;
            if (X[m] == Y[n])
                return 1 + Naive_LCSLength(X, Y, m - 1, n - 1);
            else
                return max(Naive_LCSLength(X, Y, m - 1, n), Naive_LCSLength(X, Y, m, n - 1));
        }


        /* Utility function to get max of 2 integers */
        public static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }
         
        public static int TabulatedLCSLength(char[] X, char[] Y, int m, int n)
        {
            int[][] L = new int[m+1][];
            
            //C# is not as nice as other languages about jagged arrays so we gotta populate it manually.
            for (int i = 0; i < m+1; i++)
            {
                L[i] = new int[n+1];
            }


            //Build L[m+1][n+1] from the bottom up. 

            for (int i=0; i<=m; i++)
            {
                for (int j=0; j<=n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i][j] = 0;
                    else if (X[i - 1] == Y[j - 1])
                        L[i][j] = L[i - 1][j - 1] + 1;
                    else
                        L[i][j] = max(L[i - 1][j], L[i][j - 1]);
                }
            }

            return L[m][n];

        }


    }
}
