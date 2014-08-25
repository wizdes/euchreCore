using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;
using EuchreCore.PlayerClass;

namespace EuchreCore.CardGames
{
    class HeartsPassingGameStage : GameStage
    {
        private Deck deck;
        private List<PlayerHand> playerHands;
        private List<Player> players; 

        public HeartsPassingGameStage(Deck deck, List<PlayerHand> playerHands, List<Player> players)
        {
            // do nothing
            this.deck = deck;
            this.playerHands = playerHands;
            this.players = players;
        }

        public override void run()
        {
            run(0);
        }

        public override void run(int roundNumber)
        {
            List<List<Card>> cardsToPass = new List<List<Card>>();

            // each player selects the cards they want to pass over
            foreach (Player player in players)
            {
                cardsToPass.Add(player.getCardsToPass(playerHands.ElementAt(player.Id)));
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
                players[i].giveCards(cardsToGameMap[i]);
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

                // TODO: add the remove card part
                throw new NotImplementedException();

                cardsToMap.Add((i + delta)%3, cardsToPass[i]);
            }

            return cardsToMap;
        }
    }
}
