using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGames;
using EuchreCore.Interface;

namespace EuchreCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Create the Game
            CardGame game = new HeartsCardGame();

            // initialize the game
            game.init(IOType.CmdLine);

            // run the game
            game.run();

            //exit
            game.clear();
        }
    }
}
