using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Dynamic_Programming
{
    public class Substrings
    {
        /// <summary>
        /// Given an input string and a length num, return all substrings with exactly num distinct characters.
        /// </summary>
        /// <param name="inputStr"> (duh) the input string</param>
        /// <param name="num"> How many distinct, contiguous characters the substring must have. 
        /// eg: If InputStr was "abecedfhj" and num=4; the substrings returned would be {abec,cedf,edfh,dfhj} since they all have 4 contiguous distinct chars.</param>
        /// <returns></returns>
        public static List<string> subStringsKDist(string inputStr, int num)
        {
            char[] letters = inputStr.ToCharArray();
            List<string> substrings = new List<string>();

            for (int i = 0, n = letters.Count() - num; i <= n; i++)
            {
                HashSet<char> uniques = new HashSet<char>();

                for (int j = i, m = i + num; j < m; j++)
                {
                    uniques.Add(letters[j]);
                }

                if (uniques.Count == num)
                {
                    substrings.Add(inputStr.Substring(i, 4));
                }
            }
            return substrings;
        }

    }
}
