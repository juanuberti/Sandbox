using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Backtracking
{
    public class CombinationalSum
    {

        public static void findNumbers(ref List<int> ar, int sum, ref List<List<int>> resultSet, ref List<int> testSet, int i)
        {
            //sum of combination does not match the intended result
            if (sum < 0)
                return;

            //sum of combination is a match, add it to the result set,
            if (sum == 0)
            {
                resultSet.Add(new List<int>(testSet));
                return;
            }

            // Recur for all remaining elements that 
            // have value smaller than sum. 
            // ar is sorted low to high to avoid unnecessary recursion where its contents already exceed the intended sum
            while (i < ar.Count && sum - ar[i] >= 0)
            {
                //add the element to the set and test if the resulting set sum is equal or lower to the intended sum
                testSet.Add(ar[i]);

                //recur for all possible subsets to find those that match
                findNumbers(ref ar, sum - ar[i], ref resultSet, ref testSet, i);
                i++;

                //backtrack to let the next combination run through
                testSet.RemoveAt(testSet.Count - 1);
            }
        }

        /// <summary>
        /// // Returns all combinations of ar[] that have given sum
        /// </summary>
        /// <param name="ar"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public static List<List<int>> combinationSum(ref List<int> ar, int sum)
        {
            ar.Sort();
            ar = ar.Distinct().ToList();
            List<int> testSet = new List<int>();
            List<List<int>> resultSet = new List<List<int>>();

            findNumbers(ref ar, sum, ref resultSet, ref testSet, 0);

            return resultSet;
        }


        /// <summary>
        /// Driver code 
        /// </summary>
        public static void Test()
        {
            List<int> ar = new List<int>();
            ar.Add(2);
            ar.Add(4);
            ar.Add(6);
            ar.Add(8);
            int n = ar.Count;

            int sum = 8; // set value of sum 
            List<List<int>> res = combinationSum(ref ar, sum);

            // If result is empty, then 
            if (res.Count == 0)
            {
                Console.WriteLine("Empty list");
                return;
            }

            // Print all combinations stored in resultSet. 
            for (int i = 0; i < res.Count; i++)
            {
                if (res[i].Count > 0)
                {
                    Console.Write("( ");
                    for (int j = 0; j < res[i].Count; j++)
                        Console.Write(res[i][j] + " ");
                    Console.Write(")");
                }
            }
        }
    }
}
