using System;
using System.Collections.Generic;
using System.Text;

namespace Hearthstone_Sim_Parser
{
    /*
     * Class: CardPack
     * This class is meant primarily as a structure for the 5 cards
     */
    public class CardPack
    {
        // TODO
        /// The roller
        /// / Rarity roller
        /// // Make one guaranteed rare or better? Maybe a flag "hasGainedLegendary"
        /// / ID roller



        public CardPack(Checklist checklist)
        {
            Card card1 = new Card(RarityRoller());
            card1.id = IdRoller(card1.rarity, checklist);



        }

        /*
         * Function: RarityRoller
         * Input: None
         * Output: The rarity of the card, in string format
         * Remarks: Is called in constructor
         */
        public string RarityRoller()
        {
            string rarity;

            int rarityRoll = Globals.rnd.Next(0, 101);




            return rarity;
        }

        /*
         * Function: IdRoller
         * Input: 
         * Output: The card ID (which card out of the x amount in the given rarity of the set), in int format
         * Remarks: 
         */
        public int IdRoller(string rarity, Checklist checklist)
        {

        }

    }
}
