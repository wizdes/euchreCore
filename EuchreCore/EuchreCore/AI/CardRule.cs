using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.CardGames;
using EuchreCore.PlayerClass;

namespace EuchreCore.AI
{
    public abstract class CardRule
    {
        protected List<CardRule> nextRule;

        public abstract Card Decide(List<Card> cards, GameState gamestate, Player player);

        public void AddRule(CardRule r, bool recursive)
        {
            
        }
    }
}
