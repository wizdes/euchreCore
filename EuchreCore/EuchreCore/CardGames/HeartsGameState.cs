using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

namespace EuchreCore.CardGames
{
    public class HeartsGameState : GameState
    {
        private int lastTrickTaker;

        private Suit startingSuit;

        public HeartsGameState()
        {
            lastTrickTaker = -1;
            startingSuit = Suit.None;
        }

        public int getLastTrickTaker()
        {
            return lastTrickTaker;
        }

        public override void PutCardInMiddle(CardGameElements.Card card, int player)
        {
            if (CardsInMiddle.Count == 0)
            {
                startingSuit = card.Suit;
            }

            base.PutCardInMiddle(card, player);
        }

        public bool IsFirstGreaterThanSecond(int x, int y)
        {
            if (x == 1 || x > y)
            {
                return true;
            }

            return false;
        }

        public override void ClearCardsInMiddle()
        {
            lastTrickTaker = 0;
            startingSuit = Suit.None;
            int highestValue = CardsInMiddle[0].card.Value;
            foreach (Trick t in CardsInMiddle)
            {
                if(IsFirstGreaterThanSecond(t.card.Value,highestValue))
                {
                    lastTrickTaker = t.player;
                    highestValue = t.card.Value;
                }
            }

            base.ClearCardsInMiddle();
        }

    }
}
