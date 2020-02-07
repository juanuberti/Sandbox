using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Backtracking
{
    public class RatInAMaze
    {

        /// <summary>
        /// Consider a rat placed at (0, 0) in a square matrix m[][] of order n and has to reach the destination at (n-1, n-1). 
        /// Your task is to complete the function printPath() which returns a sorted array of strings denoting all the 
        /// possible directions which the rat can take to reach the destination at (n-1, n-1). 
        /// The directions in which the rat can move are 'U'(up), 'D'(down), 'L' (left), 'R' (right).
        /// </summary>
        /// <returns></returns>


        public static List<string> FindWayOutOfMaze(int[,] maze, int mazeLength)
        {
            bool[,] isVisited = new bool[mazeLength, mazeLength];
            string path = "";

            result = new List<string>();

            dfs("", maze, 0, 0, mazeLength - 1, isVisited, path);
            return result;
        }

        public static List<string> result;

        public static void dfs(string direction, int[,] maze, int i, int j, int mazeLength, bool[,] isVisited, string path)
        {
            if(i == mazeLength && j == mazeLength)
            {
                path = path + direction;
                result.Add(path);
                return;
            }

            if(i < 0 || i > mazeLength || j < 0 || j > mazeLength || isVisited[i,j] == true || maze[i,j] == 0)
                return;

            isVisited[i, j] = true;
            path = path + direction;
            dfs("D", maze, i + 1, j, mazeLength, isVisited, path);
            dfs("R", maze, i, j + 1, mazeLength, isVisited, path);
            dfs("U", maze, i - 1, j, mazeLength, isVisited, path);
            dfs("L", maze, i, j - 1, mazeLength, isVisited, path);
            isVisited[i, j] = false;
        }

        public static void Test()
        {
            const int n = 4;
            int[,] maze = new int[n, n] { { 1, 0, 0, 0 }, { 1, 1, 0, 1 }, { 0, 1, 0, 0 }, { 0, 1, 1, 1 } };
            FindWayOutOfMaze(maze, n);
        }

    }
}
