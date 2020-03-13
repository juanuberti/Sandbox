using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Amz
    {
        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public static int minimumHours(int rows, int columns, int[,] grid)
        {
            int[,] temp;
            temp = copyArray(grid, rows, columns);

            int countOfServersWithFile = 0;

            int minimumHours = 0;
            while (countOfServersWithFile < rows * columns)
            {
                countOfServersWithFile = distributeFIleAccrossServers(grid, ref temp, rows, columns);
                grid = copyArray(temp, rows, columns);
                minimumHours++;
            }
            return minimumHours;

        }

        public static int[,] copyArray(int[,] originalArray, int rows, int columns)
        {
            int[,] newArray = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newArray[i, j] = originalArray[i, j];
                }
            }
            return newArray;
        }

        public static int distributeFIleAccrossServers(int[,] grid, ref int[,] nextIterationsGrid, int rows, int columns)
        {
            int countOfServersWithFile = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        countOfServersWithFile++;
                        if (i > 0)
                            nextIterationsGrid[i - 1, j] = 1;
                        if (i < rows - 1)
                            nextIterationsGrid[i + 1, j] = 1;
                        if (j > 0)
                            nextIterationsGrid[i, j - 1] = 1;
                        if (j < columns - 1)
                            nextIterationsGrid[i, j + 1] = 1;
                    }
                }
            }
            return countOfServersWithFile;
        }

        public static void a()
        {
            int[,] grid = { { 0, 1, 1, 0, 1 },{0, 1, 0, 1, 0},{0, 0, 0, 0, 1},{0, 1, 0, 0, 0}};
            minimumHours(4, 5, grid);
        }


        public static List<string> topNCompetitors(int numCompetitors,
                                        int topNCompetitors,
                                        List<string> competitors,
                                        int numReviews, List<string> reviews)
        {

            Dictionary<string, int> competitorHits = new Dictionary<string, int>();
            for (int i = 0; i < numCompetitors; i++)
            {
                competitorHits.Add(competitors[i].ToLower(), 0);
            }

            foreach (string review in reviews)
            {
                countCompetitorHitsInReview(ref competitorHits, review.ToLower());
            }

            int nComp = 0;

            List<string> output = new List<string>();

            if (topNCompetitors > numCompetitors)
                topNCompetitors = numCompetitors;

            foreach (var hit in competitorHits.OrderBy(x => x.Value).Select(x => x.Key))
            {
                output[nComp] = hit;
                if (nComp >= topNCompetitors)
                    break;
            }

            return output;

        }

        public static void countCompetitorHitsInReview(ref Dictionary<string, int> competitorHits, string review)
        {
            foreach (string competitor in competitorHits.Keys.ToList())
            {
                if (review.Contains(competitor))
                    competitorHits[competitor] += 1;
            }

        }

        public static void b()
        {
            List<string> a = new List<string>();
            a.Add("aa");
            a.Add("bb");
            List<string> b = new List<string>();
            b.Add("aa");
            b.Add("bb");
            b.Add("aa");
            topNCompetitors(1, 1, a, 3, b);
        }
    }
}
