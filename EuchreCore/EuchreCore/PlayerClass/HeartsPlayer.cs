using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.Interface;

namespace EuchreCore.PlayerClass
{
    public class HeartsPlayer : Player
    {
        public HeartsPlayer(CmdInterface cmdInterface, int playerValue)
        {
            if (cmdInterface != null)
            {
                this.cmdInterface = cmdInterface;
            }
            else
            {
                this.cmdInterface = new AICmdInterface();
            }

            this.playerId = playerValue;
        }

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
            int cardValue = int.Parse(s.Substring(1));
            return new Card(cardValue, Card.ConvertStrToSuit(suit));
        }

        public override void waitToBeReady()
        {
            
        }

        public override void giveCards(List<Card> cardsToGame)
        {
            throw new NotImplementedException();
        }

        public override void play()
        {
            throw new NotImplementedException();
        }
    }
}
