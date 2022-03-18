using System;
using System.Collections.Generic;

namespace TwentyOne
{

    /// <summary>
    /// The class Table which joins the different required parts together.
    /// </summary>
    class Table
    {        
        /// <summary>
        /// Creates a list of the Participants of the game.
        /// </summary>
        /// <typeparam name="Player"></typeparam>
        /// <returns>Players</returns>
        public static List<Player> Participants = new List<Player>();

        /// <summary>
        /// Creates and sets the values of this games Dealer.
        /// </summary>
        /// <returns>A Dealer</returns>
        public static Dealer GameDealer = new Dealer("Dealer Sven", 19, new Hand());

        /// <summary>
        /// Sets the minimum boldness of the players.
        /// </summary>
        private static int MinBoldness = 15;

        /// <summary>
        /// Sets the maximum boldness of the players.
        /// </summary>
        private static int MaxBoldness = 20;

        /// <summary>
        /// Sets the amount of players in the game.
        /// </summary>
        public static int PlayerAmount = 30;

        /// <summary>
        /// Calls the methods to initialize the game from the different classes and itself.
        /// </summary>
        public static void GameStart()
        {
            Deck.ShuffleDeck();
            CreatePlayers(PlayerAmount);
            Rules.GameRounds();
        }

        /// <summary>
        /// A method that creates the players within set rules with their "unique" names and adds them to the Participants list.
        /// </summary>
        /// <param name="AmountOfPlayers"></param>
        private static void CreatePlayers(int AmountOfPlayers)
        {
            if (AmountOfPlayers < 1 || AmountOfPlayers > 30)
            {
                throw new ArgumentOutOfRangeException("There must be a minimum of 1 and a max 30 players.");
            }
            for (var i = 1; i <= AmountOfPlayers; i++)
            {
                string name = "Person #" + i;
                int boldness = PlayerBoldness(MinBoldness, MaxBoldness);

                Participants.Add(new Player(name, boldness, new Hand()));
            }
        }

        /// <summary>
        /// Helps set the random boldness for each player.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        private static int PlayerBoldness(int min, int max)
        {
            Random rnd = new Random(); 
            
            return rnd.Next(min, max);
        }
    }
}