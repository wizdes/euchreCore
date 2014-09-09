using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.Interface;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGames
{
    public class HeartsCardGame : CardGame
    {
        private Deck deck;
        private List<Player> players;

        public List<Player> Players
        {
            get { return players; }
        } 

        public HeartsCardGame()
        {
            players = new List<Player>();
            deck = new Deck();
        }

        public override void init(IOType inputType)
        {
            // set up the deck
            deck.shuffle();

            // create the player hands
            for (int i = 0; i < 4; i++)
            {
                PlayerHand playerHand = new PlayerHand();
                for (int j = 0; j < 13; j++)
                {
                    playerHand.Add(deck.deal());
                }

                CmdInterface input;
                switch (inputType)
                {
                    case IOType.AI:
                        input = new AICmdInterface();
                        break;
                    case IOType.CmdLine:
                        input = new CommandLineCmdInterface();
                        break;
                    case IOType.Web:
                        input = new WebCmdInterface();
                        break;
                    default:
                        throw new Exception("Bad IO input");

                }

                players.Add(new HeartsPlayer(input, i, playerHand));
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
                GameStage passingStage = new HeartsPassingGameStage(players);

                // after this, each playerHand is valid, and players know what is going on
                passingStage.run(round);

                // run the playing stage of the game
                GameStage playingStage = new HeartsPlayingGameStage(players);

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
