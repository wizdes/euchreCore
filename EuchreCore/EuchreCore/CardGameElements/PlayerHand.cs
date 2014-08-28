using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGameElements
{
    public class PlayerHand
    {
        private List<Card> playerHand;

        public PlayerHand()
        {
            playerHand = new List<Card>();
        }

        public void Add(Card c)
        {
            playerHand.Add(c);
        }

        public void Remove(Card c)
        {
            foreach (Card playerCard in playerHand)
            {
                if (playerCard.Suit == c.Suit && playerCard.Value == c.Value)
                {
                    playerHand.Remove(playerCard);
                    break;
                }
            }
        }

        public Card[] GetListCards()
        {
            return playerHand.ToArray();
        }

        public override string ToString()
        {
            string cardStr = "";
            foreach (Card c in playerHand)
            {
                cardStr += c +",";
            }

            return cardStr;
        }
    }
}
