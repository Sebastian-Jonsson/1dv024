using System.Collections.Generic;
using System;

namespace Tjugoett
{
    public class Game
    {
        // skapa lista med spelare
        public List<Player> allPlayers = new List<Player>();
        Random rnd = new Random();
        Dealer dealer = new Dealer("Dealer", 18);
        Deck deckOfCards = new Deck();
        public void GameOn(int players)
        {
            CheckIfTooManyPlayers(players);
            GeneratePlayers(players);
            
            foreach (Player player in allPlayers)
            {
                do
                {
                   player.Hit(deckOfCards.DealCard());
                } while (SatisfiedPlayer(player, dealer));

                if(dealer.ShouldPlay)
                {
                    do
                    {
                        dealer.Hit(deckOfCards.DealCard());
                    } while (SatisfiedDealer(dealer));
                }
                System.Console.WriteLine();
                CompareResults(player, dealer);
                
                ThrowCards(player.ThePlayerHand());
                ThrowCards(dealer.ThePlayerHand());

                player.ClearHand();
                dealer.ClearHand();
                dealer.ShouldPlay = true;
                dealer.IsBusted = false;
            }
        }

        /// <summary>
        /// Creates the amount of players and gives them one card each
        /// </summary>
        /// <param name="numOfPlayers">Number of players</param>
        public void GeneratePlayers(int numOfPlayers)
        {
            for (int i = 0; i < numOfPlayers; i++)
            {
                Player player = new Player("Player" + (i+1), rnd.Next(15, 19));
                player.Hit(deckOfCards.DealCard());
                allPlayers.Add(player);
            }
        }

        public void CheckIfTooManyPlayers(int numOfPlayers)
        {
            if(numOfPlayers > 45)
            {
                throw new ArgumentException($"Max players is 45, you selected: {numOfPlayers.ToString()}");
            }
            
        }

        /// <summary>
        /// Throws the cards to the Card pile
        /// </summary>
        /// <param name="playersHand">List with cards</param>
        public void ThrowCards(List<Card> playersHand)
        {
            foreach (var card in playersHand)
            {
                Deck.CardPile.Add(card);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player">Player object</param>
        /// <param name="dealer">Dealer object</param>
        /// <returns></returns>
        public bool SatisfiedPlayer(Player player, Dealer dealer)
        {
            if(player.TotalScore() == 21)
            {
                dealer.ShouldPlay = false;
                return false;
            }
            else if(player.TotalScore() < 22 && player.ThePlayerHand().Count == 5)
            {
                dealer.ShouldPlay = false;
                return false;
            }
            else if(player.TotalScore() >= player.Satisfied && player.TotalScore() < 21)
            {
                return false;
            }
            else if(player.TotalScore() > 21)
            {
                player.IsBusted = true;
                dealer.ShouldPlay = false;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dealer">Dealer object</param>
        /// <returns>True or false</returns>
        public bool SatisfiedDealer(Dealer dealer)
        {
            if(dealer.TotalScore() == 21)
            {
                return false;
            }
            else if(dealer.TotalScore() < 22 && dealer.ThePlayerHand().Count == 5)
            {
                return false;
            }
            else if(dealer.TotalScore() >= dealer.Satisfied && dealer.TotalScore() < 21)
            {
                return false;
            }
            else if(dealer.TotalScore() > 21)
            {
                dealer.IsBusted = true;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Compares the result between the player and dealer
        /// </summary>
        /// <param name="player">The player object</param>
        /// <param name="dealer">The dealer object</param>
        public void CompareResults(Player player, Dealer dealer)
        {
            if(player.IsBusted && !dealer.IsBusted)
            {
                Console.Write($"{player}: {player.ShowHand()}({player.TotalScore()}) BUSTED!");
                Console.WriteLine();
                Console.Write($"{dealer}: {dealer.ShowHand()}({dealer.TotalScore()}) WINS!");
                Console.WriteLine();
            }
            else if(!player.IsBusted && dealer.IsBusted)
            {
                Console.Write($"{player}: {player.ShowHand()}({player.TotalScore()}) WINS!");
                Console.WriteLine();
                Console.Write($"{dealer}: {dealer.ShowHand()}({dealer.TotalScore()}) BUSTED!");
                Console.WriteLine();
                
            }
            else if(!dealer.ShouldPlay)
            {
                Console.Write($"{player}: {player.ShowHand()}({player.TotalScore()}) WINS!");
                Console.WriteLine();
                Console.Write($"{dealer}: {dealer.ShowHand()}({dealer.TotalScore()})");
                Console.WriteLine();
            }
            else if(player.TotalScore() > dealer.TotalScore())
            {
                Console.Write($"{player}: {player.ShowHand()}({player.TotalScore()}) WINS!");
                Console.WriteLine();
                Console.Write($"{dealer}: {dealer.ShowHand()}({dealer.TotalScore()})");
                Console.WriteLine();
            }
            else if(player.TotalScore() < dealer.TotalScore() || player.TotalScore() == dealer.TotalScore())
            {
                Console.Write($"{player}: {player.ShowHand()}({player.TotalScore()})");
                Console.WriteLine();
                Console.Write($"{dealer}: {dealer.ShowHand()}({dealer.TotalScore()}) WINS!");
                Console.WriteLine();
            }
        }
        
    }
}

