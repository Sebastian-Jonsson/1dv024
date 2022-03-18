namespace TwentyOne
{

    /// <summary>
    /// Class representing a basic card and it's contents.
    /// </summary>
    public class Card
    {

        /// <summary>
        ///  The Suit of a Card.
        /// </summary>
        /// <value></value>
        public string Suit { get; private set; }

        /// <summary>
        ///  The Value of a Card.
        /// </summary>
        /// <value></value>
        public int Value { get; set; }

        /// <summary>
        ///  Foundation of a card.
        /// </summary>
        /// <param name="suit">Suit of a Card</param>
        /// <param name="value">Value of a Card</param>
        public Card(string suit, int value)
        {
            Suit = suit;
            Value = value;

        }

        /// <summary>
        ///  Matches Value with Suit.
        /// </summary>
        /// <value>Visual</value>
        public string CardRanker =>
            Value switch
            {
                14 => Suit + "Ace",
                13 => Suit + "King",
                12 => Suit + "Queen",
                11 => Suit + "Jack",
                _ => Suit + Value
            };
    }
}