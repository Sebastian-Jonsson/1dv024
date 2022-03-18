using System.Collections.Generic;

namespace Tjugoett
{
    public class Player
    {
        protected Hand _hand = new Hand();
        private int _satisfiedNum;

        private bool _isBusted = false;

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Satisfied
        {
            get { return _satisfiedNum; }
            set { _satisfiedNum = value; }
        }

        /// <summary>
        ///  Propertie for busted player
        /// </summary>
        /// <value>True or false</value>
        public bool IsBusted
        {
            get { return _isBusted; }
            set { _isBusted = value; }
        }
        
        public Player(string playerName, int satisfiedNumber)
        {
            Name = playerName;  
            Satisfied = satisfiedNumber;
        }

        /// <summary>
        /// When the player wants a card
        /// </summary>
        /// <param name="card">Card object</param>
        public void Hit(Card card)
        {
            _hand.AddCard(card);
        }
        
        /// <summary>
        /// The players total score
        /// </summary>
        /// <returns>total score of the players hand</returns>
        public int TotalScore()
        {
            return _hand.TotalScoreOfHand();
        }


        public List<Card> ThePlayerHand()
        {
            return _hand.HandOfPlayer;
        }

        /// <summary>
        /// Show the player hand
        /// </summary>
        /// <returns>Displays the players cards</returns>
        public string ShowHand()
        {
            return _hand.ShowTheHand();
        }

        /// <summary>
        /// Clears the hand for copies
        /// </summary>
        public void ClearHand()
        {
            _hand.HandOfPlayer.Clear();
        }

        /// <summary>
        /// Displays the name as a string
        /// </summary>
        /// <returns>The name as a string</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}