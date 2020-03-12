using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    /// <summary>
    /// Suppose that we wish to know which stories in a 36-story building are safe to drop eggs from, and which will cause the eggs to break on landing. We make a few assumptions:
    /// 
    /// …..An egg that survives a fall can be used again.
    /// …..A broken egg must be discarded.
    /// …..The effect of a fall is the same for all eggs.
    /// …..If an egg breaks when dropped, then it would break if dropped from a higher floor.
    /// …..If an egg survives a fall then it would survive a shorter fall.
    /// …..It is not ruled out that the first-floor windows break eggs, nor is it ruled out that the 36th-floor do not cause an egg to break.
    /// 
    /// If only one egg is available and we wish to be sure of obtaining the right result, the experiment can be carried out in only one way.Drop the egg from the first-floor window; if it survives, drop it from the second floor window.Continue upward until it breaks. In the worst case, this method may require 36 droppings.Suppose 2 eggs are available.What is the least number of egg-droppings that is guaranteed to work in all cases?
    /// The problem is not actually to find the critical floor, but merely to decide floors from which eggs should be dropped so that total number of trials are minimized.
    /// </summary>
    public class EggDroppingProblem
    {
        /// <summary>
        /// Utility function
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        /// <summary>
        /// Function to get minimum number of  
        /// trials needed in worst case with n
        /// eggs and k floors
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int eggDrop(int n, int k)
        {
            /// A 2D table where entry eggFloor[i,j]
            /// will represent minimum number of trials
            /// needed for i eggs and j floors
            int[,] eggFloor = new int[n + 1, k + 1];
            int res;
            int i, j, x;

            /// Base cases
            /// We need one trial for one floor
            /// and 0 trials for 0 floors.
            for(i =1; i<= n; i++)
            {
                eggFloor[i, 1] = 1;
                eggFloor[i, 0] = 0;
            }

            /// We always need j trials for one egg and j floors
            for (j = 1; j <= k; j++)
                eggFloor[1, j] = j;

            /// Fill the rest of the entries in table
            for(i = 2; i <= n; i++)
            {
                for (j = 2; j <= k; j++)
                {
                    eggFloor[i, j] = int.MaxValue;
                    for (x = 1; x <= j; x++)
                    {
                        res = 1 + Max(eggFloor[i-1,x-1], eggFloor[i, j-x]);
                        if (res < eggFloor[i, j])
                            eggFloor[i, j] = res;
                    }
                }
            }
            return eggFloor[n, k];
        }

        public static void Test()
        {
            int n = 2, k = 36;
            Console.WriteLine("Minimum number of trials "
               + "in worst case with " + n + " eggs and "
                     + k + "floors is " + eggDrop(n, k));
        }
    }
}
