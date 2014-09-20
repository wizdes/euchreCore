using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGames
{
    class HeartsPassingGameStage : GameStage
    {
        private List<Player> players;
        private List<List<Card>> cardsToPass;


        public HeartsPassingGameStage(List<Player> players)
        {
            this.players = players;
            cardsToPass = new List<List<Card>>();
        }

        public override void run()
        {
            run(0);
        }

        public override void run(int roundNumber)
        {
            // each player selects the cards they want to pass over
            foreach (Player player in players)
            {
                cardsToPass.Add(player.getCardsToPass(player.PlayerHand));
            }

            // wait for the players to be ready. This is necessary for a server-based approach.
            foreach (Player player in players)
            {
                player.waitToBeReady();
            }

            // now you have all the cards you want to pass
            // pass them!
            Dictionary<int, List<Card>> cardsToGameMap = removeAndGetAndOrganizePassedCardsApp(cardsToPass, roundNumber);

            for(int i = 0; i < players.Count; i++)
            {
                List<Card> cardsToGiveAway = cardsToPass.ElementAt(i);
                foreach (Card c in cardsToGiveAway)
                {
                    players[i].removeCard(c);
                }

                foreach (Card c in cardsToGameMap[i])
                {
                    players[i].giveCard(c);
                }
            }
        }

        private Dictionary<int, List<Card>> removeAndGetAndOrganizePassedCardsApp(List<List<Card>> cardsToPass, int roundNumber)
        {
            Dictionary<int, List<Card>> cardsToMap = new Dictionary<int, List<Card>>();
            int delta = 0;
            switch (roundNumber%3)
            {
                case 0:
                    delta = 3;
                    break;
                case 3:
                    delta = 0;
                    break;
                default:
                    delta = roundNumber;
                    break;
            }
            for (int i = 0; i < 4; i++)
            {
                cardsToMap.Add((i + delta) % 4, cardsToPass[i]);
            }

            return cardsToMap;
        }

        public override string ToString()
        {
            string str = "Passing stage of hearts: \n";

            int player = 0;

            foreach (List<Card> handsToPass in cardsToPass)
            {
                str += "Player " + player++ + ": ";
                foreach (Card c in handsToPass)
                {
                    str += c + " ";
                }
                str += " to pass.\n";
            }

            return str;
        }
    }
}
