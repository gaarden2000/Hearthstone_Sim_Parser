using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthstone_Sim_Parser
{
    /*
     * Class: Card
     * A class meant to be used for the building of, and editing of, a card object
     */
    public class Card
    {
        // Variables necessary for the card; will be set at constructor
        public string rarity { get; set; }
        public bool isNotCommon { get; set; }
        public int id { get; set; }

        public Card(string Rarity)
        {
            rarity = Rarity;
            
            // if statement sets isNotCommon flag for purposes in CardPack
            if (rarity.Equals("common"))
            {
                isNotCommon = false;
            }
            else
            {
                isNotCommon = true;
            }

        }

        


    }


}
