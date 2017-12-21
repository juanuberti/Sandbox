using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Sorting
{
    /// <summary>
    /// Similar to counting sort but works for non-discrete ranges (like floating point numbers)
    /// </summary>
    public class BucketSort
    {
        
        public static void Sort(float[] arr, int n)
        {

            // 1) Create n empty buckets

            Dictionary<int, List<float>> buckets = new Dictionary<int, List<float>>();

            // 2) Put array elements in their respective buckets

            for (int i = 0; i < n; i++)
            {
                int bucketIndex = (int)(n * arr[i]);

                if (buckets.ContainsKey(bucketIndex))
                    buckets[bucketIndex].Add(arr[i]);
                else
                {
                    buckets.Add(bucketIndex, new List<float>());
                    buckets[bucketIndex].Add(arr[i]);
                }
            }
            
            //Check each bucket in order, sort each inner list and add the results to the output sorted array.
            int index = 0;
            for (int i = 0;i<n;i++)
            {
                if(buckets.ContainsKey(i))
                {
                    // Sort each bucket
                    buckets[i].Sort(); //Default comparer is low to high. Implement a comparator otherwise if desired.

                    //Add them into the array in order.
                    foreach (float f in buckets[i])
                    {
                        arr[index] = f;
                        index++;
                    }
                }
            }
        }

        public static void Test()
        {
            Console.WriteLine("\n\nBucket Sorting test:\n");

            float[] arr = { 0.897f, 0.565f, 0.656f, 0.1234f, 0.665f, 0.3434f };
            int n = 6;

            Console.WriteLine("UnSorted array is: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + ", ");
            }

            Sort(arr, n);

            Console.WriteLine("Sorted array is: ");
            for(int i = 0; i < n ; i++)
            {
                Console.Write(arr[i] + ", ");
            }
        }
    

    }
}
