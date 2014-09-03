using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EuchreCore.CardGames;
using EuchreCore.Interface;

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
            CardGame game = new HeartsCardGame();

            game.init(IOType.CmdLine);

            // pass the game state information to the ViewBag
            // pass guid to the ViewBag
            ViewData["gameDetails"] = game;
            ViewData["gameId"] = guid;

            //add the game to the inMemoryMapping
            inMemoryMapping.Add(guid, game);

            return View();
        }
    }
}