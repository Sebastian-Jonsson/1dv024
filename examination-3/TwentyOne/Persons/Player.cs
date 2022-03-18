namespace TwentyOne
{
    /// <summary>
    /// Class Player that inherits from Person.
    /// </summary>
    class Player : Person
    {
        /// <summary>
        /// Constructor of Player.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="boldness"></param>
        /// <param name="hand"></param>
        public Player(string name, int boldness, Hand hand)
        : base(name, boldness, hand)
        {}

    }
}