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
    public class ValidCardsRule : CardRule
    {
        public override Card Decide(List<Card> cards, GameState gamestate, Player player)
        {
            List<Card> potentialCards = FilterByRule(cards, gamestate, player);

            throw new NotImplementedException();
        }

        public List<Card> FilterByRule(List<Card> cards, GameState gamestate, Player player)
        {
            bool heartsBroken = false;
            
            // here, calculate if hearts has been broken or not
            
            if (gamestate.CardsInMiddle.Count == 0)
            {
                // any non-hearts card, unless hearts is broken

            }
            else
            {
                
            }

            throw new NotImplementedException();
        }
    }
}
