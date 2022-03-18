using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tjugoett
{
    public class Deck
    {
        public List<Card> deck;
        static public List<Card> CardPile = new List<Card>();

        //konstruktorn
        public Deck()
        {
            CreateDeck();
        }
        
        /// <summary>
        /// When a new instance of Deck.cs is created a deck of cards will be created
        /// </summary>
        private void CreateDeck()
        {
            deck = new List<Card>();
            foreach (var suit in (Suit[])Enum.GetValues(typeof(Suit)))

            {
                foreach (var rank in (Rank[])Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
            Shuffle();
        }

        /// <summary>
        /// Shuffles the deck source: https://codereview.stackexchange.com/questions/136341/fisher-yates-shuffle-in-c 
        /// and the task from 1dv021
        /// </summary>
        private void Shuffle()
        {
            Random random = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(deck.Count - i);
                Card swap = deck[i];
                deck[i] = deck[randomIndex];
                deck[randomIndex] = swap;
            }
        }

        /// <summary>
        /// Deals a card. If the deck has 1 card left, take the card pile and add it back to the deck.
        /// </summary>
        /// <returns>Card object</returns>
        public Card DealCard()
        {
            if(deck.Count == 1)
            {
                foreach (var cards in CardPile)
                {
                    deck.Add(cards);
                }
                Shuffle();
                CardPile.Clear();
            }
            var card = deck.First();

            deck.Remove(card);

            return card;
        }
    }
} 