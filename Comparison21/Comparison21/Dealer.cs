namespace Tjugoett
{
    /// <summary>
    /// Inherits from the Player
    /// </summary>
    public class Dealer : Player
    {
        private bool _shouldPlay = true;

        /// <summary>
        /// Decides if the dealer should play
        /// </summary>
        /// <value>True or False</value>
        public bool ShouldPlay
        {
            get { return _shouldPlay; }
            set { _shouldPlay = value; }
        }
        
        /// <summary>
        /// Dealer constructor inherits from the player constructor
        /// </summary>
        /// <param name="playerName">Name for the player</param>
        /// <param name="satisfiedNumber">the number that dealer is going to stop picking cards</param>
        /// <returns></returns>
        public Dealer(string playerName, int satisfiedNumber) : base(playerName, satisfiedNumber)
        {
        }
    }
}