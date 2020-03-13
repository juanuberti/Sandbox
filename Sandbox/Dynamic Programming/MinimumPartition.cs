using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    /// <summary>
    /// Given a set of positive integers S, partition the set S into two subsets S1, S2 such that the 
    /// difference between the sum of elements in S1 and the sum of elements in S2 is minimized.
    /// </summary>
    public class MinimumPartition
    {
        /// <summary>
        /// Partition the set S into two subsets S1, S2 such that the difference between
        /// the sum of elements in S1 and the sum of elements in S2 is minimized
        /// </summary>
        /// <param name="S">overall set</param>
        /// <param name="n">index of partition -- ie number of items of S that have been partitioned to either S1 or S2</param>
        /// <param name="S1">Sum of values in set 1</param>
        /// <param name="S2">Sum of values in set 2</param>
        /// <param name="lookup"></param>
        /// <returns></returns>
        public static int minPartition(int[] S, int n, int S1, int S2, ref Dictionary<String, int> lookup)
        {
            // base case: If the list becomes empty, return the absolute difference between the two sets
            if (n < 0)
                return Math.Abs(S1 - S2);

            // construct a unique map key from dynamic elements of the input.
            // Note thatw e can uniquely identify the subproblem with just n and S1, 
            // as S2 is nothing but sum(S) - S1
            string key = n + "|" + S1;

            //If sub-problem is seen for the first time, solve it and store its result in a map
            if (!lookup.ContainsKey(key))
            {
                // Case 1. Include current item in subset S1 and recur for remaining n-1 items
                int inc = minPartition(S, n - 1, S1 + S[n], S2, ref lookup);

                // Case 2. Include current item in subset S2 and recur for remaining n-1 items
                int exc = minPartition(S, n - 1, S1 , S2 + S[n], ref lookup);

                lookup.Add(key, Math.Min(inc, exc));
            }
            return lookup[key];
        }


        public static void Test()
        {
            // Input: set of items
            int[] S = { 10, 20, 15, 5, 25 };

            // create a map to store solutions of subproblems
            Dictionary<string, int> lookup = new Dictionary<string, int>();

            Console.WriteLine("The minimum difference is "
                    + minPartition(S, S.Length - 1, 0, 0, ref lookup));
            int a = 1;
        }

    }
}
