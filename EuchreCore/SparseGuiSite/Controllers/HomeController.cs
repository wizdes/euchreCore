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
        IDictionary<Guid, HeartsCardGame> inMemoryMapping = new Dictionary<Guid, HeartsCardGame>();

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
                    string cardsPlayed = Request.QueryString["input"];
                    Guid gameId = new Guid(Request.QueryString["gameId"]);
                    HeartsCardGame game = inMemoryMapping[gameId];
                    //todo: change from player 0
                    WebCmdInterface webInterface = (WebCmdInterface)game.Players[0].CmdInterface;
                    webInterface.setInputRelease(cardsPlayed);
                    // update web cmd interface's get input to wait on update of a string
                    ShowGameView(game, gameId);
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

        private void ShowGameView(HeartsCardGame game, Guid gameGuid)
        {
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
            ViewData["gameId"] = gameGuid.ToString();
            ViewData["gameDescription"] = gameDetails;            
        }

        private ActionResult CreateGame()
        {
            // if the special word is 'new game', then create a new game and return details
            // create a new game and guid to associate with
            Guid guid = Guid.NewGuid();
            HeartsCardGame game = new HeartsCardGame();

            game.init(IOType.Web);

            ShowGameView(game, guid);

            //add the game to the inMemoryMapping
            inMemoryMapping.Add(guid, game);

            return View();
        }
    }
}