using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.PlayerClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EuchreCore.CardGames
{
    internal class HeartsPlayingGameStage : GameStage
    {
        private Deck deck;
        private List<PlayerHand> playerHands;
        private List<Player> players; 

        public HeartsPlayingGameStage(List<Player> players)
        {
            this.deck = deck;
            this.playerHands = playerHands;
            this.players = players;
        }

        public override void run()
        {
            run(0);
        }

        public override void run(int round)
        {
            bool continueRound = true;
            int numInternalRounds = 0;

            HeartsGameState gameState = new HeartsGameState();

            while (continueRound)
            {
                // first, determine who goes first
                int firstPlayerMark = DetermineFirstPlayer(gameState, players);
                // in > (), out < (int of player who goes first)

                PlayRound(firstPlayerMark, gameState);
                
                if (numInternalRounds == 13)
                {
                    continueRound = false;
                }

                numInternalRounds++;
            }

            // determine points
                // in > (game state of picked up tricks), out < (points for all)
                // TODO: make a class that represents this, and pass it from outside
        }

        private void PlayRound(int firstPlayerMark, HeartsGameState gameState)
        {
            // start from that player, and iterate and go through each player
            Assert.IsTrue(firstPlayerMark < 4);

            for (int i = 0; i < 4; i++)
            {
                int currentPlayerRound = (firstPlayerMark + i) % 4;

                // each player must play one card
                // in > (game state), out < (card played)                
                Card c = players.ElementAt(currentPlayerRound).play(gameState);

                // update the game state to reflect (card played)
                gameState.PutCardInMiddle(c, currentPlayerRound);
            }
            
            // determine who gets the trick
            // in > (game state), out < (int of player who got the trick)
            // keep track of who last picked up the trick
            gameState.ClearCardsInMiddle();
        }

        private int DetermineFirstPlayer(HeartsGameState heartsGameState, List<Player> players)
        {
            if (heartsGameState.getLastTrickTaker() == -1)
            {
                return playerWithAceTwo(players);
            }

            return heartsGameState.getLastTrickTaker();
        }

        private int playerWithAceTwo(List<Player> list)
        {
            for(int i = 0; i < 4; i++)
            {
                if (list.ElementAt(i).PlayerHand.GetListCards().Any(x => x.Suit == Suit.Clubs && x.Value == 2))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
