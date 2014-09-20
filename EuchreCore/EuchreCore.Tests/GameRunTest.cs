using System;
using System.Collections.Generic;
using EuchreCore.CardGameElements;
using EuchreCore.CardGames;
using EuchreCore.Interface;
using EuchreCore.PlayerClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuchreCore.Tests
{
    [TestClass]
    public class GameRunTest
    {
        [TestMethod]
        public void HeartsGameBasicRun()
        {
            // run the playing stage of the game
            List<Player> players = new List<Player>();

            for (int i = 0; i < 4; i++)
            {
                PlayerHand playerHand = new PlayerHand();
                playerHand.Add(new Card(2, Suit.Clubs));
                playerHand.Add(new Card(3, Suit.Clubs));

                MockCmdInterface input = new MockCmdInterface();

                input.inputs.Add("c2");
                input.inputs.Add("c3");

                players.Add(new HeartsPlayer(input, i, playerHand));
            }

            GameStage playingStage = new HeartsPlayingGameStage(players);

            playingStage.run(0);

            // TODO: do some more verification stuff.
        }

        [TestMethod]
        public void HeartsGameEndGameRun()
        {
            
        }
    }
}
