using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    class WebCmdInterface : CmdInterface
    {
        internal override void SendOutput(string str)
        {
            //throw new NotImplementedException();
        }

        internal override string GetInputLine()
        {
            return "";
            //throw new NotImplementedException();
        }
    }
}
