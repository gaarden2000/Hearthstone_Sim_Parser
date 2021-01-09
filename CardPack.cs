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
                Card card5 = new Card(RarityRollerRigged());
                card5.id = IdRoller(card5.rarity, checklist);
                cardList.Add(card5);
            }
            else
            {
                Card card5 = new Card(RarityRoller());
                card5.id = IdRoller(card5.rarity, checklist);
                cardList.Add(card5);
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

            int rarityRoll = Globals.rnd.Next(0, 10001); // Next is inclusive lower bounds, exclusive upper bounds. Upper bound is to allow for a resolution of second decimal point

            // All numbers are from the original report working with several pack openings from Hearthsim
            // The numbers are based on the pull rate of each rarity, including golden rarities
            if (rarityRoll <= 7036)
            {
                rarity = "common";
            }
            else if (rarityRoll > 7036 && rarityRoll <= 9196)
            {
                rarity = "rare";
            }
            else if (rarityRoll > 9196 && rarityRoll <= 9604)
            {
                rarity = "epic";
            }
            else if (rarityRoll > 9604 && rarityRoll <= 9698)
            {
                rarity = "legendary";
            }
            else if (rarityRoll > 9698 && rarityRoll <= 9847)
            {
                rarity = "gCommon";
            }
            else if (rarityRoll > 9847 && rarityRoll <= 9973)
            {
                rarity = "gRare";
            }
            else if (rarityRoll > 9973 && rarityRoll <= 9993)
            {
                rarity = "gEpic";
            }
            else if (rarityRoll > 9993)
            {
                rarity = "gLegendary";
            }

            return rarity;
        }

        /*
         * Function: RarityRoller
         * Input: None
         * Output: The rarity of the card, in string format
         * Remarks: Is called in constructor, only if the previous four cards have not been rare or higher
         */
        public string RarityRollerRigged()
        {
            string rarity = "";

            int rarityRoll = Globals.rnd.Next(0, 10001); // Next is inclusive lower bounds, exclusive upper bounds

            if (rarityRoll <= 7671)
            {
                rarity = "rare";
            }
            else if (rarityRoll > 7671 && rarityRoll <= 9121)
            {
                rarity = "epic";
            }
            else if (rarityRoll > 9121 && rarityRoll <= 9455)
            {
                rarity = "legendary";
            }
            else if (rarityRoll > 9455 && rarityRoll <= 9905)
            {
                rarity = "gRare";
            }
            else if (rarityRoll > 9905 && rarityRoll <= 9974)
            {
                rarity = "gEpic";
            }
            else if (rarityRoll > 9974)
            {
                rarity = "gLegendary";
            }

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
