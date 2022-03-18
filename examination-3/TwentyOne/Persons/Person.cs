namespace TwentyOne{

    /// <summary>
    /// Class of Person which will be overwritten by specific types of persons.
    /// </summary>
    abstract class Person
    {
        /// <summary>
        /// Constructor of class Person.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="boldness"></param>
        /// <param name="hand"></param>
        protected Person(string name, int boldness, Hand hand)
        {
            Name = name;
            Boldness = boldness;
            Hand = hand;
        }

        /// <summary>
        /// Name to be set.
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }

        /// <summary>
        /// Boldness to be set.
        /// </summary>
        /// <value></value>
        public int Boldness { get; private set; }

        /// <summary>
        /// Hand to be set.
        /// </summary>
        /// <value></value>
        public Hand Hand { get; private set; }

        /// <summary>
        /// Sets the int of total value in the hand.
        /// </summary>
        private int TotalValue;

        /// <summary>
        /// Calculates he total value of the cards in the hand.
        /// </summary>
        /// <returns>TotalValue</returns>
        public int TotalHandValue()
        {
            TotalValue = 0;
            for (int i = 0; i < Hand.Fingers.Count; i++)
            {
                TotalValue += Hand.Fingers[i].Value;
            }
            return TotalValue;
        }
    }

}