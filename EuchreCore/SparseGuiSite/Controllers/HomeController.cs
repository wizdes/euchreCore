using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuchreCore.CardGames;
using EuchreCore.Interface;
using EuchreCore.PlayerClass;
using Microsoft.Ajax.Utilities;

namespace SparseGuiSite.Controllers
{
    public class HomeController : Controller
    {
        IDictionary<Guid, CardGame> inMemoryMapping = new Dictionary<Guid, CardGame>();

        enum WebGameState
        {
            ShowNewGame,
            CreateNewGame,
            InGameProgress
        }

        public ActionResult Index()
        {
            WebGameState webGameState = GetWebGameState();

            switch (webGameState)
            {
                case WebGameState.ShowNewGame:
                    return View();
                case WebGameState.CreateNewGame:
                    return CreateGame();
                case WebGameState.InGameProgress:
                    // update this to get passing stage working 9/9
                    return View();
                default:
                    return View();
            }
        }

        private WebGameState GetWebGameState()
        {
            if (Request.QueryString.Count == 0)
            {
                return WebGameState.ShowNewGame;
            }
            else
            {
                string gameId = Request.QueryString["gameId"];
                if (gameId.Equals("newGame"))
                {
                    return WebGameState.CreateNewGame;
                }
                else
                {
                    return WebGameState.InGameProgress;
                }
            }
        }

        private ActionResult CreateGame()
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