using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

namespace EuchreCore.CardGames
{
    public class Trick
    {
        public Card card;
        public int player;

        public Trick(Card card, int player)
        {
            this.card = card;
            this.player = player;
        }
    }

    public class GameState
    {
        public List<Trick> CardsInMiddle = new List<Trick>();

        public void PutCardInMiddle(Card card, int player)
        {
            CardsInMiddle.Add(new Trick(card, player));
        }

        public virtual void ClearCardsInMiddle()
        {
            CardsInMiddle.Clear();
        }
    }
}
