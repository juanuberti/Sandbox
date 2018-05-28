using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    public static class MinimumCostPath
    {
        /// <summary>
        /// Given a cost matrix cost[][] and a position (m, n) in cost[][], 
        /// write a function that returns cost of minimum cost path to reach (m, n) from (0, 0). 
        /// Each cell of the matrix represents a cost to traverse through that cell. 
        /// Total cost of a path to reach (m, n) is sum of all the costs on that path (including both source and destination). 
        /// You can only traverse down, right and diagonally lower cells from a given cell,
        /// i.e., from a given cell (i, j), cells (i+1, j), (i, j+1) and (i+1, j+1) can be traversed.
        /// You may assume that all costs are positive integers.
        /// </summary>
        /// <param name=""></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FindMinimumCostPath(int[,] cost, int m, int n)
        {
            //Indices for the arrays.

            int[,] tc = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {

                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        if (i == 0 && j == 0)
                            tc[0, 0] = cost[0, 0];
                        else if (i==0)
                            tc[i, j] = cost[i, j] + tc[i, j - 1];
                        else
                            tc[i, j] = cost[i, j] + tc[i-1, j];
                    }
                    else
                        tc[i, j] = min(tc[i - 1, j - 1],
                                       tc[i, j - 1],
                                       tc[i - 1, j]) + cost[i, j];
                }
            }
            return tc[m, n];

        }

        public static int min(int x, int y, int z)
        {
            if (x <= y && x <= z) return x;
            if (y <= x && y <= z) return y;
            return z;
        }

        public static void Test()
        {
            int[,] cost = {{1, 2, 3},
                    {4, 8, 2},
                    {1, 5, 3}};
            Console.WriteLine(FindMinimumCostPath(cost, 2, 2));
        }


    }
}
