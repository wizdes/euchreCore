using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.CardGames;
using EuchreCore.Interface;

namespace EuchreCore.PlayerClass
{
    public class HeartsPlayer : Player
    {
        public HeartsPlayer(CmdInterface cmdInterface, int playerValue, PlayerHand playerHand)
        {
            if (cmdInterface != null)
            {
                this.cmdInterface = cmdInterface;
            }
            else
            {
                this.cmdInterface = new AICmdInterface();
            }

            playerId = playerValue;

            this.playerHand = playerHand;
        }

        public HeartsPlayer(CmdInterface cmdInterface, int playerValue)
            : this(cmdInterface, playerValue, new PlayerHand()) {}

        public HeartsPlayer(int playerValue) : this(null, playerValue) {}

        public HeartsPlayer() : this(0) {}

        public override List<Card> getCardsToPass(PlayerHand hand)
        {
            cmdInterface.SendOutput(hand.ToString());
            string inputCards = cmdInterface.GetInputLine();
            return ConvertStringToCards(inputCards);
        }

        private List<Card> ConvertStringToCards(string inputCards)
        {
            List<Card> cardsRecieved = new List<Card>();
            string[] cardStringArray = inputCards.Split(' ');
            foreach (string s in cardStringArray)
            {
                cardsRecieved.Add(ConvertStringToCard(s));
            }
            return cardsRecieved;
        }

        private Card ConvertStringToCard(string s)
        {
            string suit = s.ElementAt(0).ToString();
            string remainingString = s.Remove(0, 1);
            switch (remainingString.ToLower())
            {
                case "j":
                    remainingString = "11";
                    break;
                case "q":
                    remainingString = "12";
                    break;
                case "k":
                    remainingString = "13";
                    break;
                case "a":
                    remainingString = "1";
                    break;
            }
            int cardValue = int.Parse(remainingString);
            return new Card(cardValue, Card.ConvertStrToSuit(suit));
        }

        public override void waitToBeReady()
        {
            
        }

        public override Card play(GameState gameState)
        {
            throw new NotImplementedException();
        }

        public override void removeCard(Card card)
        {
            playerHand.Remove(card);
        }

        public override void giveCard(Card card)
        {
            playerHand.Add(card);
        }
    }
}
