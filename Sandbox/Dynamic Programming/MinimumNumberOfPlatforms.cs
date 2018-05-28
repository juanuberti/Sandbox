using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    /// <summary>
    /// Given arrival and departure times of all trains that reach a railway station, find the minimum number of platforms required for the railway station so that no train waits.
    /// We are given two arrays which represent arrival and departure times of trains that stop
    /// Examples:
    /// Input:  arr[]  = {9:00,  9:40, 9:50,  11:00, 15:00, 18:00}
    /// dep[]  = {9:10, 12:00, 11:20, 11:30, 19:00, 20:00}
    /// Output: 3
    /// There are at-most three trains at a time(time between 11:00 to 11:20)
    /// </summary>
    public class MinimumNumberOfPlatforms
    {

        public static int NumberOfPlatformsNeeded(int[] arr, int[] dep)
        {
            //Sort the arrivals and departures.
            //For every train that arrives, you need one more platform available; for every train that departs a platform is freed.
            Sorting.QuickSort.RecursiveSort(arr, 0, arr.Length - 1);
            Sorting.QuickSort.RecursiveSort(dep, 0, dep.Length - 1);

            int PlatsNeeded = 0, l = 0, r = 0, MaxPlatsNeeded=0;

            //If a train departs before any arrive then logically there was already at least one train on the station, and as such one platform was needed.
            if (dep[0] < arr[0])
                PlatsNeeded++;

            //We only really care about arrivals, since the maximum number of platforms will never be greater than the number of arrivals.
            while (l < arr.Length)
            {
                //If the next event in time is a train arrival, one more platform is needed.
                if (arr[l] < dep[r])
                {
                    PlatsNeeded++;
                    l++;
                }
                else if (arr[l] > dep[r])
                {
                    PlatsNeeded--;
                    r++;
                }
                if (PlatsNeeded > MaxPlatsNeeded)
                    MaxPlatsNeeded = PlatsNeeded;
            }

            return MaxPlatsNeeded;

        }

        public static void Test()
        {
            int[] arr = { 900, 940, 950, 1100, 1500, 1800 };
            int[] dep = { 910, 1200, 1120, 1130, 1900, 2000 };

            Console.WriteLine("The minimum number of platforms needed is " + NumberOfPlatformsNeeded(arr, dep));
        }


    }
}
