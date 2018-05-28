using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    public class SubstringEqualToSum
    {

        public static void Doit(int[] arr, int S)
        {
            int sum;


            int number;
            int previousNumber = 0;

            int startIndex = 0, endIndex = 0;
            sum = 0;

            for (int j = 0; j < arr.Length; j++)
            {
                endIndex = j;
                if (sum == S)
                {

                    break;
                }

                number = arr[j];
                sum += number;

                if (sum > S)
                {
                    sum -= arr[startIndex];
                    startIndex++;

                    if (previousNumber > number)
                    {
                        sum -= arr[j];
                        j--;
                    }
                }
                previousNumber = number;


            }

            if (sum != S)
                Console.WriteLine(-1);
            else
                Console.WriteLine((startIndex + 1) + " " + (endIndex));

        }






        public static void Test()
        {
            int sum = 1562;

            int[] arr = { 28, 68, 142, 130, 41, 14, 175, 2, 78, 16, 84, 14, 193, 25, 2, 193, 160, 71, 29, 28, 85, 76, 187, 99, 171, 88, 48, 5, 104, 22, 64, 107, 164, 11, 172, 90, 41, 165, 143, 20, 114, 192, 105, 19, 33, 151, 6, 176, 140, 104, 23, 99, 48, 185, 49, 172, 65 };

            Doit(arr, sum);
        }


        void a()
        {


        }
    }
}
