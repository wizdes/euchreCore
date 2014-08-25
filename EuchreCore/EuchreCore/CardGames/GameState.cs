using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

namespace EuchreCore.CardGames
{
    public class GameState
    {
        internal List<Card> cardsInMiddle = new List<Card>();

        internal void putCardInMiddle(Card card)
        {
            cardsInMiddle.Add(card);
        }

        internal void clearCardsInMiddle()
        {
            cardsInMiddle.Clear();
        }
    }
}
