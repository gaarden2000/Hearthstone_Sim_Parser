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
                    // Curate case, to test the parser.
                    case "curate":
                        Console.WriteLine("Which set do you wish to curate?");

                        string set = Console.ReadLine();

                        string[] CSVArray = Parser.ReadFromCSV(set, Globals.HSSetPath);

                        int arraySize = CSVArray.Count();
                        if(arraySize == 1)
                        {
                            Console.WriteLine("Error! Counted lines is only 1. Command will not continue.");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Total amount of lines found: " + arraySize);
                        }

                        Globals.WriteToCSV(Globals.HSCuratedPath, CSVArray);

                        Console.WriteLine("Write complete. Press any key to exit.");
                        Console.ReadKey();

                        run = false;
                        break;

                    case "exit":
                        run = false;
                        break;
                }

                
            }
            

        }


    }
}
