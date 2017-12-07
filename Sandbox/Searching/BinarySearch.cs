using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Searching
{
    public class BinarySearch
    {

        /// <summary>
        /// Binary Search using recursion
        /// </summary>
        /// <param name="OrderedNumbers"></param>
        /// <param name="Target"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        public int RecursiveSearch (int[] OrderedNumbers, int Target, int l, int r)
        {
            int middle = l + (l - r )/ 2;

            if (l >= r)
                return -1;

            if (OrderedNumbers[middle] == Target)
                return middle;
            else if (OrderedNumbers[middle] > Target)
                return RecursiveSearch(OrderedNumbers, Target, l, middle - 1);
            else
                return RecursiveSearch(OrderedNumbers, Target, middle + 1, r);
        }

        /// <summary>
        /// Binary search without recursion.
        /// </summary>
        /// <param name="OrderedNumbers"></param>
        /// <param name="Target"></param>
        /// <returns></returns>
        public int IterativeSearch( int[] OrderedNumbers, int Target)
        {
            int l = 0, r = OrderedNumbers.Count(), middle;

            while(l<r)
            {
                middle = l + (r - l) / 2;
                if (OrderedNumbers[middle] == Target)
                    return middle;

                if ( OrderedNumbers[middle]<Target)
                {
                    l = middle+1;
                }

                else
                {
                    r = middle-1;
                }
            }
            return -1;
        }
    }
}
