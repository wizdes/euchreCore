﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

namespace EuchreCore.PlayerClass
{
    public class HeartsPlayer : Player
    {
        public HeartsPlayer(int playerValue)
        {
            playerId = playerValue;
        }


        public HeartsPlayer() : this(0)
        {
        }

        public override List<Card> getCardsToPass(PlayerHand hand)
        {
            throw new NotImplementedException();
        }

        public override void waitToBeReady()
        {
            
        }

        public override void giveCards(List<Card> cardsToGame)
        {
            throw new NotImplementedException();
        }

        public override void play()
        {
            throw new NotImplementedException();
        }
    }
}
