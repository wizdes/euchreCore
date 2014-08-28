using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.CardGames
{
    public class HeartsGameState : GameState
    {
        private int lastTrickTaker;

        public HeartsGameState()
        {
            lastTrickTaker = -1;
        }

        public int getLastTrickTaker()
        {
            return lastTrickTaker;
        }

        public override void ClearCardsInMiddle()
        {
            lastTrickTaker = 0;
            base.ClearCardsInMiddle();
        }

    }
}
