using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TwentyOne
{

    /// <summary>
    /// The Dealer class that inherits from Person.
    /// </summary>
    class Dealer : Person
    {

        /// <summary>
        ///  Dealer class' constructor.
        /// </summary>
        /// <param name="name">Dealer name</param>
        /// <param name="boldness">Dealer boldness</param>
        /// <param name="hand">Dealer hand</param>
        public Dealer(string name, int boldness, Hand hand)
        : base(name, boldness, hand)
        {

        }

        /// <summary>
        /// A method that lets the Dealer deal a single card.
        /// </summary>
        /// <returns>Card</returns>
        public static Card DealSingleCard()
        {
            Card handoutCard = Deck.DeckOfCards[Deck.CardsInDeck() - 1];
            Deck.DeckOfCards.RemoveAt(Deck.CardsInDeck() - 1);
            
            return handoutCard;
        }

        /// <summary>
        /// Checks the amount of cards in Deck of Cards and takes the used Cards to keep playing.
        /// </summary>
        public static void ReshuffleEmptyDeck()
        {
            if (Deck.CardsInDeck() < 2)
            {
                foreach (var c in Deck.DeckOfCards)
                {
                    Card reshuffleCard = Deck.DeckOfCards[Deck.CardsInDeck() - 1];
                    Deck.UsedCards.Add(reshuffleCard);
                }

                Deck.DeckOfCards = Deck.UsedCards;
                Deck.Shuffle();
                Deck.UsedCards = new List<Card>();
            }
        }

    }
}