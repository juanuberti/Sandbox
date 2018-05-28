using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Strings_and_substrings
{
    public class Permutations
    {

        public static string Swap (string str, int l, int r)
        {
            StringBuilder sb = new StringBuilder(str);
            sb[l] = str[r];
            sb[r] = str[l];
            return sb.ToString();
        }

        /// <summary>
        /// Prints out all possible permutations of a given string (including duplicates).
        /// O(n*n!) time complexity.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        private static void permute(string str, int l, int r)
        {
            if (l == r)
                Console.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = Swap(str, l, i);
                    permute(str, l + 1, r);
                    str = Swap(str, l, i);
                }
            }
        }

        public static void Test ()
        {
            string str = "ABCD";
            int len = str.Length;
            permute(str, 0, len-1);
        }

    }
}
