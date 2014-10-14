using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.CardGames;
using EuchreCore.PlayerClass;

namespace EuchreCore.AI
{
    public class GetLowestCardsRule : CardRule
    {
        public override Card Decide(List<Card> cards, GameState gamestate, Player player)
        {
            List<Card> potentialCards = FilterByRule(cards, gamestate, player);

            throw new NotImplementedException();
        }

        public List<Card> FilterByRule(List<Card> cards, GameState gamestate, Player player)
        {
            Suit[] suits = new Suit[]
            {
                Suit.Clubs,
                Suit.Diamonds,
                Suit.Hearts,
                Suit.Spades
            };

            foreach (Suit s in suits)
            {
                Card lowestCard = null;
                foreach (Card c in cards)
                {
                    if (c.Suit.Equals(s))
                    {
                        if (lowestCard == null)
                        {
                            lowestCard = c;
                        }
                        else if(c.Value < lowestCard.Value)
                        {
                            lowestCard = c;
                        }
                    }
                }

                if (lowestCard != null)
                {
                    cards.RemoveAll(x => x != lowestCard);                    
                }
            }

            return cards;
        }
    }
}
