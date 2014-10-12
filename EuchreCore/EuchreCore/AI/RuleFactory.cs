using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.AI
{
    public class RuleFactory
    {
        // all rules created by the rule factory need to be start with valid card, and end with a 'choose one' rule
        public CardRule GetBasicAI()
        {
            CardRule baseValidRule = new ValidCardsRule();
            CardRule filterToLowestCard = new GetLowestCardsRule();
            CardRule randomRole = new RandomRule();

            baseValidRule.AddRule(filterToLowestCard);
            filterToLowestCard.AddRule(randomRole);

            return baseValidRule;
        }
    }
}
