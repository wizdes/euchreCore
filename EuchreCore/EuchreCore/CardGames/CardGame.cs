using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.Interface;

namespace EuchreCore.CardGames
{
    abstract public class CardGame
    {
        public abstract void init(IOType inputType);
        public abstract void run();
        public abstract void clear();
    }
}
