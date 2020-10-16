using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

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
         * Function: WriteToCSV
         * Input: String array of all lines meant to be written to a file
         * Output: CSV file exported at given file path
         * Remarks: Uses File from System.IO in order to write. Is written in Globals as it is to be used by multiple functions
         */
        public static void WriteToCSV(string path, string[] CSVArray)
        {
            File.WriteAllLines(path, CSVArray); // Syntax is File.WriteAllLines(path, thing to print)
        }
    }
}
