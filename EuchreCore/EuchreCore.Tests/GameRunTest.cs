using System;
using System.Collections.Generic;
using EuchreCore.AI;
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
            // run the playing stage of the game
            List<Player> players = new List<Player>();

            List<List<string>> preListedCards = new List<List<string>>();
            List<List<Card>> playerCards = new List<List<Card>>();

            playerCards.Add(new List<Card>{new Card(2, Suit.Clubs), new Card(13, Suit.Hearts)});
            playerCards.Add(new List<Card> { new Card(13, Suit.Spades), new Card(9, Suit.Clubs) });
            playerCards.Add(new List<Card> { new Card(10, Suit.Hearts), new Card(9, Suit.Hearts) });
            playerCards.Add(new List<Card> { new Card(10, Suit.Clubs), new Card(2, Suit.Hearts) });

            preListedCards.Add(new List<string> { "c2", "hk" });
            preListedCards.Add(new List<string> { "sk", "c9" });
            preListedCards.Add(new List<string> { "h10", "h9" });
            preListedCards.Add(new List<string> { "c10", "h2" });

            for (int i = 0; i < 4; i++)
            {
                PlayerHand playerHand = new PlayerHand();

                for (int j = 0; j < 2; j++)
                {
                    playerHand.Add(playerCards[i][j]);
                }

                MockCmdInterface input = new MockCmdInterface();

                for (int j = 0; j < 2; j++)
                {
                    input.inputs.Add(preListedCards[i][j]);
                }

                players.Add(new HeartsPlayer(input, i, playerHand));
            }

            HeartsPlayingGameStage playingStage = new HeartsPlayingGameStage(players);

            playingStage.run(0);

            Assert.AreEqual(3, players[0].score);
            Assert.AreEqual(0, players[1].score);
            Assert.AreEqual(0, players[2].score);
            Assert.AreEqual(1, players[3].score);
        }

        [TestMethod]
        public void TestAIRules()
        {
            CardRule r = new GetLowestCardsRule();
            
        }
    }
}
