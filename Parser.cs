using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthstone_Sim_Parser
{
    public class Parser
    {
        /*
         * Function: ReadFromCSV
         * Input: Set to find, path of the file to read from
         * Output: String array of all cards of a given set
         * Remarks: Being given the card set that one wishes to have all the cards for, and the path to read from, the function gathers all lines of card names from a given set
         */
        public static string[] ReadFromCSV(string set, string path)
        {
            // TODO
            // Find amount of cards to curate
            /// lineAmount
            /// Write correct cards
            



            int lineAmount = 1;
            string[] CSVArray = new string[lineAmount];

            return CSVArray;
        }


        /*
         * Function: FindIndex
         * Input: The character to find the index of, the string to find the characters in
         * Output: An array of indices for a given character
         * Remarks: This function is usually used for commas exclusively, and is necessary to finding out where the comparable pieces of writing lies
         */
        public static int[] FindIndex(char x, string parsedString)
        {
            int[] Indices = new int[11]; // Array to use
            int lastPos = 0; 

            // This for loop runs 11 times, once for each comma in the given line. lastPos is position of the comma from the previous run, and IndexOf goes from position "lastPos + 1" and forward until it finds char x
            for(int i = 0; i <= 10; i++)
            {
                lastPos = parsedString.IndexOf(x, lastPos + 1);
                Indices[i] = lastPos;
            }

            return Indices;
        }


    }
}
