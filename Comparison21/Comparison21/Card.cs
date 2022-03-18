using System;

namespace Tjugoett
{

    /// <summary>
    /// Card class.
    /// Source: Mats 1dv024 Slack-chat message
    /// </summary>
    public class Card
    {
        public Rank Rank { get; }
        public Suit Suit { get; }
        public int Value => (int) Rank;
        


        /// <summary>
        /// Constructor of Card
        /// </summary>
        public Card(Suit suit,Rank rank)
        {
            Suit = Enum.IsDefined(typeof(Suit), suit) ? suit : throw new ArgumentException(nameof(suit));
            Rank = Enum.IsDefined(typeof(Rank), rank) ? rank : throw new ArgumentException(nameof(rank));;
        }

        /// <summary>
        /// Displays the card as a string
        /// </summary>
        /// <returns>Card as a string </returns>
        public override string ToString()
        {
            return $"{(char)Suit}{(Value > 1 && Value < 11 ? Value.ToString() : Rank.ToString().Substring(0, 1))}";
        }
    }
}