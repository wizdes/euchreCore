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
            // each player selects the cards they want to pass over
            foreach (Player player in players)
            {
                player.getCardsToPass(playerHands.ElementAt(player.Id));
            }

            // wait for the players to be ready. This is necessary for a server-based approach.
            foreach (Player player in players)
            {
                player.waitToBeReady();
            }

            // now you have all the cards you want to pass
            // pass them!
            Dictionary<int, List<Card>> cardsToGameMap = getAndOrganizePassedCardsApp(players, roundNumber);

            for(int i = 0; i < players.Count; i++)
            {
                players[i].giveCards(cardsToGameMap[i]);
            }

        }

        private Dictionary<int, List<Card>> getAndOrganizePassedCardsApp(List<Player> list, int roundNumber)
        {
            throw new NotImplementedException();
        }
    }
}
