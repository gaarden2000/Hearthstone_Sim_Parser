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
        // TODO: Make things in constructor variables out here?

        public CardPack(Checklist checklist)
        {
            // A list is made to easily check through
            List<Card> cardList = new List<Card>();

            Card card1 = new Card(RarityRoller());
            card1.id = IdRoller(card1.rarity, checklist);
            cardList.Add(card1);

            Card card2 = new Card(RarityRoller());
            card2.id = IdRoller(card2.rarity, checklist);
            cardList.Add(card2);

            Card card3 = new Card(RarityRoller());
            card3.id = IdRoller(card3.rarity, checklist);
            cardList.Add(card3);

            Card card4 = new Card(RarityRoller());
            card4.id = IdRoller(card4.rarity, checklist);
            cardList.Add(card4);

            // Basically, if not a single card previously is rare or better
            if (card1.isNotCommon == false && card2.isNotCommon == false && card3.isNotCommon == false && card4.isNotCommon == false)
            {

            }

        }

        /*
         * Function: RarityRoller
         * Input: None
         * Output: The rarity of the card, in string format
         * Remarks: Is called in constructor
         */
        public string RarityRoller()
        {
            string rarity = "";

            int rarityRoll = Globals.rnd.Next(0, 101); // Next is inclusive lower bounds, exclusive upper bounds

            // TODO: Figure out where the hell these numbers came from
            if (rarityRoll <= 72)
            {
                rarity = "common";
            }
            else if (rarityRoll > 72 && rarityRoll <= 95)
            {
                rarity = "rare";
            }
            else if (rarityRoll > 95 && rarityRoll <= 99)
            {
                rarity = "epic";
            }
            else if (rarityRoll > 99)
            {
                rarity = "legendary";
            }

            return rarity;
        }

        public string RarityRollerRigged()
        {

        }

        /*
         * Function: IdRoller
         * Input: 
         * Output: The card ID (which card out of the x amount in the given rarity of the set), in int format
         * Remarks: 
         */
        public int IdRoller(string rarity, Checklist checklist)
        {
            int id = 0;

            if (rarity.Equals("common"))
            {
                id = Globals.rnd.Next(0, checklist.commonChecklistSize);
            }
            if (rarity.Equals("rare"))
            {
                id = Globals.rnd.Next(0, checklist.rareChecklistSize);
            }
            if (rarity.Equals("epic"))
            {
                id = Globals.rnd.Next(0, checklist.epicChecklistSize);
            }
            if (rarity.Equals("legendary"))
            {
                id = Globals.rnd.Next(0, checklist.legendaryChecklistSize);
            }

            return id;
        }

    }
}
