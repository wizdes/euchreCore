﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.CardGames
{
    public abstract class GameStage
    {
        public abstract void run();

        public abstract void run(int round);
    }
}
