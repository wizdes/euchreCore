using System;
using System.Collections.Generic;
using EuchreCore.CardGameElements;
using EuchreCore.CardGames;
using EuchreCore.PlayerClass;

namespace EuchreCore.AI
{
    public class RandomRule : CardRule
    {
        public override Card Decide(List<Card> cards, GameState gamestate, Player player)
        {
            Random r = new Random();
            int selectedCard = r.Next(cards.Count);
            return cards.ToArray()[selectedCard];
        }
    }
}
