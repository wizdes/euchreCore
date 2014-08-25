using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGames
{
    class HeartsCardGame : CardGame
    {
        private Deck deck;
        private List<PlayerHand> playerHands;
        private List<Player> players;
        private GameState HeartsGameState;

        public override void init()
        {
            // set up the deck
            deck = new Deck();
            deck.shuffle();

            // create the player hands
            for (int i = 0; i < 4; i++)
            {
                playerHands.Add(new PlayerHand());
                players.Add(new HeartsAIPlayer());
            }

            // set up the hearts game state
        }

        public override void run()
        {
            // run the passing stage of the game
            bool gameFinished = false;

            int round = 0;

            while (!gameFinished)
            {
                GameStage passingStage = new HeartsPassingGameStage(deck, playerHands, players);

                // after this, each playerHand is valid, and players know what is going on
                passingStage.run(round);

                // run the playing stage of the game
                GameStage playingStage = new HeartsPlayingGameStage(deck, playerHands, players);

                playingStage.run(round);

                round++;
            }
        }

        public override void clear()
        {
            // do nothing.
        }
    }
}
