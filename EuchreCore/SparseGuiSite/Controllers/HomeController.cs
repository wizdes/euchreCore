using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
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
        static IDictionary<Guid, HeartsCardGame> inMemoryMapping = new Dictionary<Guid, HeartsCardGame>();

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
                    int player = int.Parse(Request.QueryString["playerNum"]);
                    HeartsCardGame game = inMemoryMapping[gameId];
                    WebCmdInterface webInterface = (WebCmdInterface)game.Players[player].CmdInterface;
                    webInterface.setInputRelease(cardsPlayed);
                    Thread.Sleep(100);
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
            ViewData["gameDetails"] = game.ToString();
            ViewData["gameId"] = gameGuid.ToString();
            ViewData["gameDescription"] = gameDetails;
            ViewData["CmdDetails"] = "";
            ViewData["playerNum"] = "0";

            foreach (Player p in game.Players)
            {
                WebCmdInterface webInterface = ((WebCmdInterface) p.CmdInterface);
                ViewData["CmdDetails"] += webInterface.currentOutput + "\n";
                if (webInterface.isWaiting)
                {
                    ViewData["playerNum"] = p.Id;
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

            //add the game to the inMemoryMapping
            inMemoryMapping.Add(guid, game);
            Thread oThread = new Thread(game.run);
            oThread.Start();

            Thread.Sleep(100);

            ShowGameView(game, guid);

            return View();
        }
    }
}