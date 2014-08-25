using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

// TODO: NOT USED!!!!
// BUG: DO NOT USE THIS. We will use AI interfaces instead.

namespace EuchreCore.PlayerClass
{
    class HeartsAIPlayer : Player
    {
        public override List<Card> getCardsToPass(PlayerHand hand)
        {
            throw new NotImplementedException();
        }

        public override void waitToBeReady()
        {
            throw new NotImplementedException();
        }

        public override void play()
        {
            throw new NotImplementedException();
        }

        public override void removeCard(Card card)
        {
            throw new NotImplementedException();
        }

        public override void giveCard(Card card)
        {
            throw new NotImplementedException();
        }
    }
}
