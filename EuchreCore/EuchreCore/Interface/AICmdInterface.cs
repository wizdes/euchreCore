using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    class AICmdInterface : CmdInterface
    {
        public override void SendOutput(string str)
        {
            throw new NotImplementedException();
        }

        public override string GetInputLine()
        {
            throw new NotImplementedException();
        }

        public override bool isAI()
        {
            return true;
        }
    }
}
