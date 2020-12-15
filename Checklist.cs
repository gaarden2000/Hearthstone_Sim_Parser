using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthstone_Sim_Parser
{
    public class Checklist
    {
     
        // Array names for class
        public int[] commonArray { get; set; }
        public int[] rareArray { get; set; }
        public int[] epicArray { get; set; }
        public int[] legendaryArray { get; set; }


        public Checklist(string[] CSVArray)
        {
            /// 4 arrays (based on rarity)
            /// Init based on CSVarray

            int[] arraySizes = FindArraySizes(CSVArray);

            commonArray = new int[arraySizes[0]];
            rareArray = new int[arraySizes[1]];
            epicArray = new int[arraySizes[2]];
            legendaryArray = new int[arraySizes[3]];

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
