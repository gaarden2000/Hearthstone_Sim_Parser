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
            int lineAmount = FindLineAmount(set, path); // Function finds the amount of lines necessary in the array
            Console.WriteLine("Amount of lines found for writing found: " + lineAmount);

            string[] CSVArray = new string[lineAmount]; // Array meant for writing to a new file with the wanted set

            CSVArray = PopulateCSVArray(CSVArray, set, path);

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

                while((line = sr.ReadLine()) != null) // Readline() goes to the next line of the file after being called. While loop breaks when ReadLine() returns null
                {
                    int[] Indices = FindIndex(',', line); // Array of indices of commas of the given line

                    // This if statement is true if the following is true:
                    // The set read in the line is the same as the one given (set is the same as the set written in the line)
                    // The card is a collectible card (cardTrue is the same as the flag in the line)
                    if (set.Equals(line.Substring(Indices[1] + 1, 7)) && cardTrue.Equals(line.Substring(Indices[10] + 1, 4)))
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

                while((line = sr.ReadLine()) != null) // Readline() goes to the next line of the file after being called. While loop breaks when ReadLine() returns null
                {
                    int[] Indices = FindIndex(',', line);

                    // This if statement is true if the following is true:
                    // The set read in the line is the same as the one given (set is the same as the set written in the line)
                    // The card is a collectible card (cardTrue is the same as the flag in the line)
                    if (set.Equals(line.Substring(Indices[1] + 1, 7)) && cardTrue.Equals(line.Substring(Indices[10] + 1, 4)))
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
