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
            throw new NotImplementedException();
        }
    }
}
