using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Heaps
{
    /// <summary>
    /// TODO: reorganize.
    /// Methods and scenarios related to one test question about running medians.
    /// Should be split into more relevant files/etc.
    /// </summary>
    public class Controller
    {
/// <summary>
        /// Very basic test-case driver.
        /// </summary>
        public static void TestScenario()
        {
            int[] TestInput = { 6, 12, 4, 5, 3, 8, 7 };

            Console.WriteLine(FindMedian(TestInput));
        }

        /// <summary>
        /// Use heaps to find a running median in an array of integers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double FindMedian(int[] input)
        {
            MaxHeap lowerHalfHeap = new MaxHeap(input.Length/2);
            Heap upperHalfHeap = new Heap(input.Length/2);
            foreach (int item in input)
            {
                if (lowerHalfHeap.Size <= upperHalfHeap.Size)
                    lowerHalfHeap.Add(item);
                else
                    upperHalfHeap.Add(item);
                Heap.Balance(lowerHalfHeap,upperHalfHeap);
            }

            if (input.Length % 2 == 0)
                return (double)(lowerHalfHeap.Peek() + upperHalfHeap.Peek()) / 2;
            else
                return (double)lowerHalfHeap.Peek();
        }

    }
}