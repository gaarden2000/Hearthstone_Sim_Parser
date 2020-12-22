using System;
using System.Linq;

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
                    case "findset": // Curate case, to test the parser.
                        Console.WriteLine("Which set do you wish to use?");

                        string set = Console.ReadLine(); // Set given by user

                        string[] CSVArray = Parser.ReadFromCSV(set, Globals.HSSetPath); // Returns an array based on the hearthstone.csv file, based on the set written

                        int arraySize = CSVArray.Count(); // array size is counted
                        if(arraySize == 1) // This should only occur if the set written is wrong, meaning the array only includes the header
                        {
                            Console.WriteLine("Error! Counted lines is only 1. Command will not continue.");
                            break; // This breaks out of the switch case
                        }
                        else
                        {
                            Console.WriteLine("Total amount of cards found: " + (arraySize - 1)); // arraySize-1 is amount of cards minus the header line
                        }

                        Console.WriteLine("What do you wish to do with the set?");
                        command = Console.ReadLine();

                        if (command.Equals("curate"))
                        {
                            Globals.WriteToCSV(CSVArray, Globals.HSCuratedPath); // The array is written to the file

                            Console.WriteLine("Write complete. Press any key to exit.");
                            Console.ReadKey();
                        }
                        else if (command.Equals("simulate"))
                        {
                            // TODO
                            // Write simulation here

                            // Create object based on:
                            /// Previously curated stuff
                            /// Cardroller (uses checklist and also makes the lines as previous roller)
                            /// Present info
                            /// Save info

                            Checklist checklist = new Checklist(CSVArray);

                            Console.WriteLine("Array sizes: ");
                            Console.WriteLine("Common: " + checklist.commonChecklistSize);
                            Console.WriteLine("Rare: " + checklist.rareChecklistSize);
                            Console.WriteLine("Epic: " + checklist.epicChecklistSize);
                            Console.WriteLine("Legendary: " + checklist.legendaryChecklistSize);

                            if(Globals.PromptConfirmation("Are the amounts correct?"))
                            {
                                Console.WriteLine("Moving on.");
                            }
                            else
                            {
                                Console.WriteLine("Exiting. Please check your card source file or set name for inconsistencies.");
                                Environment.Exit(0);
                            }
                            

                            Console.WriteLine("Writing to file.");
                            Globals.WriteToCSV(CSVArray, Globals.HSCuratedPath); // The array is written to the file

                            Console.WriteLine("Write complete. Press any key to exit.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Command not recognised. Command will not continue.");
                            break;
                        }
                        

                        run = false;
                        break;

                    case "exit": // exit case
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Command not recognized.");
                        break;
                }

                
            }
            

        }


    }
}
