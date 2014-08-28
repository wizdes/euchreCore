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

        public Dictionary<int, int> score;

        public HeartsGameState()
        {
            lastTrickTaker = -1;
            startingSuit = Suit.None;
            score = new Dictionary<int, int>
            {
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0}
            };
        }

        public int GetLastTrickTaker()
        {
            return lastTrickTaker;
        }

        public override void PutCardInMiddle(Card card, int player)
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
                if(IsFirstGreaterThanSecond(t.card.Value,highestValue) && t.card.Suit == startingSuit)
                {
                    lastTrickTaker = t.player;
                    highestValue = t.card.Value;
                }
            }

            base.ClearCardsInMiddle();
        }

        public void CalculateRoundScore()
        {
            for (int i = 0; i < 4; i++)
            {
                if (CardsCollected[i].Count == 52)
                {
                    //He shot the moon!

                    for (int moonSucker = 0; moonSucker < 4; moonSucker++)
                    {
                        if (moonSucker == 1)
                        {
                            continue;
                        }

                        score[moonSucker] += 26;
                    }
                    break;
                }
                else
                {
                    foreach (Card c in CardsCollected[i])
                    {
                        if (c.Suit == Suit.Hearts)
                        {
                            score[i] += 1;
                        }
                        else if (c.Suit == Suit.Spades && c.Value == 12)
                        {
                            score[i] += 13;
                        }
                    }                    
                }
            }
        }
    }
}
