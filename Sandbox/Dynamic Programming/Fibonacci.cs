using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    /// <summary>
    /// Calculate fibonacci numbers the brute force way, then using memoization and tabulation methods.
    /// Idea and much of the code taken from http://www.geeksforgeeks.org/dynamic-programming-set-1/
    /// I haven't fo9und if the code there is licensed and how I should go about doing proper attribution. I'm just doing this for practice.
    /// </summary>
    public class Fibonacci
    {

        public const int NIL = -1;

        /// <summary>
        /// Lookup table of fibonacci values, used by the memoization technique.
        /// </summary>
        public static int[] Lookup = new int[int.MaxValue]; //Used for memoization method.

        /// <summary>
        /// Must be run before the memoizedFibonacci function can be called.
        /// </summary>
        public static void InitializeLookup()
        {
            for(int i=0;i<=int.MaxValue;i++)
            {
                Lookup[i] = NIL;
            }
        }

        /// <summary>
        /// Uses a lookup table for fibonacci values so any precomputed values can be reused without being added to the call stack.
        /// More efficient than the base recursive function; but requires a fixzed cost of initializing the lookup array before it can be used.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int MemoizedFibonacci (int number)
        {
            if (Lookup[number] == NIL)
            {
                if (number <= 1)
                    Lookup[number] = number;
                else
                    Lookup[number] = MemoizedFibonacci(number - 1) + MemoizedFibonacci(number - 2);
            }
            return Lookup[number];
        }

        /// <summary>
        /// Using tabulation, we create a lookup table and fill it up from the bottom up.
        /// We then return the lookup value of the last calculation.
        /// If our program needed to calculate many Fibonacci numebrs, it would be better to move the first lines of this method into an initialization function, like the memoization method uses, and to make the Lookup table static or at least a class variable.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int TabulatedFibonacci (int number)
        {
            int[] fib = new int[number];
            fib[0] = 1;
            fib[1] = 1;
            for(int i=2;i<=number;i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            return fib[number];
        }

        /// <summary>
        /// Basic brute-force recursive function for a fibonacci number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int RecursiveFibonacci(int number)
        {
            if (number <= 1)
                return number;
            else
                return RecursiveFibonacci(number-1) + RecursiveFibonacci(number - 2);
        }

        /// <summary>
        /// Example driver function that calls each different method.
        /// </summary>
        public static void Driver()
        {
            int number = 40;

            Console.WriteLine("Using recursion, the fibonacci number of 40 is " + RecursiveFibonacci(40));

            //Must Initialize lookup table before using memoization solution
            InitializeLookup();
            Console.WriteLine("Using Memoization, the fibonacci number of 40 is " + MemoizedFibonacci(number));

            Console.WriteLine("Using tabulation, the fibonacci number of 40 is " + TabulatedFibonacci(40));
        }
    }
}
