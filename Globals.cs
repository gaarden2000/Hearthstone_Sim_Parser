using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace Hearthstone_Sim_Parser
{
    /*
     * Class: Globals
     * This class contains several objects, variables, and functions that is used by more than one class in the program.
     * 
     */
    public class Globals
    {
        // Random object used for packs
        public static Random rnd = new Random();

        // File paths for reading and writing. Will be removed eventually to allow custom paths
        public static string HSSetPath = "hearthstone.csv"; // File containing all cards from several sets
        public static string HSCuratedPath = "hearthstonecurated.csv"; // File to write to, to contain all cards from the chosen set
        public static string HSDataPath = "packs.csv"; // File to write to, to contain all the data gathered from the simulation

        /*
         * Function: PromptConfirmation
         * Input: String of the question to give in the console
         * Output: True or false response
         * Remarks: y is yes, n is no
         */
        public static bool PromptConfirmation(string question)
        {
            bool confirmed = false;
            bool response = false;

            Console.WriteLine(question);

            while (confirmed != true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                Console.WriteLine();
                if (cki.Key.ToString().ToLower().Equals("y"))
                {
                    response = true;
                    confirmed = true;
                }
                else if (cki.Key.ToString().ToLower().Equals("n"))
                {
                    response = false;
                    confirmed = true;
                }
                else
                {
                    Console.WriteLine("Answer undefined.");
                }
            }

            return response;
        }

        /*
         * Function: WriteToCSV
         * Input: String array of all lines meant to be written to a file
         * Output: CSV file exported at given file path
         * Remarks: Uses File from System.IO in order to write. Is written in Globals as it is to be used by multiple functions
         */
        public static void WriteToCSV(string[] CSVArray, string path)
        {
            File.WriteAllLines(path, CSVArray); // Syntax is File.WriteAllLines(path, thing to print)
        }



    }
}
