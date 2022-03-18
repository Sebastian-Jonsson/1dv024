using System;
using System.Collections.Generic;
using System.Linq;

namespace TwentyOne
{

    /// <summary>
    ///  A Class that represents a new Deck that's produced shuffled.
    /// </summary>
    class Deck
    {

        /// <summary>
        ///  Constructor of the class Deck.
        /// </summary>
        public Deck() {
            ShuffleDeck();
        }

        /// <summary>
        ///  The Deck of Cards to be played with.
        /// </summary>
        public static List<Card> DeckOfCards;

        /// <summary>
        ///  The pile where one throws used cards.
        /// </summary>
        /// <typeparam name="Card">Card</typeparam>
        /// <returns></returns>
        public static List<Card> UsedCards = new List<Card>();
    
        /// <summary>
        ///  Counts the amount of cards in the Deck of Cards.
        /// </summary>
        /// <returns>The amount of cards.</returns>
        public static int CardsInDeck()
        {
           return DeckOfCards.Count(); 
        } 

        /// <summary>
        ///  Creation of the Deck of Cards, based on Suit and Value.
        /// </summary>
        /// <returns>A new Deck of Cards.</returns>
        private static List<Card> DeckCreation()
        {

            List<Card> DeckOfCards = new List<Card>();
            var suit = new[] { "♠", "♥", "♦", "♣" };
            var value = new[] { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            foreach (var i in suit)
                foreach (var k in value)
                    DeckOfCards.Add(new Card(i, k));

            return DeckOfCards;
        }

        /// <summary>
        ///  A shuffle method.
        /// </summary>
        public static void Shuffle() 
        {
            Random rng = new Random();

            int i = DeckOfCards.Count;

            while (i > 1)
            {
                i--;
                int j = rng.Next(i + 1);
                Card card = DeckOfCards[j];
                DeckOfCards[j] = DeckOfCards[i];
                DeckOfCards[i] = card;
            }
        }
        
        /// <summary>
        ///  Takes the new Deck of Cards and shuffles it.
        /// </summary>
        public static void ShuffleDeck() 
        {
            DeckOfCards = DeckCreation();
            Shuffle();
        }

    }

}