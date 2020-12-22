using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthstone_Sim_Parser
{
    public class Checklist
    {
        // TODO
        /// Add variables for:
        /// / Amount of packs opened
        /// / Craft value
        /// / Dust value
        /// / Dust amount
        /// / Dust reguired
        
        
        // Amount of cards necessary to checklist for each rarity
        public int commonChecklistSize { get; set; }
        public int rareChecklistSize { get; set; }
        public int epicChecklistSize { get; set; }
        public int legendaryChecklistSize { get; set; }


        // Array names for class
        public int[] commonChecklist { get; set; }
        public int[] rareChecklist { get; set; }
        public int[] epicChecklist { get; set; }
        public int[] legendaryChecklist { get; set; }


        public Checklist(string[] CSVArray)
        {
            /// 4 arrays (based on rarity)
            /// Init based on CSVarray

            int[] arraySizes = FindArraySizes(CSVArray);

            commonChecklistSize = arraySizes[0];
            rareChecklistSize = arraySizes[1];
            epicChecklistSize = arraySizes[2];
            legendaryChecklistSize = arraySizes[3];

            commonChecklist = new int[commonChecklistSize];
            rareChecklist = new int[rareChecklistSize];
            epicChecklist = new int[epicChecklistSize];
            legendaryChecklist = new int[legendaryChecklistSize];

        }


        private int[] FindArraySizes(string[] CSVArray)
        {
            int[] arraySizes = new int[4];

            foreach (string String in CSVArray)
            {
                if (String.Contains("Common"))
                {
                    arraySizes[0]++;
                }
                else if (String.Contains("Rare"))
                {
                    arraySizes[1]++;
                }
                else if (String.Contains("Epic"))
                {
                    arraySizes[2]++;
                }
                else if (String.Contains("Legendary"))
                {
                    arraySizes[3]++;
                }
            }

            return arraySizes;
        }


    }
}
