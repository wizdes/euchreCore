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
        public CardRule GetBasicAI()
        {
            CardRule rule = new ValidCardsRule();
            CardRule nextRule = new GetLowestCardsRule();
            CardRule randomRole = new RandomRule();

            nextRule.AddRule(randomRole);
            randomRole.AddRule(nextRule);

            return rule;
        }
    }
}
