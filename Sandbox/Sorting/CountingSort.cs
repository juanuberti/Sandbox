using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    public class CountingSort
    {

        /// <summary>
        /// Time Complexity: O(n+k) where k is the range of items
        /// Since we need to allocate an array of indexes for the whole range of k, this method is only viable for arrays with fixed ranges.
        /// This makes it infeasible for random int arrays (unless we know the minimum and maximum values therein), but it is good for chars since there are only 256 possible values.
        /// </summary>
        /// <param name="arr"></param>
        public static void SortCharArray(char[] arr)
        {
            // finding the length, min, max of the recieved list of numbers
            char element;

            // initialize counter for the range of elements. int arrays are initialized to 0 in C#.
            // The range of unsigned chars in C# is 0..255
            int[] count = new int[256];

            // count number of times each element occurs in the list
            for (int i = 0; i < arr.Length; i++)
            {
                element = arr[i];
                count[element]++;
            }

            // starting from the min element up to max element
            // we insert values according to their count in the new list in sorted order
            element = (char)0;

            //running index of position in the array.
            int index2 = 0;

            //instead of going element by element and filling out the list in place, we are rewriting the array from left to right.
            for (int i = 0; i < 256; i++)
            {
                int Count = count[i]; // How many times the ith element, from min to max, shows up.

                //Write in (Count) elements into the array.
                for (int j = 0; j < Count; j++)
                {
                    arr[index2] = element;
                    index2++;
                }
                //Get the next element.
                element ++;
            }
        }

        /// <summary>
        /// If we know the range of values (the minimum and maximum possible values in the array) we can Sort any list.
        /// Ofcourse, since CountSort has O(n+k) complexity, it is only really efficient if n is much larger than k.
        /// In this example we fill the array from beginning to end, as opposed to the char example which fills it in by element index, right to left.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="minElement"></param>
        /// <param name="maxElement"></param>
        public static void SortIntArray(int[] arr, int minElement, int maxElement)
        { 
            // finding the length, min, max of the recieved list of numbers
            int element;

            // initialize counter for the range of elements. int arrays are initialized to 0 in C#.
            int[] count = new int[maxElement - minElement + 1]; 
            

            // count number of times each element occurs in the list
            for (int i = 0; i < arr.Length; i++)
            {
                element = arr[i];
                count[element - minElement]++;
            }

            // starting from the min element up to max element
            // we insert values according to their count in the new list in sorted order
            element = minElement;

            //running index of position in the array.
            int index2 = 0;

            //instead of going element by element and filling out the list in place, we are rewriting the array from left to right.
            for (int i = 0; i < (maxElement - minElement + 1); i++)
            {
                int Count = count[i]; // How many times the ith element, from min to max, shows up.

                //Write in (Count) elements into the array.
                for (int j = 0; j < Count; j++)
                {
                    arr[index2] = element;
                    index2++;
                }
                //Get the next element.
                element += 1;
            }
        }

        public static void Test()
        {
            Console.WriteLine("\n\nCounting Sort test:\n");

            char[] arr = { 'g', 'e', 'e', 'k', 's', 'f', 'o', 'r', 'g', 'e', 'e', 'k', 's' };
            int[] arr2 = { 1, 2, 5, 4, 7, 8, 9, 6, 5, 4, 3, 2, 1, 5, 9, 7, 5, 3, 6, 5, 4 };

            Console.WriteLine("character array is:");
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + ", ");

            SortCharArray(arr);

            Console.WriteLine("\nSorted character array is:");
            for (int i = 0; i < arr.Length; ++i)
                Console.Write(arr[i] + ", ");

            Console.WriteLine("\n");

            Console.WriteLine("int array is:");
            for (int i = 0; i < arr2.Length; ++i)
                Console.Write(arr2[i] + ", ");

            int minValue = 1, maxValue = 9;
            SortIntArray(arr2, minValue, maxValue);


            Console.WriteLine("\nSorted int array is:");
            for (int i = 0; i < arr2.Length; ++i)
                Console.Write(arr2[i] + ", ");
        }
    }
}
