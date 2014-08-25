using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
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

        public abstract List<Card> getCardsToPass(PlayerHand hand);

        public abstract void waitToBeReady();

        public abstract void play();

        public abstract void removeCard(Card card);

        public abstract void giveCard(Card card);
    }
}
