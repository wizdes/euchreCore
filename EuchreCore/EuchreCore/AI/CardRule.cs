using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuchreCore.CardGameElements;

namespace EuchreCore.AI
{
    public abstract class CardRule
    {
        protected List<CardRule> nextRule;

        public abstract Card Decide(List<Card> cards);
    }
}
