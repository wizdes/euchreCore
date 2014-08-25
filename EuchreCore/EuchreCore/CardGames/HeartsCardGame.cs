﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.Interface;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGames
{
    class HeartsCardGame : CardGame
    {
        private Deck deck;
        private List<PlayerHand> playerHands;
        private List<Player> players;
        private GameState HeartsGameState;

        public HeartsCardGame()
        {
            playerHands = new List<PlayerHand>();
            players = new List<Player>();
            HeartsGameState = new GameState();
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

                playerHands.Add(playerHand);

                CmdInterface input;
                switch (inputType)
                {
                    case IOType.AI:
                        input = new AICmdInterface();
                        break;
                    case IOType.CmdLine:
                        input = new CommandLineCmdInterface();
                        break;
                    default:
                        throw new Exception("Bad IO input");

                }

                players.Add(new HeartsPlayer(input, i));
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
