using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{

    /// <summary>
    /// Helper methods that populate basic datatables or structures to query/compare/operate on.
    /// </summary>
    public class Inputs
    {


        /// <summary>
        /// Creates a sample datatable with generic columns and values for quick offhand querying and LINQ groupings
        /// </summary>
        /// <returns></returns>
        public static DataTable SampleTable1()
        {
            DataTable table = new DataTable();

            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Category or idk", typeof(int));
            table.Columns.Add("Price Or Whatever", typeof(decimal));
            table.Columns.Add("Comma Separated Tags", typeof(string));
            table.Columns.Add("Reference", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));
            table.Columns.Add("End Date", typeof(DateTime));

            table.LoadDataRow(new object[] { "1", "Object 1", "Type 1", "A long description of things or words I may be looking for and may be tasked with ranking by repetition of words I may be looking for", 1, (decimal)100.35, "A,List,Of,Comma,Separated,Tags,Associated,With,This,Entry", "",       new DateTime(2017, 1, 1), new DateTime(2017, 6, 30) },false);
            table.LoadDataRow(new object[] { "2", "Object 2", "Type 2", "long description words may lookin for ",                                                                                                2, (decimal)10.65, "some,more,separated,tags", "1",                                        new DateTime(2017, 1, 1), new DateTime(2017, 6, 30 ) }, false);
            table.LoadDataRow(new object[] { "3", "Object 3", "Type 1", "ranking ranking ranking ranking ranking ranking",                                                                                       1, (decimal)100, " some, tags, with, spaces, because, reasons", "1,2",                     new DateTime(2017, 1, 1), new DateTime(2017, 6, 30) }, false);
            table.LoadDataRow(new object[] { "4", "Object 4", "Type 2", "Lorem Ipsum something something dark side",                                                                                            2, (decimal)120.66, "Star Wars,Star,Wars,Palpatine,The Force, Lorem, Lorem Ipsum", "5,6,13", new DateTime(2017, 5, 4), new DateTime(2017, 12, 31) }, false);
            table.LoadDataRow(new object[] { "5", "Object 5", "Type 1", "Something Something Dark Side",                                                                                                        1, (decimal)12, "Star Wars,Star,Wars,Palpatine,The Force", "4,6,13",                        new DateTime(2017, 5, 4), new DateTime(2017, 12, 31) }, false);
            table.LoadDataRow(new object[] { "6", "Object 6", "Type 2", "Something something complete",                                                                                                         2, (decimal)100.35, "Star Wars,Star,Wars,Palpatine", "4,5,13",                              new DateTime(2017, 5, 4), new DateTime(2017, 12, 31) }, false);
            table.LoadDataRow(new object[] { "7", "Object 7", "Type 3", "bird bird bird, bird is the word",                                                                                                     3, (decimal)1000, "Family Guy", "8",                                                        new DateTime(2017, 2, 1), new DateTime(2020, 1, 11) }, false);
            table.LoadDataRow(new object[] { "8", "Object 8", "Type 5", "I say a bird bird bird, b-bird's the word",                                                                                            3, (decimal)10000, "Family Guy,Bird", "7",                                                  new DateTime(2017, 2, 1), new DateTime(2018, 12, 31) }, false);
            table.LoadDataRow(new object[] { "9", "Object 9", "Type 5", "Someday I will be I'll be those common words",                                                                                         4, (decimal)10000, "AFI", "10",                                                             new DateTime(2017, 3, 1), new DateTime(2040, 1, 1) }, false);
            table.LoadDataRow(new object[] { "10", "Object 10", "Type 5", "spoken uniquely",                                                                                                                    5, (decimal)1001, "AFI", "9",                                                               new DateTime(2017, 3, 1), new DateTime(2017, 1, 1) }, false);
            table.LoadDataRow(new object[] { "11", "Object 11", "Type 5", "not much of a description here",                                                                                                     5, (decimal)10001, "blah", "",                                                              new DateTime(2017, 10, 1), new DateTime(2100, 12, 31) }, false);
            table.LoadDataRow(new object[] { "12", "Object 12", "Type 5", "mentions of some words but not much to see",                                                                                         5, (decimal)1, "", "",                                                                      new DateTime(2017, 11, 1), new DateTime(2017, 11, 2) }, false);
            table.LoadDataRow(new object[] { "13", "Object 13", "Type A", "These are not the droids you're looking for",                                                                                        1, (decimal)-10, "Star Wars, The Force,", "4,5,6",                                          new DateTime(2017, 6, 4), new DateTime(2017, 12, 31) }, false);
            /*table.LoadDataRow(new object[] { "14", "Object 14", "Type B", "description", 1, (decimal)100.35, "tags", "", new DateTime(2017, 1, 1), new DateTime(2017, 12, 31) }, false);
            table.LoadDataRow(new object[] { "15", "Object 15", "Type A", "description", 1, (decimal)100.35, "tags", "", new DateTime(2017, 1, 1), new DateTime(2017, 12, 31) }, false);
            table.LoadDataRow(new object[] { "16", "Object 16", "Type B", "description", 1, (decimal)100.35, "tags", "", new DateTime(2017, 1, 1), new DateTime(2017, 12, 31) }, false);
            table.LoadDataRow(new object[] { "17", "Object 17", "Type C", "description", 1, (decimal)100.35, "tags", "", new DateTime(2017, 1, 1), new DateTime(2017, 12, 31) }, false);
            */
            return table;
        }

    }
}
