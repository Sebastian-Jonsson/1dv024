using System;
using System.Collections.Generic;

namespace TwentyOne{

    /// <summary>
    /// Class representing a hand.
    /// </summary>
    class Hand
    {

        /// <summary>
        /// The cards in the persons hand.
        /// </summary>
        /// <typeparam name="Card"></typeparam>
        /// <returns>A list to hold cards</returns>
        public List<Card> Fingers = new List<Card>();

        /// <summary>
        /// Sets the card to get privately.
        /// </summary>
        /// <value>Card</value>
        public static Card CardToGet { get; private set; }

        /// <summary>
        /// Method that adds a card to the players list of cards.
        /// </summary>
        /// <param name="CardToGet"></param>
        /// <returns></returns>
        public List<Card> AddCardToHand(Card CardToGet)
        {
            Fingers.Add(CardToGet);

            return Fingers;
        }
        
    }

}