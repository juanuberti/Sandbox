using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Backtracking
{
    public class Sudoku
    {
        public const string UNSOLVED_SUDOKU = @"306508400520000000087000031003010080900863005050090600130000250000000074005206300";

        public const int size = 9;

        public static int[,] ReadSudokuIntoGrid(string sudoku)
        {
            int[,] grid = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    grid[i, j] = Int32.Parse(sudoku[i * size + j].ToString());
                }
            }
            return grid;
        }

        public static bool SolveSudoku(int[,] grid)
        {
            int row = -1;
            int col = -1;
            bool isEmpty = true;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (grid[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                {
                    break;
                }
            }
            if (isEmpty) return true;

            for (int num = 1; num <= 9; num++)
            {
                if (IsSafe(grid, row, col, num))
                {
                    grid[row, col] = num;
                    if (SolveSudoku(grid)) return true;
                    grid[row, col] = 0;
                }
            }
            return false;
        }

        public static bool IsSafe(int[,] grid, int row, int col, int num)
        {
            if (row < 0 || row > size || col < 0 || col > size) return false;
            for (int i = 0; i < 9; i++)
            {
                if (grid[i, col] == num || grid[row, i] == num)
                    return false;
            }

            int sqrt = (int)Math.Sqrt(size);
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
            {
                for (int c = boxColStart; c < boxColStart + sqrt; c++)
                {
                    if (grid[r, c] == num)
                        return false;
                }
            }
            return true;
        }

        public static void PrintSudoku(int[,] grid)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.Write("\n");
            }
        }

        public static void Test()
        {
            string sudoku = UNSOLVED_SUDOKU;
            int[,] gridSudoku = ReadSudokuIntoGrid(sudoku);
            if (SolveSudoku(gridSudoku))
            {
                PrintSudoku(gridSudoku);
            }
        }
    }
}
