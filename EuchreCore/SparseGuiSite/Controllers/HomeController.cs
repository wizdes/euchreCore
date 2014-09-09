using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuchreCore.CardGames;
using EuchreCore.Interface;
using EuchreCore.PlayerClass;

namespace SparseGuiSite.Controllers
{
    public class HomeController : Controller
    {
        IDictionary<Guid, CardGame> inMemoryMapping = new Dictionary<Guid, CardGame>();

        public ActionResult Index()
        {
            // if the special word is 'new game', then create a new game and return details
            // create a new game and guid to associate with
            Guid guid = Guid.NewGuid();
            HeartsCardGame game = new HeartsCardGame();

            game.init(IOType.Web);

            string gameDetails = string.Empty;

            int playerNum = 1;

            foreach (Player p in game.Players)
            {
                gameDetails += "Player " + playerNum + ": " + p.PlayerHand + "\n";
                playerNum++;
            }

            // pass the game state information to the ViewBag
            // pass guid to the ViewBag
            ViewData["gameDetails"] = game;
            ViewData["gameId"] = guid.ToString();
            ViewData["gameDescription"] = gameDetails;

            //add the game to the inMemoryMapping
            inMemoryMapping.Add(guid, game);

            return View();
        }
    }
}