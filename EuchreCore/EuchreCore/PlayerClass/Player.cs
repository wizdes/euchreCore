using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.CardGames;
using EuchreCore.Interface;

namespace EuchreCore.PlayerClass
{
    public abstract class Player
    {
        protected PlayerHand playerHand;

        public PlayerHand PlayerHand
        {
            get { return playerHand; }
        }

        protected int playerId;

        protected CmdInterface cmdInterface;

        public int Id
        {
            get { return playerId; }
        }

        public int score;

        public abstract List<Card> getCardsToPass(PlayerHand hand);

        public abstract void waitToBeReady();

        public abstract Card play(GameState gameState);

        public abstract void removeCard(Card card);

        public abstract void giveCard(Card card);
    }
}
