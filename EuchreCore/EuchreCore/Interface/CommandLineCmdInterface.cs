using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuchreCore.Interface
{
    public class CommandLineCmdInterface : CmdInterface
    {
        internal override void SendOutput(string str)
        {
            Console.Write(str);
        }

        internal override string GetInputLine()
        {
            return Console.ReadLine();

        }
    }
}
