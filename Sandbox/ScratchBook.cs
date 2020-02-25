using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    /// <summary>
    /// placeholder class for all "Idk wtf this code will do or be good for so while I figure that out it has to go somewhere I guess?" snippets and WIPs'.
    /// </summary>
    public class ScratchBook
    {

        /// <summary>
        /// Placeholder for whatever disaster I am just about to unleash.
        /// </summary>
        public static void Test()
        {

        }

        /// <summary>
        /// Just a method I ran to test some things before. Will rename/replace/remove later.
        /// </summary>
        public static void DoTheThing()
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            string[] WordsToLookFor = { "citybody", "beach", "stuff", "thing" }; //Console.ReadLine().Split(' ');
                                                                                 //int NumberOfReviews = Convert.ToInt32(Console.ReadLine());



            Dictionary<int, Hotel> Hotels = new Dictionary<int, Hotel>();
            /*for (int i = 0; i < NumberOfReviews; i++)
            {
                int HotelID = Convert.ToInt32(Console.ReadLine());
                if (!Hotels.ContainsKey(HotelID))
                    Hotels.Add(HotelID, new Hotel(HotelID));
                Hotels[HotelID].Reviews.Add(Console.ReadLine());
            }
            */
            //All reviews loaded to their respective Hotel object.
            Hotels.Add(1, new Hotel(1));
            Hotels.Add(2, new Hotel(2));
            Hotels.Add(3, new Hotel(3));

            Hotels[1].Reviews.Add(" beach a a jdois asdoi");
            Hotels[1].Reviews.Add(" beach a djf akl fs ");
            Hotels[1].Reviews.Add(" city a djf akl fs thing"); //3

            Hotels[2].Reviews.Add(" beach a djf akl fs stuff");
            Hotels[2].Reviews.Add(" a djf akl fs "); //2

            Hotels[3].Reviews.Add(" beach citybody stuff a djf akl fs ");
            Hotels[3].Reviews.Add(" beach a djf thing stuffakl fs ");
            Hotels[3].Reviews.Add(" beach a djf akl citybody fs "); //most

            foreach (Hotel hotel in Hotels.Values)
            {
                foreach (string review in hotel.Reviews)
                    Console.WriteLine(review);
                foreach (string KeyWord in WordsToLookFor)
                {
                    var OccurencesOfWord = hotel.Reviews.Count(x => x.Contains(KeyWord));
                    Console.WriteLine("Hotel ID: " + hotel.ID + ", Keyword: " + KeyWord + ", count: " + OccurencesOfWord);
                    hotel.NumberOfKeywordsInReview += OccurencesOfWord;
                }
            }

            var myList = Hotels.Values.ToList();

            var sortedList = from hot in myList orderby hot.NumberOfKeywordsInReview descending select hot;



            foreach (var hotel in sortedList)
                Console.WriteLine(hotel.ID + ", " + hotel.NumberOfKeywordsInReview);
        }
        public class Hotel
        {
            public int ID { get; set; }
            public List<string> Reviews { get; set; }
            public int NumberOfKeywordsInReview { get; set; }

            public Hotel(int ID)
            {
                this.ID = ID;
                Reviews = new List<string>();
                NumberOfKeywordsInReview = 0;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int gcd(int a, int b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }

        


    }


}
