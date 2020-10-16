﻿using System;

namespace Hearthstone_Sim_Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true; // Boolean made to run commands more than once per run of the program

            // TODO
            // Add info and disclaimer when program runs

            /*
             * This while loop is made to allow a command prompt-esque way of using the program. 
             * Adding this to the program allows it to be expanded with features further down the line. 
             */
            while (run)
            {
                
                Console.Write("Command: ");
                string command = Console.ReadLine().ToLower(); // Command is read and turned to lower case

                // Switch case based on written command
                switch (command)
                {
                    case "curate":
                        Console.WriteLine("Which set do you wish to curate?");
                        // TODO
                        // Write specific names for each set
                        string set = Console.ReadLine(); // Write which set to curate

                        // CSVArray is given from the parser, then written to the curated path
                        string[] CSVArray = Parser.ReadFromCSV(set, Globals.HSSetPath);
                        Globals.WriteToCSV(Globals.HSCuratedPath, CSVArray);
                        
                        Console.WriteLine("Write complete. Press any key to exit.");
                        Console.ReadKey();

                        run = false; // breaks the while loop and makes the program exit
                        break;

                }

                
            }
            

        }


    }
}
