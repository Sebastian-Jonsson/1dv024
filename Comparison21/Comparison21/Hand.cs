using System.Collections.Generic;
using System;

namespace Tjugoett
{
    public class Hand
    {
        private List<Card> _handOfPlayer = new List<Card>();

        public List<Card> HandOfPlayer
        {
            get { return _handOfPlayer; }
        }
        
        /// <summary>
        /// Adds card to the hand
        /// </summary>
        /// <param name="card">card object</param>
        public void AddCard(Card card)
        {
            HandOfPlayer.Add(card);
        }


        /// <summary>
        /// The cards in the hand
        /// </summary>
        /// <returns>the cards as string</returns>
        public string ShowTheHand()
        {
            string cards = "";
            foreach (Card card in HandOfPlayer)
            {
                cards += card.ToString() + " ";
            }
            return cards;
        }

        /// <summary>
        /// Check the total score of the hand
        /// </summary>
        /// <returns>the total sum of the hand</returns>
        public int TotalScoreOfHand()
        {
            int sum = 0;
            int aces = 0;
            foreach (var card in HandOfPlayer)
            {
                if(card.Value == 14)
                {
                    aces += 1;
                }
                sum += card.Value;
            }
            while (sum > 21 && aces > 0)
            {
                sum -= 13;
                aces -= 1;
            }
            return sum;
        }
    }
}
