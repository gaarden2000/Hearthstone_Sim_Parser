using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            int lineAmount = FindLineAmount(set, path); // lineAmount determines how many lines is necessary to have in the array, aka amount of cards in the given set
            Console.WriteLine("Amount of lines to write found: " + lineAmount); // Written for clarity purposes
            
            string[] CSVArray = new string[lineAmount]; // array is initialised based on amount of lines found

            CSVArray = PopulateCSVArray(CSVArray, set, path); // array is populated

            return CSVArray;
        }

        /*
         * Function: FindLineAmount
         * Input: The set (as string) that is looked for in the file, the path (as string) to the file
         * Output: An integer of amount of lines to write
         * Remarks: None
         */
        public static int FindLineAmount(string set, string path)
        {
            int lineAmount = 1; // This variable is set to 1 in order to count the header at the top of the document

            using (StreamReader sr = new StreamReader(path)) // Reads the file given in path
            {
                string line; // String variable used to store the read line
                string cardTrue = "True"; // String to check for collectible flag of the card

                while ((line = sr.ReadLine()) != null) // Readline() goes to the next line of the file after being called. While loop breaks when ReadLine() returns null
                {
                    // This if statement is true if the following is true:
                    // The card is from the right set (line contains set)
                    // The card is a collectible card (line contains cardTrue = "True")
                    if (line.Contains(set) && line.Contains(cardTrue))
                    {
                        lineAmount++;
                    }
                }
            }

            return lineAmount;
        }

        /*
         * Function: PopulateCSVArray
         * Input: The string array to write to, the set (as string) that is looked for in the file, the path (as string) to the file
         * Output: The array containing the correct lines from the CSV file
         * Remarks: None
         */
        public static string[] PopulateCSVArray(string[] CSVArray, string set, string path)
        {

            using (StreamReader sr = new StreamReader(path)) // Reads the file given in path
            {
                CSVArray[0] = sr.ReadLine(); // First line of the file is the header, which should be included for neatness. StreamReader object remembers how many lines has been read, going down one line with every ReadLine()
                int arrayIndex = 1; // Integer to put a new line in a new index. Set to 1 because of the header

                string line; // String variable used to store the read line
                string cardTrue = "True"; // String to check for collectible flag of the card

                while ((line = sr.ReadLine()) != null) // Readline() goes to the next line of the file after being called. While loop breaks when ReadLine() returns null
                {
                    // This if statement is true if the following is true:
                    // The card is from the right set (line contains set)
                    // The card is a collectible card (line contains cardTrue = "True")
                    if (line.Contains(set) && line.Contains(cardTrue))
                    {
                        Console.Write(line); // Written for clarity purposes
                        CSVArray[arrayIndex] = line; // Line is added to the array
                        Console.WriteLine(" arrayIndex of line: " + arrayIndex); // Written for clarity purposes
                        arrayIndex++; // Increments arrayIndex so the next line to add will be on a new index
                    }
                }
            }
            return CSVArray;
        }

    }
}
