using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;


namespace Sandbox
{

    /// <summary>
    /// Might (should?) be renamed. It's basically the function that runs all test scenarios as requested from the main Form.
    /// </summary>
    public class Controller
    {

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
            Hotels.Add(1, new Sandbox.Controller.Hotel(1));
            Hotels.Add(2, new Sandbox.Controller.Hotel(2));
            Hotels.Add(3, new Sandbox.Controller.Hotel(3));

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

        // METHOD SIGNATURE ENDS

        /// <summary>
        /// Needs to be moved elsewhere. A base class for a problem I worked on earlier.
        /// </summary>
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
    }
}