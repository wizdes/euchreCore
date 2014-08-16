using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGames
{
    class HeartsWarCardGame : CardGame
    {
        private Deck deck;
        private List<PlayerHand> playerHands;
        private List<Player> players; 

        public override void init()
        {
            // set up the deck
            deck = new Deck();
            deck.shuffle();

            // create the player hands
            for (int i = 0; i < 4; i++)
            {
                playerHands.Add(new PlayerHand());
                players.Add(new HeartsPlayer());
            }
        }

        public override void run()
        {
            // run the passing stage of the game
            GameStage passingStage = new HeartsPassingGameStage(deck, playerHands);

            passingStage.run();

            // run the playing stage of the game
        }

        public override void clear()
        {
            // do nothing.
        }
    }
}
