using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

namespace EuchreCore.PlayerClass
{
    public abstract class Player
    {
        public abstract void getCardsToPass();

        public abstract void waitToBeReady();

        public abstract void giveCards(List<Card> cardsToGame);
    }
}
