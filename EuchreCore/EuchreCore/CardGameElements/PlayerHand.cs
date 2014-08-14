using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.CardGameElements
{
    internal class PlayerHand
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
            playerHand.Remove(c);
        }

        public Card[] GetListCards()
        {
            return playerHand.ToArray();
        }
    }
}
