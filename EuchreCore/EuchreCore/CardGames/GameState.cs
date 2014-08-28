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

        public Dictionary<int, List<Card>> CardsCollected = new Dictionary<int, List<Card>>();

        public GameState()
        {
            for (int i = 0; i < 4; i++)
            {
                CardsCollected[i] = new List<Card>();
            }
        }

        public virtual void PutCardInMiddle(Card card, int player)
        {
            CardsInMiddle.Add(new Trick(card, player));
        }

        public virtual void ClearCardsInMiddle()
        {
            foreach (Trick t in CardsInMiddle)
            {
                CardsCollected[t.player].Add(t.card);
            }

            CardsInMiddle.Clear();
        }
    }
}
