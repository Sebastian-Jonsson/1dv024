using System;
using System.Linq;

namespace TwentyOne
{

    /// <summary>
    /// Class named Rules that sets the rules and demands made inside of the game and decides when each should happen.
    /// </summary>
    class Rules
    {
        /// <summary>
        /// Is used in to help check if the limit of points has been reached of if a player or dealer has won.
        /// </summary>
        private static bool Limit;

        /// <summary>
        /// Is used to set which Person is the winner, dealer or player alike.
        /// </summary>
        private static Person Winner;

        /// <summary>
        /// Sets the revealed hand for the final showdown between player and dealer.
        /// </summary>
        private static string RevealedHand;

        /// <summary>
        /// Method that sees to it that each round of the game is handled properly in logical order.
        /// </summary>
        public static void GameRounds()
        {
            DealCardsToAll();
            for (var i = 0; i < Table.PlayerAmount; i++)
            {
                
                if (Table.Participants[i].Hand.Fingers.Count() < 5 && Table.Participants[i].TotalHandValue() < Table.Participants[i].Boldness)
                {
                    while (Table.Participants[i].TotalHandValue() < Table.Participants[i].Boldness)
                    {
                        if (Table.Participants[i].TotalHandValue() < Table.Participants[i].Boldness)
                        {
                            Dealer.ReshuffleEmptyDeck();
                            Table.Participants[i].Hand.AddCardToHand(Dealer.DealSingleCard());
                            CheckAce(Table.Participants[i]);
                        }
                    }

                    if (!PointChecker(Table.Participants[i], Table.GameDealer))
                    {
                        while (Table.GameDealer.TotalHandValue() < Table.GameDealer.Boldness)
                        {
                            if (Table.GameDealer.TotalHandValue() < Table.GameDealer.Boldness) {
                                Dealer.ReshuffleEmptyDeck();
                                Table.GameDealer.Hand.AddCardToHand(Dealer.DealSingleCard());
                                CheckAce(Table.GameDealer);
                            }
                        }
                        
                        if (!PointChecker(Table.GameDealer, Table.Participants[i]))
                        {
                            CheckWinner(Table.Participants[i], Table.GameDealer);
                        }
                    }
                }
                TossCards(Table.Participants[i]);
                TossCards(Table.GameDealer);
            }
        }

        /// <summary>
        /// Supportive method of GameRounds which gives all participants a single card as per rules, before the game starts each round.
        /// </summary>
        private static void DealCardsToAll()
        {
            for (var i = 1; i <= Table.PlayerAmount; i++)
            {
            Table.Participants[i - 1].Hand.AddCardToHand(Dealer.DealSingleCard());
            }
        }

        /// <summary>
        /// Supportive method of GameRounds that tosses all cards of currently active player and dealer after each round.
        /// </summary>
        /// <param name="person"></param>
        private static void TossCards(Person person)
        {
            while (person.Hand.Fingers.Count > 0)
            {
                Card tossedCard = (person.Hand.Fingers[person.Hand.Fingers.Count - 1]);
                person.Hand.Fingers.RemoveAt(person.Hand.Fingers.Count - 1);
                
                Deck.UsedCards.Add(tossedCard);
            }

        }

        /// <summary>
        ///  Checks if the game comes to a direct conclusion and thus skips the Dealers turn.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dealer"></param>
        /// <returns></returns>
        private static bool PointChecker(Person person, Person dealer)
        {
            
            Limit = false;
            if (person.TotalHandValue() == 21)
            {
                Limit = true;
                Winner = person;
                PrintResults(person, dealer, Winner);
            }
            if (person.TotalHandValue() < 21 && person.Hand.Fingers.Count() == 5)
            {
                Limit = true;
                Winner = person;
                PrintResults(person, dealer, Winner);
            }
            if (person.TotalHandValue() > 21)
            {
                Limit = true;
                Winner = dealer;
                PrintResults(person, dealer, Winner);
            }
            return Limit;
        }

        /// <summary>
        /// Method that checks if the value is an Ace or not, due to it's dual value and alters it if required by either player or dealers boldness.
        /// </summary>
        /// <param name="person"></param>
        private static void CheckAce(Person person)
        {
            if (person.TotalHandValue() > 21)
            {
                for (var i = 0; i < person.Hand.Fingers.Count(); i++)
                {
                    if (person.Hand.Fingers[i].Value == 14)
                    {
                        person.Hand.Fingers[i].Value = 1;

                    }
                    if (person.TotalHandValue() < 21)
                    {
                        break;
                    }
                    

                }

            }
        }

        /// <summary>
        /// Compares the values between Dealer and Player and determines which one is the winner.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dealer"></param>
        private static void CheckWinner(Player person, Dealer dealer)
        {
            if (person.TotalHandValue() > dealer.TotalHandValue())
            {
                Winner = person;
                PrintResults(person, dealer, Winner);
            }
            else if (dealer.TotalHandValue() == person.TotalHandValue())
            {
                Winner = dealer;
                PrintResults(person, dealer, Winner);
            }
            else 
            {
                Winner = dealer;
                PrintResults(person, dealer, Winner);
            }
        }

        /// <summary>
        /// The method that helps reveal the hand of any Person.
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private static string RevealCards(Person person)
        {
            RevealedHand = "";
            foreach (Card card in person.Hand.Fingers)
            {
                RevealedHand += $"{card.CardRanker} ";
            }
            return RevealedHand;
        }

        /// <summary>
        /// Method that prints the results of the round between the Dealer and Player, revealing the winner and what cards each Person had.
        /// </summary>
        /// <param name="person"></param>
        /// <param name="dealer"></param>
        /// <param name="winner"></param>
        private static void PrintResults(Person person, Person dealer, Person winner)
        {
            Console.WriteLine($"{person.Name} had {RevealCards(person)}with a Total of {person.TotalHandValue()} points.");

            Console.WriteLine($"{dealer.Name} had {RevealCards(dealer)}with a Total of {dealer.TotalHandValue()} points.");
            Console.WriteLine($"Winner: {winner.Name}!");
            Console.WriteLine($"");
        }
    }
}